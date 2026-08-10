using Evergine.Bindings.MuJoCo;
using Evergine.Common.Graphics;
using Evergine.Common.Graphics.VertexFormats;
using Evergine.DirectX11;
using Evergine.Mathematics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Buffer = Evergine.Common.Graphics.Buffer;
using Color = Evergine.Common.Graphics.Color;
using Rectangle = Evergine.Mathematics.Rectangle;

namespace LowLevelDemo
{
	/// <summary>
	/// Headless demo: MuJoCo simulates bodies dropped in three waves; the Evergine low-level
	/// graphics API renders every geom into an offscreen framebuffer; frames are read back and
	/// piped to ffmpeg as an H.264 MP4.
	/// Rendering follows the engine's VisualTests.LowLevel patterns (DrawCubeTest,
	/// RenderToTextureTest, MultithreadingTest) and the Evergine.Graphics.Tests readback pattern.
	/// </summary>
	unsafe class Program
	{
		private const uint Width = 1280;
		private const uint Height = 720;
		private const uint CbSlotSize = 256; // per-geom constant slot, 256-byte aligned
		private const int Fps = 60;
		private const double DurationSeconds = 8.0;

		/// <summary>
		/// Release time per wave. Waves 2 and 3 wait frozen at z ~6, well above the camera frustum,
		/// so they drop into an already-formed pile instead of arriving all at once. Pure free fall
		/// cannot stagger arrivals this far apart: even 8 m only buys 1.3 s.
		/// </summary>
		private static readonly double[] WaveReleaseTime = { 0.0, 2.0, 4.2 };
		private const int BodiesPerWave = 10;

