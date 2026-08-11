using CppAst;
using System;
using System.IO;
using System.Linq;

namespace MuJoCoGen
{
	class Program
	{
		static int Main(string[] args)
		{
			var headerFile = Path.Combine(AppContext.BaseDirectory, "Headers", "mujoco_capi.h");

			if (!File.Exists(headerFile))
			{
				Console.Error.WriteLine($"Header not found: {headerFile}");
				return 1;
			}

			var options = new CppParserOptions
			{
				ParseMacros = true,

			};

			// mujoco.h includes its siblings as <mujoco/mjdata.h>, so the folder holding the
			// "mujoco" directory is what has to be on the include path.
			options.IncludeFolders.Add(Path.Combine(AppContext.BaseDirectory, "Headers"));

			// Stand-ins for <stdlib.h> and <math.h>. libclang ships freestanding headers but no
			// libc, so without these the parse fails on a bare Linux runner and succeeds on
			// Windows. See Headers/libc-stubs/stdlib.h.
			options.IncludeFolders.Add(Path.Combine(AppContext.BaseDirectory, "Headers", "libc-stubs"));

			// mjexport.h resolves MJAPI to __declspec(dllimport)/visibility attributes unless the
			// static build is selected; MJ_STATIC keeps those out of the AST.
			options.Defines.Add("MJ_STATIC");

			var compilation = CppParser.ParseFile(headerFile, options);

			if (compilation.HasErrors)
			{
				foreach (var message in compilation.Diagnostics.Messages)
				{
					if (message.Type == CppLogMessageType.Error)
					{
						Console.Error.WriteLine(message);
					}
				}

				return 1;
			}

			var outputPath = ResolveOutputPath();
			if (outputPath == null)
			{
				Console.Error.WriteLine("Could not locate the Evergine.Bindings.MuJoCo project folder.");
				return 1;
			}

			Directory.CreateDirectory(outputPath);

			CsCodeGenerator.Instance.Generate(compilation, outputPath);

			Console.WriteLine($"Bindings written to {outputPath}");
			return 0;
		}

		/// <summary>
		/// Walks up from the build output until the sibling binding project is found, instead of
		/// hard-coding a fixed number of parent hops, which breaks whenever the RuntimeIdentifier
		/// or the publish layout changes the output depth.
		/// </summary>
		private static string ResolveOutputPath()
		{
			var current = new DirectoryInfo(AppContext.BaseDirectory);

			while (current != null)
			{
				var candidate = Path.Combine(current.FullName, "Evergine.Bindings.MuJoCo");
				if (Directory.Exists(candidate))
				{
					return Path.Combine(candidate, "Generated");
				}

				current = current.Parent;
			}

			return null;
		}
	}
}
