using System;
using System.Runtime.InteropServices;

namespace Evergine.Bindings.MuJoCo
{
	/// <summary>
	/// function type for log handler callback; must be thread-safe, must not call mju_error
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void mjfLogHandler(mjLogMessage* arg0);

	/// <summary>
	/// generic MuJoCo function
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void mjfGeneric(mjModel* m, mjData* d);

	/// <summary>
	/// contact filter: 1- discard, 0- collide
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfConFilt(mjModel* m, mjData* d, int geom1, int geom2);

	/// <summary>
	/// sensor simulation
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void mjfSensor(mjModel* m, mjData* d, int stage);

	/// <summary>
	/// timer
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate double mjfTime();

	/// <summary>
	/// actuator dynamics, gain, bias
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate double mjfAct(mjModel* m, mjData* d, int id);

	/// <summary>
	/// collision detection
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfCollision(mjModel* m, mjData* d, mjPreContact* con, int g1, int g2, double margin);

	/// <summary>
	/// callback for opening a resource, returns zero on failure.
	/// Note: If opening fails, the close callback will not be called. Therefore, the
	/// open callback is responsible for cleaning up any allocated memory before
	/// returning 0.
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfOpenResource(mjResource* resource);

	/// <summary>
	/// callback for reading a resource
	/// return number of bytes stored in buffer, return -1 if error
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfReadResource(mjResource* resource, void** buffer);

	/// <summary>
	/// callback for closing a resource (responsible for freeing any allocated memory)
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void mjfCloseResource(mjResource* resource);

	/// <summary>
	/// callback for mounting a resource (provider), returns zero on failure
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfMountResource(mjResource* resource);

	/// <summary>
	/// callback for unmounting a resource (provider), returns zero on failure
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfUnmountResource(mjResource* resource);

	/// <summary>
	/// callback for checking if the current resource was modified from the time
	/// specified by the timestamp
	/// returns 0 if the resource's timestamp matches the provided timestamp
	/// returns &gt; 0 if the resource is younger than the given timestamp
	/// returns
	/// &lt;
	/// 0 if the resource is older than the given timestamp
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfResourceModified(mjResource* resource, [MarshalAs(UnmanagedType.LPUTF8Str)] string timestamp);

	/// <summary>
	/// callback for writing bytes to a resource
	/// return number of bytes written, return -1 if error
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate long mjfWriteResource(mjResource* resource, void* buffer, long nbytes);

	/// <summary>
	/// function pointer types
	/// return an mjSpec representing the decoded resource.
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate mjSpec* mjfDecode(mjResource* resource, mjVFS* vfs);

	/// <summary>
	/// return true if the given resource can be decoded.
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfCanDecode(mjResource* resource);

	/// <summary>
	/// ---------------------------------- Encoder -------------------------------------------------------
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate long mjfEncode(mjSpec* s, mjModel* m, mjVFS* vfs, mjResource* resource);

	/// <summary>
	/// function pointer type for mj_loadAllPluginLibraries callback
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void mjfPluginLibraryLoadCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int first, int count);

	/// <summary>
	/// predicate function: set enable/disable based on item category
	/// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int mjfItemEnable(int category, void* data);
}