		private const string Scene = """
			<mujoco model="waves">
			  <option timestep="0.002" iterations="50"/>
			  <worldbody>
			    <light pos="0 0 10"/>
			    <!-- generous floor: strays bouncing off a smaller plane fall into the void and read
			         as a rendering glitch in the recording -->
			    <geom name="floor" type="plane" size="7 7 0.1" rgba="0.72 0.70 0.66 1"/>

			    <!-- wave 1 -->
			    <body pos=" 0.00  0.00 1.2"><freejoint/><geom type="box" size="0.22 0.22 0.22" rgba="0.90 0.30 0.24 1" euler="10 25 0"/></body>
			    <body pos=" 0.42  0.18 1.7"><freejoint/><geom type="box" size="0.18 0.18 0.18" rgba="0.16 0.50 0.73 1" euler="0 30 40"/></body>
			    <body pos="-0.35  0.30 2.1"><freejoint/><geom type="box" size="0.15 0.25 0.12" rgba="0.95 0.61 0.07 1" euler="20 0 65"/></body>
			    <body pos=" 0.12 -0.40 2.5"><freejoint/><geom type="box" size="0.20 0.12 0.16" rgba="0.10 0.74 0.61 1" euler="45 15 10"/></body>
			    <body pos="-0.50 -0.12 1.4"><freejoint/><geom type="box" size="0.14 0.14 0.28" rgba="0.61 0.35 0.71 1" euler="5 50 20"/></body>
			    <body pos=" 0.60 -0.32 1.9"><freejoint/><geom type="sphere" size="0.18" rgba="0.91 0.30 0.55 1"/></body>
			    <body pos="-0.18  0.58 2.4"><freejoint/><geom type="sphere" size="0.14" rgba="0.20 0.60 0.86 1"/></body>
			    <body pos=" 0.28  0.48 1.5"><freejoint/><geom type="sphere" size="0.21" rgba="0.95 0.77 0.06 1"/></body>
			    <body pos=" 0.06  0.22 2.8"><freejoint/><geom type="capsule" size="0.10 0.25" rgba="0.90 0.49 0.13 1" euler="80 0 30"/></body>
			    <body pos="-0.28 -0.50 2.2"><freejoint/><geom type="capsule" size="0.08 0.20" rgba="0.75 0.22 0.17 1" euler="15 70 0"/></body>

			    <!-- wave 2 (held above the frustum until t=2.0) -->
			    <body pos=" 0.30  0.35 5.6"><freejoint/><geom type="box" size="0.19 0.19 0.19" rgba="0.20 0.29 0.37 1" euler="30 10 55"/></body>
			    <body pos="-0.40  0.10 5.9"><freejoint/><geom type="box" size="0.13 0.22 0.17" rgba="0.85 0.37 0.008 1" euler="0 45 20"/></body>
			    <body pos=" 0.15 -0.45 6.2"><freejoint/><geom type="box" size="0.24 0.14 0.14" rgba="0.44 0.62 0.81 1" euler="60 0 35"/></body>
			    <body pos="-0.10  0.50 5.7"><freejoint/><geom type="box" size="0.16 0.16 0.24" rgba="0.99 0.85 0.21 1" euler="15 35 5"/></body>
			    <body pos=" 0.52 -0.05 6.4"><freejoint/><geom type="sphere" size="0.16" rgba="0.56 0.27 0.68 1"/></body>
			    <body pos="-0.55 -0.30 6.0"><freejoint/><geom type="sphere" size="0.20" rgba="0.11 0.63 0.51 1"/></body>
			    <body pos=" 0.05  0.05 6.6"><freejoint/><geom type="sphere" size="0.13" rgba="0.94 0.40 0.40 1"/></body>
			    <body pos=" 0.38  0.52 5.8"><freejoint/><geom type="capsule" size="0.09 0.22" rgba="0.25 0.55 0.79 1" euler="70 20 0"/></body>
			    <body pos="-0.22 -0.15 6.3"><freejoint/><geom type="capsule" size="0.11 0.19" rgba="0.90 0.62 0.10 1" euler="10 80 40"/></body>
			    <body pos=" 0.60  0.25 6.1"><freejoint/><geom type="capsule" size="0.07 0.26" rgba="0.36 0.72 0.36 1" euler="45 45 0"/></body>

			    <!-- wave 3 (held above the frustum until t=4.2) -->
			    <body pos="-0.05  0.40 5.6"><freejoint/><geom type="box" size="0.21 0.15 0.15" rgba="0.72 0.11 0.28 1" euler="25 55 10"/></body>
			    <body pos=" 0.45 -0.38 5.9"><freejoint/><geom type="box" size="0.17 0.17 0.21" rgba="0.13 0.44 0.62 1" euler="0 15 70"/></body>
			    <body pos="-0.48  0.22 6.3"><freejoint/><geom type="box" size="0.12 0.20 0.18" rgba="0.96 0.71 0.13 1" euler="50 30 25"/></body>
			    <body pos=" 0.20  0.12 6.6"><freejoint/><geom type="box" size="0.15 0.15 0.15" rgba="0.31 0.66 0.44 1" euler="35 0 45"/></body>
			    <body pos="-0.30 -0.42 5.7"><freejoint/><geom type="sphere" size="0.19" rgba="0.86 0.29 0.62 1"/></body>
			    <body pos=" 0.58  0.08 6.1"><freejoint/><geom type="sphere" size="0.15" rgba="0.29 0.56 0.90 1"/></body>
			    <body pos="-0.12 -0.05 6.5"><freejoint/><geom type="sphere" size="0.22" rgba="0.98 0.80 0.30 1"/></body>
			    <body pos=" 0.10  0.55 6.0"><freejoint/><geom type="capsule" size="0.10 0.20" rgba="0.55 0.34 0.76 1" euler="65 10 20"/></body>
			    <body pos="-0.58  0.00 6.4"><freejoint/><geom type="capsule" size="0.08 0.24" rgba="0.87 0.45 0.20 1" euler="20 60 50"/></body>
			    <body pos=" 0.32 -0.20 5.8"><freejoint/><geom type="capsule" size="0.12 0.17" rgba="0.16 0.70 0.66 1" euler="80 30 15"/></body>
			  </worldbody>
			</mujoco>
			""";

