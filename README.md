# MuJoCo.NET

This repository contains low-level bindings for [MuJoCo](https://github.com/google-deepmind/mujoco) used in [Evergine](https://evergine.com/).
This binding is generated from the MuJoCo release:
[https://github.com/google-deepmind/mujoco/releases/tag/3.11.0](https://github.com/google-deepmind/mujoco/releases/tag/3.11.0)

[![CI](https://github.com/EvergineTeam/MuJoCo.NET/actions/workflows/CI.yml/badge.svg)](https://github.com/EvergineTeam/MuJoCo.NET/actions/workflows/CI.yml)
[![CD](https://github.com/EvergineTeam/MuJoCo.NET/actions/workflows/CD.yml/badge.svg)](https://github.com/EvergineTeam/MuJoCo.NET/actions/workflows/CD.yml)
[![Nuget](https://img.shields.io/nuget/v/Evergine.Bindings.MuJoCo?logo=nuget)](https://www.nuget.org/packages/Evergine.Bindings.MuJoCo)

## Purpose

MuJoCo (*Multi-Joint dynamics with Contact*) is a general-purpose physics engine for robotics,
biomechanics, graphics and machine learning. It provides fast and accurate simulation of articulated
bodies in contact, along with analytical derivatives, inverse dynamics and a built-in visualizer.

These bindings expose the full MuJoCo C API to .NET so that Evergine — and any other .NET
application — can drive the engine directly, with no marshalling layer in between. See the
[upstream repository](https://github.com/google-deepmind/mujoco) and the
[official documentation](https://mujoco.readthedocs.io/) for what the engine itself can do.

## Features

- **Complete C API** — 536 entry points covering simulation (`mj_`), utilities (`mju_`),
  derivatives (`mjd_`), model editing (`mjs_`), abstract visualization (`mjv_`), OpenGL rendering
  (`mjr_`) and the built-in UI (`mjui_`)
- **Full data model** — 90 blittable structs including `mjModel`, `mjData`, `mjOption` and `mjVisual`,
  plus 76 enums and 68 constants
- **Names match the C API** — `mj_step`, `mjModel.qpos0`, `mjOBJ_BODY` read exactly as they do in the
  MuJoCo documentation, so upstream examples translate line by line
- **Zero-overhead interop** — raw pointers and `unsafe` structs throughout; no wrapper allocations
- **Generated, not hand-written** — regenerating for a new MuJoCo release is a single command

## Supported Platforms

- [x] Windows x64
- [ ] Windows ARM64 — no official MuJoCo build is published for this platform
- [x] Linux x64, ARM64
- [x] MacOS ARM64, x64 (single `universal2` binary under the `osx` RID)

## Usage

```csharp
using Evergine.Bindings.MuJoCo;

unsafe
{
    byte* error = stackalloc byte[1024];
    mjModel* m = MuJoCo.mj_loadXML("model.xml", null, error, 1024);
    mjData* d = MuJoCo.mj_makeData(m);

    for (int i = 0; i < 1000; i++)
    {
        MuJoCo.mj_step(m, d);
    }

    MuJoCo.mj_deleteData(d);
    MuJoCo.mj_deleteModel(m);
}
```

`Test/Program.cs` is a runnable version of the above that also validates the struct layout against
the native library.

### Demo

`LowLevelDemo/` drives MuJoCo from these bindings and renders the simulation live with the
[Evergine](https://evergine.com/) low-level graphics API — a DirectX 11 device presenting to a swap
chain, one draw per geom through a dynamic-offset constant buffer. 30 bodies (boxes, spheres and
capsules) drop in three waves while the camera orbits the pile; the simulation restarts every 10
seconds.

```bash
dotnet run --project LowLevelDemo/LowLevelDemo.csproj
```

[**mujoco-lowlevel-demo.mp4**](LowLevelDemo/media/mujoco-lowlevel-demo.mp4) is a recording of it.

### String parameters

`const char*` parameters are marshalled as UTF-8 (`UnmanagedType.LPUTF8Str`), which is what MuJoCo
expects. Caller-allocated output buffers are plain `byte*` and are never copied back implicitly —
read them with `Marshal.PtrToStringUTF8`.

### Known limitations

MuJoCo exports a number of global *variables* rather than functions: the callback hooks
(`mjcb_control`, `mjcb_passive`, `mjcb_contactfilter`, `mju_user_warning`, ...) and the string tables
(`mjDISABLESTRING`, `mjVISSTRING`, ...). `[DllImport]` cannot bind to exported data, so these are not
part of the generated surface. Reach them with `NativeLibrary.GetExport` if you need them.

## Building

```bash
dotnet build MuJoCoGen.sln
```

To regenerate the bindings after changing the headers:

```bash
dotnet run --project MuJoCoGen/MuJoCoGen.csproj
```

The generator parses `MuJoCoGen/Headers/mujoco_capi.h` with [CppAst](https://github.com/xoofx/CppAst.NET)
and writes `Evergine.Bindings.MuJoCo/Generated/`. That wrapper header exists because MuJoCo presents a
different API to C++ than to C — `mjspec.h` aliases `mjString`/`mjIntVec` to `std::string`/`std::vector`
under `__cplusplus` — and only the C view is marshallable.

To run the validation app:

```bash
dotnet run --project Test/Test.csproj
```

## Updating to a new MuJoCo version

1. Replace the headers in `MuJoCoGen/Headers/mujoco/` with those from
   `https://github.com/google-deepmind/mujoco/tree/<version>/include/mujoco`.
2. Replace the native binaries under `Evergine.Bindings.MuJoCo/runtimes/`:

   | RID | Source | File to place |
   |---|---|---|
   | `win-x64` | `mujoco-<version>-windows-x86_64.zip` | `bin/mujoco.dll` → `mujoco.dll` |
   | `linux-x64` | `mujoco-<version>-linux-x86_64.tar.gz` | `lib/libmujoco.so.<version>` → `libmujoco.so` |
   | `linux-arm64` | `mujoco-<version>-linux-aarch64.tar.gz` | `lib/libmujoco.so.<version>` → `libmujoco.so` |
   | `osx` | `mujoco-<version>-cp313-cp313-macosx_11_0_arm64.whl` (PyPI) | `mujoco/libmujoco.<version>.dylib` → `libmujoco.dylib` |

   The archives release symlinked `.so` files — copy the real file and drop the version suffix.
   For macOS the official release only ships a `.dmg`, which needs `hdiutil`; the PyPI wheel contains
   the same `universal2` binary (x86_64 + arm64) and can be unzipped anywhere, so it covers both
   `osx-x64` and `osx-arm64` from the architecture-less `osx` RID.
3. Run the generator and `dotnet run --project Test/Test.csproj`. The test asserts that
   `mj_version()` matches `mjVERSION_HEADER`, so a mismatched pair fails immediately.

## Related Evergine Bindings

- [WebGPU.NET](https://github.com/EvergineTeam/WebGPU.NET) — Bindings for WebGPU
- [Meshoptimizer.NET](https://github.com/EvergineTeam/Meshoptimizer.NET) — Bindings for meshoptimizer
- [RenderDoc.NET](https://github.com/EvergineTeam/RenderDoc.NET) — Bindings for RenderDoc
- [XAtlas.NET](https://github.com/EvergineTeam/XAtlas.NET) — Bindings for xatlas
