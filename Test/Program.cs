using Evergine.Bindings.MuJoCo;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Test
{
	unsafe class Program
	{
		private const string Model = """
			<mujoco model="hello">
			  <option timestep="0.002"/>
			  <worldbody>
			    <geom name="floor" type="plane" size="5 5 0.1"/>
			    <body name="ball" pos="0 0 1">
			      <freejoint/>
			      <geom name="ball" type="sphere" size="0.1"/>
			    </body>
			  </worldbody>
			</mujoco>
			""";

		static int Main()
		{
			// NuGet wires runtimes/<rid>/native into the app's native probing paths automatically,
			// so a consumer of the package needs none of this. A ProjectReference does not, hence
			// the explicit resolver here.
			NativeLibrary.SetDllImportResolver(typeof(mjModel).Assembly, ResolveRuntimes);

			int failures = 0;

			Console.WriteLine($"header version : {MuJoCo.mjVERSION_HEADER}");
			Console.WriteLine($"library version: {MuJoCo.mj_version()} ({Marshal.PtrToStringUTF8((IntPtr)MuJoCo.mj_versionString())})");

			if (MuJoCo.mj_version() != MuJoCo.mjVERSION_HEADER)
			{
				Console.Error.WriteLine("FAIL: native library does not match the headers the bindings were generated from.");
				failures++;
			}

			var path = Path.Combine(Path.GetTempPath(), "mujoco_net_hello.xml");
			File.WriteAllText(path, Model);

			mjModel* m;
			var error = stackalloc byte[1024];

			try
			{
				m = MuJoCo.mj_loadXML(path, null, error, 1024);
			}
			finally
			{
				File.Delete(path);
			}

			if (m == null)
			{
				Console.Error.WriteLine($"FAIL: mj_loadXML: {Marshal.PtrToStringUTF8((IntPtr)error)}");
				return 1;
			}

			Console.WriteLine($"model          : nq={m->nq} nv={m->nv} nbody={m->nbody} ngeom={m->ngeom}");
			failures += Check("nq", m->nq, 7);
			failures += Check("nv", m->nv, 6);
			failures += Check("nbody", m->nbody, 2);

			// Layout probes. mjOption, mjVisual and mjStatistic are embedded by value in mjModel,
			// ahead of every pointer field, so a wrong offset anywhere in them shows up here rather
			// than as silent corruption later. mjVisual in particular is the struct whose six
			// anonymous nested aggregates the generator has to name itself.
			Console.WriteLine($"opt.timestep   : {m->opt.timestep}");
			Console.WriteLine($"opt.gravity    : {m->opt.gravity[0]} {m->opt.gravity[1]} {m->opt.gravity[2]}");
			Console.WriteLine($"vis.global.fovy: {m->vis.global.fovy}");
			Console.WriteLine($"vis.quality.offsamples: {m->vis.quality.offsamples}");
			Console.WriteLine($"stat.meaninertia: {m->stat.meaninertia}");

			failures += Check("opt.timestep", m->opt.timestep, 0.002);
			failures += Check("opt.gravity[2]", m->opt.gravity[2], -9.81);
			failures += Check("vis.global.fovy", m->vis.global.fovy, 45f);
			failures += Check("vis.quality.offsamples", m->vis.quality.offsamples, 4);

			if (!(m->stat.meaninertia > 0))
			{
				Console.Error.WriteLine($"FAIL: stat.meaninertia = {m->stat.meaninertia}, expected > 0");
				failures++;
			}

			// qpos0 is the first pointer field after the embedded structs: reading the ball's
			// initial height back validates every offset before it.
			failures += Check("qpos0[2]", m->qpos0[2], 1.0);

			mjData* d = MuJoCo.mj_makeData(m);
			if (d == null)
			{
				Console.Error.WriteLine("FAIL: mj_makeData returned null.");
				MuJoCo.mj_deleteModel(m);
				return 1;
			}

			Console.WriteLine();
			Console.WriteLine("simulating 1000 steps:");
			Console.WriteLine($"  t={d->time,-6:F3} z={d->qpos[2]:F6}");

			for (int i = 0; i < 1000; i++)
			{
				MuJoCo.mj_step(m, d);

				if ((i + 1) % 250 == 0)
				{
					Console.WriteLine($"  t={d->time,-6:F3} z={d->qpos[2]:F6}");
				}
			}

			failures += Check("time after 1000 steps", d->time, 2.0);

			// The ball starts at z=1 and settles on the plane at its radius, 0.1.
			if (!(d->qpos[2] > 0.09 && d->qpos[2] < 0.11))
			{
				Console.Error.WriteLine($"FAIL: ball rested at z={d->qpos[2]}, expected ~0.1");
				failures++;
			}

			MuJoCo.mj_deleteData(d);
			MuJoCo.mj_deleteModel(m);

			Console.WriteLine();
			Console.WriteLine(failures == 0 ? "OK: all checks passed." : $"{failures} check(s) FAILED.");
			return failures == 0 ? 0 : 1;
		}

		private static IntPtr ResolveRuntimes(string libraryName, System.Reflection.Assembly assembly, DllImportSearchPath? searchPath)
		{
			var root = Path.Combine(Path.GetDirectoryName(assembly.Location), "runtimes");

			foreach (var rid in CandidateRuntimeIdentifiers())
			{
				var folder = Path.Combine(root, rid, "native");
				if (!Directory.Exists(folder))
				{
					continue;
				}

				foreach (var file in Directory.GetFiles(folder, $"*{libraryName}*"))
				{
					if (NativeLibrary.TryLoad(file, out var handle))
					{
						return handle;
					}
				}
			}

			return NativeLibrary.Load(libraryName, assembly, searchPath);
		}

		/// <summary>
		/// RuntimeInformation.RuntimeIdentifier can be more specific than the folders that ship in
		/// the package (it reports "ubuntu.22.04-x64" where the package has "linux-x64"), and the
		/// macOS binary is a universal2 build filed under the architecture-less "osx" RID.
		/// </summary>
		private static System.Collections.Generic.IEnumerable<string> CandidateRuntimeIdentifiers()
		{
			yield return RuntimeInformation.RuntimeIdentifier;

			string os = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win"
				: RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx"
				: "linux";

			yield return $"{os}-{RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()}";
			yield return os;
		}

		private static int Check<T>(string name, T actual, T expected)
			where T : IEquatable<T>
		{
			bool ok = actual is double a && expected is double e
				? Math.Abs(a - e) < 1e-9
				: actual.Equals(expected);

			if (!ok)
			{
				Console.Error.WriteLine($"FAIL: {name} = {actual}, expected {expected}");
				return 1;
			}

			return 0;
		}
	}
}