		[StructLayout(LayoutKind.Sequential)]
		private struct PerObject
		{
			public Matrix4x4 WorldViewProj;
			public Matrix4x4 World;
			public Vector4 Color;
		}

		private class Mesh
		{
			public Buffer VertexBuffer;
			public Buffer IndexBuffer;
			public uint IndexCount;
		}

		private static GraphicsContext graphics;
		private static readonly Dictionary<string, Mesh> meshes = new();

		static int Main(string[] args)
		{
			// ProjectReference scenario: wire runtimes/<rid>/native manually (NuGet consumers get
			// this for free).
			NativeLibrary.SetDllImportResolver(typeof(mjModel).Assembly, (name, assembly, searchPath) =>
			{
				var folder = Path.Combine(Path.GetDirectoryName(assembly.Location), "runtimes",
					$"win-{RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()}", "native");
				if (Directory.Exists(folder))
				{
					foreach (var file in Directory.GetFiles(folder, $"*{name}*"))
					{
						if (NativeLibrary.TryLoad(file, out var handle))
						{
							return handle;
						}
					}
				}

				return NativeLibrary.Load(name, assembly, searchPath);
			});

			bool pngMode = Array.IndexOf(args, "--png") >= 0;
			var positional = Array.FindAll(args, a => !a.StartsWith("--"));
			var outputPath = positional.Length > 0
				? positional[0]
				: Path.Combine(FindRepoRoot(), "LowLevelDemo", "media", "mujoco-lowlevel-demo.mp4");

			// ---- MuJoCo ----------------------------------------------------------------------
			var xmlPath = Path.Combine(Path.GetTempPath(), "mujoco_lowleveldemo.xml");
			File.WriteAllText(xmlPath, Scene);
			var error = stackalloc byte[1024];
			mjModel* m = MuJoCo.mj_loadXML(xmlPath, null, error, 1024);
			File.Delete(xmlPath);

			if (m == null)
			{
				Console.Error.WriteLine($"mj_loadXML: {Marshal.PtrToStringUTF8((IntPtr)error)}");
				return 1;
			}

			mjData* d = MuJoCo.mj_makeData(m);
			Console.WriteLine($"MuJoCo {Marshal.PtrToStringUTF8((IntPtr)MuJoCo.mj_versionString())}: ngeom={m->ngeom} nbody={m->nbody}");

			// ---- Evergine low-level, headless (GraphicsTests pattern) --------------------------
			graphics = new DX11GraphicsContext();
			graphics.CreateDevice(new ValidationLayer(ValidationLayer.NotifyMethod.Trace));

			// Offscreen framebuffer (RenderToTextureTest pattern).
			var colorDescription = new TextureDescription()
			{
				Format = PixelFormat.R8G8B8A8_UNorm,
				Width = Width,
				Height = Height,
				Depth = 1,
				ArraySize = 1,
				Flags = TextureFlags.RenderTarget | TextureFlags.ShaderResource,
				CpuAccess = ResourceCpuAccess.None,
				MipLevels = 1,
				Type = TextureType.Texture2D,
				Usage = ResourceUsage.Default,
				SampleCount = TextureSampleCount.None,
			};
			var colorTarget = graphics.Factory.CreateTexture(ref colorDescription);

			var depthDescription = colorDescription;
			depthDescription.Format = PixelFormat.D24_UNorm_S8_UInt;
			depthDescription.Flags = TextureFlags.DepthStencil;
			var depthTarget = graphics.Factory.CreateTexture(ref depthDescription);

			var frameBuffer = graphics.Factory.CreateFrameBuffer(
				new FrameBufferAttachment(depthTarget, 0, 1),
				new[] { new FrameBufferAttachment(colorTarget, 0, 1) });

			// Shaders, compiled at runtime (TestHelpers.ReadAndCompileShader pattern).
			var vsBytes = graphics.ShaderCompile(Shaders.Hlsl, "VS", ShaderStages.Vertex).ByteCode;
			var psBytes = graphics.ShaderCompile(Shaders.Hlsl, "PS", ShaderStages.Pixel).ByteCode;
			var vsDescription = new ShaderDescription(ShaderStages.Vertex, "VS", vsBytes);
			var psDescription = new ShaderDescription(ShaderStages.Pixel, "PS", psBytes);
			var vertexShader = graphics.Factory.CreateShader(ref vsDescription);
			var pixelShader = graphics.Factory.CreateShader(ref psDescription);

			// One big dynamic-offset constant buffer, one 256-byte slot per geom
			// (MultithreadingTest pattern).
			int ngeom = (int)m->ngeom;
			var cbDescription = new BufferDescription(
				CbSlotSize * (uint)ngeom, BufferFlags.ConstantBuffer, ResourceUsage.Default);
			var constantBuffer = graphics.Factory.CreateBuffer(ref cbDescription);

			var layoutDescription = new ResourceLayoutDescription(
				new LayoutElementDescription(0, ResourceType.ConstantBuffer,
					ShaderStages.Vertex | ShaderStages.Pixel, allowDynamicOffset: true, size: CbSlotSize));
			var resourceLayout = graphics.Factory.CreateResourceLayout(ref layoutDescription);

			var resourceSetDescription = new ResourceSetDescription(resourceLayout, constantBuffer);
			var resourceSet = graphics.Factory.CreateResourceSet(ref resourceSetDescription);

			var pipelineDescription = new GraphicsPipelineDescription()
			{
				PrimitiveTopology = PrimitiveTopology.TriangleList,
				InputLayouts = new InputLayouts().Add(VertexPositionNormalTangentTexture.VertexFormat),
				ResourceLayouts = new[] { resourceLayout },
				Shaders = new GraphicsShaderStateDescription()
				{
					VertexShader = vertexShader,
					PixelShader = pixelShader,
				},
				RenderStates = new RenderStateDescription()
				{
					RasterizerState = RasterizerStates.CullBack,
					BlendState = BlendStates.Opaque,
					DepthStencilState = DepthStencilStates.ReadWrite,
				},
				Outputs = frameBuffer.OutputDescription,
			};
			var pipeline = graphics.Factory.CreateGraphicsPipeline(ref pipelineDescription);
			var commandQueue = graphics.Factory.CreateCommandQueue();

			var proj = Matrix4x4.CreatePerspectiveFieldOfView(
				MathHelper.PiOver4, (float)Width / Height, 0.1f, 100f, reverseDepthBuffer: true);

			var viewports = new Viewport[] { new Viewport(0, 0, Width, Height) };
			var scissors = new Rectangle[] { new Rectangle(0, 0, (int)Width, (int)Height) };

			var cbData = new byte[CbSlotSize * ngeom];
			int totalFrames = (int)(DurationSeconds * Fps);

			// ---- Record -----------------------------------------------------------------------
			Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

			using var grabber = new FrameGrabber(colorTarget);
			FfmpegEncoder encoder = null;

			if (!pngMode)
			{
				encoder = FfmpegEncoder.Start(outputPath, Width, Height, Fps);
				Console.WriteLine($"recording {totalFrames} frames -> {outputPath}");
			}

			var stopwatch = Stopwatch.StartNew();

			for (int frame = 0; frame < totalFrames; frame++)
			{
				double targetTime = frame / (double)Fps;
				while (d->time < targetTime)
				{
					HoldUnreleasedWaves(m, d);
					MuJoCo.mj_step(m, d);
				}

				var viewProj = Matrix4x4.Multiply(GetOrbitView(frame, totalFrames), proj);
				FillConstants(m, d, viewProj, cbData);
				DrawFrame(commandQueue, frameBuffer, pipeline, resourceSet, constantBuffer, cbData, viewports, scissors, m);

				if (pngMode)
				{
					if (frame % (totalFrames / 3) == 0)
					{
						var png = Path.ChangeExtension(outputPath, null) + $"_{d->time:F1}s.png";
						SavePng(grabber.Grab(), png);
						Console.WriteLine($"t={d->time:F2}s -> {png}");
					}
				}
				else
				{
					encoder.WriteFrame(grabber.Grab());

					if ((frame + 1) % 60 == 0)
					{
						Console.WriteLine($"  {frame + 1}/{totalFrames} frames (t={d->time:F2}s)");
					}
				}
			}

			encoder?.Finish();
			stopwatch.Stop();

			MuJoCo.mj_deleteData(d);
			MuJoCo.mj_deleteModel(m);
			graphics.Dispose();

			if (!pngMode)
			{
				var size = new FileInfo(outputPath).Length / (1024.0 * 1024.0);
				Console.WriteLine($"done in {stopwatch.Elapsed.TotalSeconds:F1}s -> {outputPath} ({size:F1} MB)");
			}

			return 0;
		}

		/// <summary>
		/// Pins every body of a wave that has not been released yet to its initial pose, so the
		/// wave stays parked above the camera frustum until its release time.
		/// </summary>
		private static void HoldUnreleasedWaves(mjModel* m, mjData* d)
		{
			for (int wave = 0; wave < WaveReleaseTime.Length; wave++)
			{
				if (d->time >= WaveReleaseTime[wave])
				{
					continue;
				}

				int firstBody = 1 + (wave * BodiesPerWave); // body 0 is the world
				for (int b = firstBody; b < firstBody + BodiesPerWave && b < m->nbody; b++)
				{
					int joint = m->body_jntadr[b];
					if (joint < 0)
					{
						continue;
					}

					int qposAdr = m->jnt_qposadr[joint];
					int dofAdr = m->jnt_dofadr[joint];

					for (int k = 0; k < 7; k++)
					{
						d->qpos[qposAdr + k] = m->qpos0[qposAdr + k];
					}

					for (int k = 0; k < 6; k++)
					{
						d->qvel[dofAdr + k] = 0;
					}
				}
			}
		}

		/// <summary>
		/// Camera orbiting the pile: a 140 degree azimuth sweep while slowly closing in. The scene
		/// stays in MuJoCo's Z-up coordinates, so Z is also the camera up vector.
		/// </summary>
		private static Matrix4x4 GetOrbitView(int frame, int totalFrames)
		{
			float t = totalFrames > 1 ? frame / (float)(totalFrames - 1) : 0f;

			float azimuth = MathHelper.ToRadians(-125f + (140f * t));
			float radius = 4.0f - (1.0f * t);
			float height = 1.9f - (0.5f * t);

			var eye = new Vector3(
				radius * MathF.Cos(azimuth),
				radius * MathF.Sin(azimuth),
				height);

			return Matrix4x4.CreateLookAt(eye, new Vector3(0, 0, 0.5f), Vector3.UnitZ);
		}

		/// <summary>
		/// Writes one PerObject slot per geom: world = scale · rotation(geom_xmat) · translation(geom_xpos).
		/// </summary>
		private static void FillConstants(mjModel* m, mjData* d, Matrix4x4 viewProj, byte[] cbData)
		{
			fixed (byte* basePtr = cbData)
			{
				for (int g = 0; g < m->ngeom; g++)
				{
					var world = BuildWorldMatrix(m, d, g);

					var slot = (PerObject*)(basePtr + (g * CbSlotSize));
					slot->WorldViewProj = Matrix4x4.Multiply(world, viewProj);
					slot->World = world;
					slot->Color = new Vector4(
						m->geom_rgba[(g * 4) + 0],
						m->geom_rgba[(g * 4) + 1],
						m->geom_rgba[(g * 4) + 2],
						m->geom_rgba[(g * 4) + 3]);
				}
			}
		}

		private static Matrix4x4 BuildWorldMatrix(mjModel* m, mjData* d, int g)
		{
			int type = m->geom_type[g];
			double* size = m->geom_size + (g * 3);
			double* xpos = d->geom_xpos + (g * 3);
			double* xmat = d->geom_xmat + (g * 9);

			// MuJoCo's xmat is a row-major rotation for column vectors; Evergine uses row vectors,
			// so the transpose goes into M11..M33.
			var rotation = new Matrix4x4(
				(float)xmat[0], (float)xmat[3], (float)xmat[6], 0,
				(float)xmat[1], (float)xmat[4], (float)xmat[7], 0,
				(float)xmat[2], (float)xmat[5], (float)xmat[8], 0,
				0, 0, 0, 1);

			Matrix4x4 local;
			switch (type)
			{
				case (int)mjtGeom.mjGEOM_PLANE:
					// Rendered as a thin slab whose top face lies on the plane surface.
					float halfX = size[0] > 0 ? (float)size[0] : 10f;
					float halfY = size[1] > 0 ? (float)size[1] : 10f;
					local = Matrix4x4.CreateScale(halfX * 2, halfY * 2, 0.05f)
						* Matrix4x4.CreateTranslation(0, 0, -0.025f);
					break;

				case (int)mjtGeom.mjGEOM_SPHERE:
					local = Matrix4x4.CreateScale((float)size[0] * 2);
					break;

				case (int)mjtGeom.mjGEOM_CAPSULE:
					// The capsule mesh is generated with its exact dimensions, axis along local Y;
					// MuJoCo capsules point along local Z.
					local = Matrix4x4.CreateRotationX(MathHelper.PiOver2);
					break;

				case (int)mjtGeom.mjGEOM_BOX:
				default:
					local = Matrix4x4.CreateScale((float)size[0] * 2, (float)size[1] * 2, (float)size[2] * 2);
					break;
			}

			var translation = Matrix4x4.CreateTranslation((float)xpos[0], (float)xpos[1], (float)xpos[2]);
			return local * rotation * translation;
		}

		private static Mesh GetMesh(mjModel* m, int g)
		{
			int type = m->geom_type[g];
			double* size = m->geom_size + (g * 3);

			string key;
			List<VertexPositionNormalTangentTexture> vertices;
			List<ushort> indices;

			switch (type)
			{
				case (int)mjtGeom.mjGEOM_SPHERE:
					key = "sphere";
					if (meshes.TryGetValue(key, out var sphere))
					{
						return sphere;
					}

					Primitives.Sphere(1f, 24, out vertices, out indices);
					break;

				case (int)mjtGeom.mjGEOM_CAPSULE:
					// Capsules cannot be non-uniformly scaled without distorting the caps, so each
					// (radius, half-length) pair gets its own exact mesh.
					float radius = (float)size[0];
					float halfLength = (float)size[1];
					key = $"capsule_{radius}_{halfLength}";
					if (meshes.TryGetValue(key, out var capsule))
					{
						return capsule;
					}

					Primitives.Capsule((halfLength + radius) * 2, radius, 16, out vertices, out indices);
					break;

				default: // plane and box both render a unit cube scaled per instance
					key = "cube";
					if (meshes.TryGetValue(key, out var cube))
					{
						return cube;
					}

					Primitives.Cube(1f, out vertices, out indices);
					break;
			}

			var vertexArray = vertices.ToArray();
			var indexArray = indices.ToArray();

			var vbDescription = new BufferDescription(
				(uint)(Marshal.SizeOf<VertexPositionNormalTangentTexture>() * vertexArray.Length),
				BufferFlags.VertexBuffer, ResourceUsage.Immutable);
			var ibDescription = new BufferDescription(
				sizeof(ushort) * (uint)indexArray.Length,
				BufferFlags.IndexBuffer, ResourceUsage.Immutable);

			var mesh = new Mesh()
			{
				VertexBuffer = graphics.Factory.CreateBuffer(vertexArray, ref vbDescription),
				IndexBuffer = graphics.Factory.CreateBuffer(indexArray, ref ibDescription),
				IndexCount = (uint)indexArray.Length,
			};

			meshes[key] = mesh;
			return mesh;
		}

		private static void DrawFrame(
			CommandQueue commandQueue,
			FrameBuffer frameBuffer,
			GraphicsPipelineState pipeline,
			ResourceSet resourceSet,
			Buffer constantBuffer,
			byte[] cbData,
			Viewport[] viewports,
			Rectangle[] scissors,
			mjModel* m)
		{
			var commandBuffer = commandQueue.CommandBuffer();
			commandBuffer.Begin();

			fixed (byte* cbPtr = cbData)
			{
				commandBuffer.UpdateBufferData(constantBuffer, (IntPtr)cbPtr, (uint)cbData.Length);
			}

			commandBuffer.SetViewports(viewports);
			commandBuffer.SetScissorRectangles(scissors);

			var renderPassDescription = new RenderPassDescription(
				frameBuffer, new ClearValue(ClearFlags.All, new Color(158, 190, 222)));
			commandBuffer.BeginRenderPass(ref renderPassDescription);
			commandBuffer.SetGraphicsPipelineState(pipeline);

			var offsets = new uint[1];
			for (int g = 0; g < m->ngeom; g++)
			{
				var mesh = GetMesh(m, g);
				offsets[0] = (uint)g * CbSlotSize;
				commandBuffer.SetResourceSet(resourceSet, 0, offsets);
				commandBuffer.SetVertexBuffers(new[] { mesh.VertexBuffer });
				commandBuffer.SetIndexBuffer(mesh.IndexBuffer);
				commandBuffer.DrawIndexed(mesh.IndexCount);
			}

			commandBuffer.EndRenderPass();
			commandBuffer.End();
			commandBuffer.Commit();

			commandQueue.Submit();
			commandQueue.WaitIdle();
		}

		private static void SavePng(byte[] pixels, string path)
		{
			using var image = SixLabors.ImageSharp.Image.LoadPixelData<Rgba32>(pixels, (int)Width, (int)Height);
			image.SaveAsPng(path);
		}

		private static string FindRepoRoot()
		{
			var current = new DirectoryInfo(AppContext.BaseDirectory);
			while (current != null)
			{
				if (File.Exists(Path.Combine(current.FullName, "MuJoCoGen.sln")))
				{
					return current.FullName;
				}

				current = current.Parent;
			}

			return AppContext.BaseDirectory;
		}

		/// <summary>
		/// GPU -> CPU frame readback. The staging texture, the command queue and the pixel buffer
		/// are created once and reused: allocating them per frame is fine for a screenshot but
		/// ruinous across hundreds of frames.
		/// Pattern from Evergine.Graphics.Tests\TextureTests.cs and Evergine.Assets\SnapShoter.cs.
		/// </summary>
		private sealed class FrameGrabber : IDisposable
		{
			private readonly Texture source;
			private readonly Texture staging;
			private readonly CommandQueue queue;
			private readonly byte[] pixels;
			private readonly int width;
			private readonly int height;

			public FrameGrabber(Texture source)
			{
				this.source = source;
				this.width = (int)source.Description.Width;
				this.height = (int)source.Description.Height;
				this.pixels = new byte[this.width * this.height * 4];

				var stagingDescription = source.Description;
				stagingDescription.Flags = TextureFlags.None;
				stagingDescription.CpuAccess = ResourceCpuAccess.Read;
				stagingDescription.Usage = ResourceUsage.Staging;
				this.staging = graphics.Factory.CreateTexture(ref stagingDescription);

				this.queue = graphics.Factory.CreateCommandQueue();
			}

			public byte[] Grab()
			{
				var command = this.queue.CommandBuffer();
				command.Begin();
				command.CopyTextureDataTo(this.source, this.staging);
				command.End();
				command.Commit();
				this.queue.Submit();
				this.queue.WaitIdle();

				var mapped = graphics.MapMemory(this.staging, MapMode.Read);
				try
				{
					int rowBytes = this.width * 4;
					for (int y = 0; y < this.height; y++)
					{
						new Span<byte>((byte*)mapped.Data + (y * mapped.RowPitch), rowBytes)
							.CopyTo(this.pixels.AsSpan(y * rowBytes, rowBytes));
					}
				}
				finally
				{
					graphics.UnmapMemory(this.staging);
				}

				return this.pixels;
			}

			public void Dispose() => this.staging?.Dispose();
		}

		/// <summary>
		/// Pipes raw RGBA frames into ffmpeg's stdin and lets it mux an H.264 MP4.
		/// </summary>
		private sealed class FfmpegEncoder
		{
			private readonly Process process;
			private readonly Stream input;
			private readonly Queue<string> stderrTail = new();

			private FfmpegEncoder(Process process)
			{
				this.process = process;
				this.input = process.StandardInput.BaseStream;
			}

			public static FfmpegEncoder Start(string outputPath, uint width, uint height, int fps)
			{
				var arguments =
					$"-y -f rawvideo -pixel_format rgba -video_size {width}x{height} -framerate {fps} -i - " +
					$"-c:v libx264 -preset medium -crf 18 -pix_fmt yuv420p -movflags +faststart \"{outputPath}\"";

				foreach (var exe in CandidateExecutables())
				{
					var startInfo = new ProcessStartInfo(exe, arguments)
					{
						RedirectStandardInput = true,
						RedirectStandardError = true,
						UseShellExecute = false,
						CreateNoWindow = true,
					};

					Process process;
					try
					{
						process = Process.Start(startInfo);
					}
					catch (Exception)
					{
						continue;
					}

					var encoder = new FfmpegEncoder(process);

					// ffmpeg is chatty on stderr; leaving that pipe unread deadlocks it once the
					// buffer fills, which with hundreds of frames it certainly would.
					process.ErrorDataReceived += (_, e) =>
					{
						if (e.Data == null)
						{
							return;
						}

						lock (encoder.stderrTail)
						{
							encoder.stderrTail.Enqueue(e.Data);
							while (encoder.stderrTail.Count > 20)
							{
								encoder.stderrTail.Dequeue();
							}
						}
					};
					process.BeginErrorReadLine();

					return encoder;
				}

				throw new InvalidOperationException(
					"ffmpeg was not found on PATH nor at the known winget install location. " +
					"Install it (winget install Gyan.FFmpeg) or run with --png.");
			}

			private static IEnumerable<string> CandidateExecutables()
			{
				yield return "ffmpeg";

				yield return Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
					"Microsoft", "WinGet", "Packages",
					"Gyan.FFmpeg_Microsoft.Winget.Source_8wekyb3d8bbwe",
					"ffmpeg-8.0.1-full_build", "bin", "ffmpeg.exe");
			}

			public void WriteFrame(byte[] rgba) => this.input.Write(rgba, 0, rgba.Length);

			public void Finish()
			{
				this.input.Flush();
				this.input.Close();
				this.process.WaitForExit();

				if (this.process.ExitCode != 0)
				{
					string tail;
					lock (this.stderrTail)
					{
						tail = string.Join(Environment.NewLine, this.stderrTail);
					}

					throw new InvalidOperationException(
						$"ffmpeg exited with code {this.process.ExitCode}:{Environment.NewLine}{tail}");
				}
			}
		}
	}
}
