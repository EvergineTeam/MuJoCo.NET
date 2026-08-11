using System;
using System.Runtime.InteropServices;

namespace Evergine.Bindings.MuJoCo
{
	public static unsafe partial class MuJoCo
	{
		/// <summary>
		/// Initialize an empty VFS, mj_deleteVFS must be called to deallocate the VFS.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_defaultVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_defaultVFS(mjVFS* vfs);

		/// <summary>
		/// Mount a ResourceProvider to handle file operations under the given path; return 0: success,
		/// 2: repeated name, -1: invalid resource provider.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_mountVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_mountVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string filepath, mjpResourceProvider* provider);

		/// <summary>
		/// Unmount a previously mounted ResourceProvider; return 0: success, -1: not found in VFS.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_unmountVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_unmountVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Add file to VFS; return 0: success, 2: repeated name, -1: failed to load.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_addFileVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_addFileVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string directory, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Add file to VFS from buffer; return 0: success, 2: repeated name, -1: failed to load.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_addBufferVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_addBufferVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, void* buffer, int nbuffer);

		/// <summary>
		/// Delete file from VFS; return 0: success, -1: not found in VFS.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_deleteFileVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_deleteFileVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Check if buffer exists in VFS; return 1: exists, 0: not found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_containsBufferVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_containsBufferVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Check if file exists in VFS; return 1: exists, 0: not found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_containsFileVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_containsFileVFS(mjVFS* vfs, [MarshalAs(UnmanagedType.LPUTF8Str)] string directory, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Delete all files from VFS and deallocates VFS internal memory.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_deleteVFS", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_deleteVFS(mjVFS* vfs);

		/// <summary>
		/// Get the current size of the asset cache in bytes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getCacheSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern nuint mj_getCacheSize(mjCache* cache);

		/// <summary>
		/// Get the capacity of the asset cache in bytes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getCacheCapacity", CallingConvention = CallingConvention.Cdecl)]
		public static extern nuint mj_getCacheCapacity(mjCache* cache);

		/// <summary>
		/// Set the capacity of the asset cache in bytes (0 to disable); return the new capacity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setCacheCapacity", CallingConvention = CallingConvention.Cdecl)]
		public static extern nuint mj_setCacheCapacity(mjCache* cache, nuint size);

		/// <summary>
		/// Get the internal asset cache used by the compiler.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getCache", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjCache* mj_getCache();

		/// <summary>
		/// Clear the asset cache.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_clearCache", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_clearCache(mjCache* cache);

		/// <summary>
		/// Parse XML file in MJCF or URDF format, compile it; return low-level model.
		/// If vfs is not NULL, look up files in vfs before reading from disk.
		/// If error is not NULL, it must have size error_sz.
		/// Nullable: vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_loadXML", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjModel* mj_loadXML([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, mjVFS* vfs, byte* error, int error_sz);

		/// <summary>
		/// Parse spec from XML file.
		/// Nullable: vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_parseXML", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mj_parseXML([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, mjVFS* vfs, byte* error, int error_sz);

		/// <summary>
		/// Parse spec from XML string.
		/// Nullable: vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_parseXMLString", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mj_parseXMLString([MarshalAs(UnmanagedType.LPUTF8Str)] string xml, mjVFS* vfs, byte* error, int error_sz);

		/// <summary>
		/// Parse spec from a file.
		/// Nullable: vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_parse", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mj_parse([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string content_type, mjVFS* vfs, byte* error, int error_sz);

		/// <summary>
		/// Encode spec/model to a file using a registered encoder.
		/// Returns the number of bytes written on success, -1 on failure.
		/// Nullable: m, vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_encode", CallingConvention = CallingConvention.Cdecl)]
		public static extern long mj_encode(mjSpec* s, mjModel* m, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string content_type, mjVFS* vfs, byte* error, int error_sz);

		/// <summary>
		/// Compile spec to model.
		/// Nullable: vfs
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_compile", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjModel* mj_compile(mjSpec* s, mjVFS* vfs);

		/// <summary>
		/// Copy real-valued arrays from model to spec; return 1 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_copyBack", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_copyBack(mjSpec* s, mjModel* m);

		/// <summary>
		/// Recompile spec to model, preserving the state; return 0 on success.
		/// Nullable: vfs
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_recompile", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_recompile(mjSpec* s, mjVFS* vfs, mjModel* m, mjData* d);

		/// <summary>
		/// Update XML data structures with info from low-level model created with mj_loadXML, save as MJCF.
		/// If error is not NULL, it must have size error_sz.
		/// Nullable: error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_saveLastXML", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_saveLastXML([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, mjModel* m, byte* error, int error_sz);

		/// <summary>
		/// Free last XML model if loaded. Called internally at each load.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_freeLastXML", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_freeLastXML();

		/// <summary>
		/// Save spec to XML string; return 0 on success, -1 on failure.
		/// If length of the output buffer is too small; return the required size.
		/// Nullable: error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_saveXMLString", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_saveXMLString(mjSpec* s, byte* xml, int xml_sz, byte* error, int error_sz);

		/// <summary>
		/// Save spec to XML file; return 0 on success, -1 otherwise.
		/// Nullable: error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_saveXML", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_saveXML(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, byte* error, int error_sz);

		/// <summary>
		/// Given MJCF filename, fills dependencies with a list of all other asset files it depends on.
		/// The search is recursive, and the list includes the filename itself.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_getXMLDependencies", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_getXMLDependencies([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, void* dependencies);

		/// <summary>
		/// Advance simulation, use control callback to obtain external force and control.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_step", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_step(mjModel* m, mjData* d);

		/// <summary>
		/// Advance simulation in two steps: before external force and control is set by user.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_step1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_step1(mjModel* m, mjData* d);

		/// <summary>
		/// Advance simulation in two steps: after external force and control is set by user.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_step2", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_step2(mjModel* m, mjData* d);

		/// <summary>
		/// Forward dynamics: same as mj_step but do not integrate in time.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_forward", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_forward(mjModel* m, mjData* d);

		/// <summary>
		/// Inverse dynamics: qacc must be set before calling.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_inverse", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_inverse(mjModel* m, mjData* d);

		/// <summary>
		/// Forward dynamics with skip; skipstage is mjtStage.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_forwardSkip", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_forwardSkip(mjModel* m, mjData* d, int skipstage, int skipsensor);

		/// <summary>
		/// Inverse dynamics with skip; skipstage is mjtStage.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_inverseSkip", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_inverseSkip(mjModel* m, mjData* d, int skipstage, int skipsensor);

		/// <summary>
		/// Set default options for length range computation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_defaultLROpt", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_defaultLROpt(mjLROpt* opt);

		/// <summary>
		/// Set solver parameters to default values.
		/// Nullable: solref, solimp
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_defaultSolRefImp", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_defaultSolRefImp(double* solref, double* solimp);

		/// <summary>
		/// Set physics options to default values.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_defaultOption", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_defaultOption(mjOption* opt);

		/// <summary>
		/// Set visual options to default values.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_defaultVisual", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_defaultVisual(mjVisual* vis);

		/// <summary>
		/// Copy mjModel, allocate new if dest is NULL.
		/// Nullable: dest
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_copyModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjModel* mj_copyModel(mjModel* dest, mjModel* src);

		/// <summary>
		/// Save model to binary MJB file or memory buffer; buffer has precedence when given.
		/// Nullable: filename, buffer
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_saveModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_saveModel(mjModel* m, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, void* buffer, int buffer_sz);

		/// <summary>
		/// Load model from binary MJB file.
		/// If vfs is not NULL, look up file in vfs before reading from disk.
		/// Nullable: vfs
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_loadModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjModel* mj_loadModel([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, mjVFS* vfs);

		/// <summary>
		/// Load model from memory buffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_loadModelBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjModel* mj_loadModelBuffer(void* buffer, int buffer_sz);

		/// <summary>
		/// Free memory allocation in model.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_deleteModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_deleteModel(mjModel* m);

		/// <summary>
		/// Return size of buffer needed to hold model.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_sizeModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern long mj_sizeModel(mjModel* m);

		/// <summary>
		/// Allocate mjData corresponding to given model.
		/// If the model buffer is unallocated the initial configuration will not be set.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_makeData", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjData* mj_makeData(mjModel* m);

		/// <summary>
		/// Copy mjData.
		/// m is only required to contain the size fields from MJMODEL_INTS.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_copyData", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjData* mj_copyData(mjData* dest, mjModel* m, mjData* src);

		/// <summary>
		/// Copy mjData, skip large arrays not required for visualization.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_copyData", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjData* mjv_copyData(mjData* dest, mjModel* m, mjData* src);

		/// <summary>
		/// Reset ctrl to neutral values: zero, except quaternion inputs which reset to the identity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_resetCtrl", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_resetCtrl(mjModel* m, mjData* d);

		/// <summary>
		/// Reset data to defaults.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_resetData", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_resetData(mjModel* m, mjData* d);

		/// <summary>
		/// Reset data to defaults, fill everything else with debug_value.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_resetDataDebug", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_resetDataDebug(mjModel* m, mjData* d, byte debug_value);

		/// <summary>
		/// Reset data. If 0
		/// &lt;
		/// = key
		/// &lt;
		/// nkey, set fields from specified keyframe.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_resetDataKeyframe", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_resetDataKeyframe(mjModel* m, mjData* d, int key);

		/// <summary>
		/// Mark a new frame on the mjData stack.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_markStack", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_markStack(mjData* d);

		/// <summary>
		/// Free the current mjData stack frame. All pointers returned by mj_stackAlloc since the last call
		/// to mj_markStack must no longer be used afterwards.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_freeStack", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_freeStack(mjData* d);

		/// <summary>
		/// Allocate a number of bytes on mjData stack at a specific alignment.
		/// Call mju_error on stack overflow.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_stackAllocByte", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* mj_stackAllocByte(mjData* d, nuint bytes, nuint alignment);

		/// <summary>
		/// Allocate array of mjtNums on mjData stack. Call mju_error on stack overflow.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_stackAllocNum", CallingConvention = CallingConvention.Cdecl)]
		public static extern double* mj_stackAllocNum(mjData* d, nuint size);

		/// <summary>
		/// Allocate array of ints on mjData stack. Call mju_error on stack overflow.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_stackAllocInt", CallingConvention = CallingConvention.Cdecl)]
		public static extern int* mj_stackAllocInt(mjData* d, nuint size);

		/// <summary>
		/// Free memory allocation in mjData.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_deleteData", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_deleteData(mjData* d);

		/// <summary>
		/// Reset all callbacks to NULL pointers (NULL is the default).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_resetCallbacks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_resetCallbacks();

		/// <summary>
		/// Set constant fields of mjModel, corresponding to qpos0 configuration.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setConst", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_setConst(mjModel* m, mjData* d);

		/// <summary>
		/// Set actuator_lengthrange for specified actuator; return 1 if ok, 0 if error.
		/// Nullable: error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setLengthRange", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_setLengthRange(mjModel* m, mjData* d, int index, mjLROpt* opt, byte* error, int error_sz);

		/// <summary>
		/// Create empty spec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_makeSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mj_makeSpec();

		/// <summary>
		/// Copy spec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_copySpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mj_copySpec(mjSpec* s);

		/// <summary>
		/// Free memory allocation in mjSpec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_deleteSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_deleteSpec(mjSpec* s);

		/// <summary>
		/// Activate plugin; return 0 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_activatePlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_activatePlugin(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Turn deep copy on or off attach; return 0 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setDeepCopy", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_setDeepCopy(mjSpec* s, int deepcopy);

		/// <summary>
		/// Print mjModel to text file, specifying format.
		/// float_format must be a valid printf-style format string for a single float value.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printFormattedModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printFormattedModel(mjModel* m, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string float_format);

		/// <summary>
		/// Print model to text file.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printModel(mjModel* m, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Print mjData to text file, specifying format.
		/// float_format must be a valid printf-style format string for a single float value.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printFormattedData", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printFormattedData(mjModel* m, mjData* d, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string float_format);

		/// <summary>
		/// Print data to text file.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printData", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printData(mjModel* m, mjData* d, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Print matrix to screen.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_printMat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_printMat(double* mat, int nr, int nc);

		/// <summary>
		/// Print sparse matrix to screen.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_printMatSparse", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_printMatSparse(double* mat, int nr, int* rownnz, int* rowadr, int* colind);

		/// <summary>
		/// Print internal XML schema as plain text or HTML, with style-padding or
		/// .
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printSchema", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_printSchema([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, byte* buffer, int buffer_sz, int flg_html, int flg_pad);

		/// <summary>
		/// Print scene to text file.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printScene(mjvScene* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

		/// <summary>
		/// Print scene to text file, specifying format.
		/// float_format must be a valid printf-style format string for a single float value.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_printFormattedScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_printFormattedScene(mjvScene* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string float_format);

		/// <summary>
		/// Run all kinematics-like computations (kinematics, comPos, camlight, flex, tendon).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdKinematics", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdKinematics(mjModel* m, mjData* d);

		/// <summary>
		/// Run position-dependent computations.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdPosition", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdPosition(mjModel* m, mjData* d);

		/// <summary>
		/// Run velocity-dependent computations.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdVelocity", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdVelocity(mjModel* m, mjData* d);

		/// <summary>
		/// Compute actuator force qfrc_actuator.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdActuation", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdActuation(mjModel* m, mjData* d);

		/// <summary>
		/// Add up all non-constraint forces, compute qacc_smooth.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdAcceleration", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdAcceleration(mjModel* m, mjData* d);

		/// <summary>
		/// Run selected constraint solver.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fwdConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fwdConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Euler integrator, semi-implicit in velocity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_Euler", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_Euler(mjModel* m, mjData* d);

		/// <summary>
		/// Runge-Kutta explicit order-N integrator.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_RungeKutta", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_RungeKutta(mjModel* m, mjData* d, int N);

		/// <summary>
		/// Implicit-in-velocity integrators.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_implicit", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_implicit(mjModel* m, mjData* d);

		/// <summary>
		/// Run position-dependent computations in inverse dynamics.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_invPosition", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_invPosition(mjModel* m, mjData* d);

		/// <summary>
		/// Run velocity-dependent computations in inverse dynamics.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_invVelocity", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_invVelocity(mjModel* m, mjData* d);

		/// <summary>
		/// Apply the analytical formula for inverse constraint dynamics.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_invConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_invConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Compare forward and inverse dynamics, save results in fwdinv.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_compareFwdInv", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_compareFwdInv(mjModel* m, mjData* d);

		/// <summary>
		/// Evaluate position-dependent sensors.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_sensorPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_sensorPos(mjModel* m, mjData* d);

		/// <summary>
		/// Evaluate velocity-dependent sensors.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_sensorVel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_sensorVel(mjModel* m, mjData* d);

		/// <summary>
		/// Evaluate acceleration and force-dependent sensors.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_sensorAcc", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_sensorAcc(mjModel* m, mjData* d);

		/// <summary>
		/// Evaluate position-dependent energy (potential).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_energyPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_energyPos(mjModel* m, mjData* d);

		/// <summary>
		/// Evaluate velocity-dependent energy (kinetic).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_energyVel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_energyVel(mjModel* m, mjData* d);

		/// <summary>
		/// Check qpos, reset if any element is too big or nan.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_checkPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_checkPos(mjModel* m, mjData* d);

		/// <summary>
		/// Check qvel, reset if any element is too big or nan.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_checkVel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_checkVel(mjModel* m, mjData* d);

		/// <summary>
		/// Check qacc, reset if any element is too big or nan.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_checkAcc", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_checkAcc(mjModel* m, mjData* d);

		/// <summary>
		/// Run forward kinematics.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_kinematics", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_kinematics(mjModel* m, mjData* d);

		/// <summary>
		/// Map inertias and motion dofs to global frame centered at CoM.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_comPos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_comPos(mjModel* m, mjData* d);

		/// <summary>
		/// Compute camera and light positions and orientations.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_camlight", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_camlight(mjModel* m, mjData* d);

		/// <summary>
		/// Compute flex-related quantities.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_flex", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_flex(mjModel* m, mjData* d);

		/// <summary>
		/// Compute tendon lengths, velocities and moment arms.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_tendon", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_tendon(mjModel* m, mjData* d);

		/// <summary>
		/// Compute actuator transmission lengths and moments.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_transmission", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_transmission(mjModel* m, mjData* d);

		/// <summary>
		/// Run composite rigid body inertia algorithm (CRB).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_crb", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_crb(mjModel* m, mjData* d);

		/// <summary>
		/// Make inertia matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_makeM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_makeM(mjModel* m, mjData* d);

		/// <summary>
		/// Compute sparse L'*D*L factorizaton of inertia matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_factorM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_factorM(mjModel* m, mjData* d);

		/// <summary>
		/// Solve linear system M * x = y using factorization:  x = inv(L'*D*L)*y
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_solveM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_solveM(mjModel* m, mjData* d, double* x, double* y, int n);

		/// <summary>
		/// Half of linear solve:  x = sqrt(inv(D))*inv(L')*y
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_solveM2", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_solveM2(mjModel* m, mjData* d, double* x, double* y, double* sqrtInvD, int n);

		/// <summary>
		/// Compute cvel, cdof_dot.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_comVel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_comVel(mjModel* m, mjData* d);

		/// <summary>
		/// Compute qfrc_passive from spring-dampers, gravity compensation and fluid forces.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_passive", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_passive(mjModel* m, mjData* d);

		/// <summary>
		/// Sub-tree linear velocity and angular momentum: compute subtree_linvel, subtree_angmom.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_subtreeVel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_subtreeVel(mjModel* m, mjData* d);

		/// <summary>
		/// RNE: compute M(qpos)*qacc + C(qpos,qvel); flg_acc=0 removes inertial term.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_rne", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_rne(mjModel* m, mjData* d, int flg_acc, double* result);

		/// <summary>
		/// RNE with complete data: compute cacc, cfrc_ext, cfrc_int.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_rnePostConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_rnePostConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Return the maximum number of contacts that can be generated between two geoms.
		/// If has_margin is -1, then the margin is pulled from the model, otherwise if has_margin &gt; 0
		/// indicates that the geoms have a positive margin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_maxContact", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_maxContact(mjModel* m, int g1, int g2, int has_margin);

		/// <summary>
		/// Run collision detection.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_collision", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_collision(mjModel* m, mjData* d);

		/// <summary>
		/// Construct constraints.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_makeConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_makeConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Find constraint islands.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_island", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_island(mjModel* m, mjData* d);

		/// <summary>
		/// Compute inverse constraint inertia efc_AR.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_projectConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_projectConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Compute efc_vel, efc_aref.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_referenceConstraint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_referenceConstraint(mjModel* m, mjData* d);

		/// <summary>
		/// Compute efc_state, efc_force, qfrc_constraint, and (optionally) cone Hessians.
		/// If cost is not NULL, set *cost = s(jar) where jar = Jac*qacc-aref.
		/// Nullable: cost
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_constraintUpdate", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_constraintUpdate(mjModel* m, mjData* d, double* jar, double cost, int flg_coneHessian);

		/// <summary>
		/// Return size of state signature.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_stateSize", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_stateSize(mjModel* m, int sig);

		/// <summary>
		/// Get state.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getState", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_getState(mjModel* m, mjData* d, double* state, int sig);

		/// <summary>
		/// Extract a subset of components from a state previously obtained via mj_getState.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_extractState", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_extractState(mjModel* m, double* src, int srcsig, double* dst, int dstsig);

		/// <summary>
		/// Set state.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setState", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_setState(mjModel* m, mjData* d, double* state, int sig);

		/// <summary>
		/// Copy state from src to dst.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_copyState", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_copyState(mjModel* m, mjData* src, mjData* dst, int sig);

		/// <summary>
		/// Read ctrl value for actuator at given time.
		/// Returns d-&gt;ctrl[id] if no history, otherwise reads from history buffer.
		/// interp: 0=zero-order-hold, 1=linear, 2=cubic spline.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_readCtrl", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_readCtrl(mjModel* m, mjData* d, int id, double time, int interp);

		/// <summary>
		/// Read sensor value from history buffer at given time.
		/// Returns pointer to sensordata (no history) or history buffer (exact match),
		/// or NULL if interpolation performed (writes to result).
		/// interp: 0=zero-order-hold, 1=linear, 2=cubic spline.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_readSensor", CallingConvention = CallingConvention.Cdecl)]
		public static extern double* mj_readSensor(mjModel* m, mjData* d, int id, double time, double* result, int interp);

		/// <summary>
		/// Initialize history buffer for actuator; if times is NULL, uses existing buffer timestamps.
		/// Nullable: times
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_initCtrlHistory", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_initCtrlHistory(mjModel* m, mjData* d, int id, double* times, double* values);

		/// <summary>
		/// Initialize history buffer for sensor; if times is NULL, uses existing buffer timestamps.
		/// phase sets the user slot (last computation time for interval sensors).
		/// Nullable: times
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_initSensorHistory", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_initSensorHistory(mjModel* m, mjData* d, int id, double* times, double* values, double phase);

		/// <summary>
		/// Copy current state to the k-th model keyframe.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setKeyframe", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_setKeyframe(mjModel* m, mjData* d, int k);

		/// <summary>
		/// Add contact to d-&gt;contact list; return 0 if success; 1 if buffer full.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_addContact", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_addContact(mjModel* m, mjData* d, mjContact* con);

		/// <summary>
		/// Determine type of friction cone.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_isPyramidal", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_isPyramidal(mjModel* m);

		/// <summary>
		/// Determine type of constraint Jacobian.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_isSparse", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_isSparse(mjModel* m);

		/// <summary>
		/// Determine type of solver (PGS is dual, CG and Newton are primal).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_isDual", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_isDual(mjModel* m);

		/// <summary>
		/// Multiply dense or sparse constraint Jacobian by vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_mulJacVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_mulJacVec(mjModel* m, mjData* d, double* res, double* vec);

		/// <summary>
		/// Multiply dense or sparse constraint Jacobian transpose by vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_mulJacTVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_mulJacTVec(mjModel* m, mjData* d, double* res, double* vec);

		/// <summary>
		/// Compute 3/6-by-nv end-effector Jacobian of global point attached to given body.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jac", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jac(mjModel* m, mjData* d, double* jacp, double* jacr, double point, int body);

		/// <summary>
		/// Compute body frame end-effector Jacobian.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacBody", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacBody(mjModel* m, mjData* d, double* jacp, double* jacr, int body);

		/// <summary>
		/// Compute body center-of-mass end-effector Jacobian.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacBodyCom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacBodyCom(mjModel* m, mjData* d, double* jacp, double* jacr, int body);

		/// <summary>
		/// Compute subtree center-of-mass end-effector Jacobian.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacSubtreeCom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacSubtreeCom(mjModel* m, mjData* d, double* jacp, int body);

		/// <summary>
		/// Compute geom end-effector Jacobian.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacGeom(mjModel* m, mjData* d, double* jacp, double* jacr, int geom);

		/// <summary>
		/// Compute site end-effector Jacobian.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacSite(mjModel* m, mjData* d, double* jacp, double* jacr, int site);

		/// <summary>
		/// Compute translation end-effector Jacobian of point, and rotation Jacobian of axis.
		/// Nullable: jacPoint, jacAxis
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacPointAxis", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacPointAxis(mjModel* m, mjData* d, double* jacPoint, double* jacAxis, double point, double axis, int body);

		/// <summary>
		/// Compute 3/6-by-nv Jacobian time derivative of global point attached to given body.
		/// Nullable: jacp, jacr
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_jacDot", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_jacDot(mjModel* m, mjData* d, double* jacp, double* jacr, double point, int body);

		/// <summary>
		/// Compute subtree angular momentum matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_angmomMat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_angmomMat(mjModel* m, mjData* d, double* mat, int body);

		/// <summary>
		/// Get id of object with the specified mjtObj type and name; return -1 if id not found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_name2id", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_name2id(mjModel* m, int type, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Get name of object with the specified mjtObj type and id; return NULL if name not found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_id2name", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mj_id2name(mjModel* m, int type, int id);

		/// <summary>
		/// Get name of actuator input, determined by the actuator type and input signature;
		/// return NULL if the actuator type defines no input names.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_actuatorInputName", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mj_actuatorInputName(mjModel* m, int id, int input);

		/// <summary>
		/// Convert sparse inertia matrix into full (i.e. dense) matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_fullM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_fullM(mjModel* m, mjData* d, double* dst);

		/// <summary>
		/// Multiply vector by inertia matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_mulM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_mulM(mjModel* m, mjData* d, double* res, double* vec);

		/// <summary>
		/// Multiply vector by (inertia matrix)^(1/2).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_mulM2", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_mulM2(mjModel* m, mjData* d, double* res, double* vec);

		/// <summary>
		/// Add inertia matrix to destination matrix (lower triangle only).
		/// Destination can be sparse or dense when all int* are NULL.
		/// Nullable: rownnz, rowadr, colind
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_addM", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_addM(mjModel* m, mjData* d, double* dst, int* rownnz, int* rowadr, int* colind);

		/// <summary>
		/// Apply Cartesian force and torque (outside xfrc_applied mechanism).
		/// Nullable: force, torque
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_applyFT", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_applyFT(mjModel* m, mjData* d, double force, double torque, double point, int body, double* qfrc_target);

		/// <summary>
		/// Compute object 6D velocity (rot:lin) in object-centered frame, world/local orientation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_objectVelocity", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_objectVelocity(mjModel* m, mjData* d, int objtype, int objid, double res, int flg_local);

		/// <summary>
		/// Compute object 6D acceleration (rot:lin) in object-centered frame, world/local orientation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_objectAcceleration", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_objectAcceleration(mjModel* m, mjData* d, int objtype, int objid, double res, int flg_local);

		/// <summary>
		/// Return smallest signed distance between two geoms and optionally segment from geom1 to geom2.
		/// Nullable: fromto
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_geomDistance", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_geomDistance(mjModel* m, mjData* d, int geom1, int geom2, double distmax, double fromto);

		/// <summary>
		/// Extract 6D force:torque given contact id, in the contact frame.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_contactForce", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_contactForce(mjModel* m, mjData* d, int id, double result);

		/// <summary>
		/// Compute velocity by finite-differencing two positions.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_differentiatePos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_differentiatePos(mjModel* m, double* qvel, double dt, double* qpos1, double* qpos2);

		/// <summary>
		/// Integrate position with given velocity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_integratePos", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_integratePos(mjModel* m, double* qpos, double* qvel, double dt);

		/// <summary>
		/// Normalize all quaternions in qpos-type vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_normalizeQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_normalizeQuat(mjModel* m, double* qpos);

		/// <summary>
		/// Map from body local to global Cartesian coordinates, sameframe takes values from mjtSameFrame.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_local2Global", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_local2Global(mjData* d, double xpos, double xmat, double pos, double quat, int body, byte sameframe);

		/// <summary>
		/// Sum all body masses.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getTotalmass", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_getTotalmass(mjModel* m);

		/// <summary>
		/// Scale body masses and inertias to achieve specified total mass.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_setTotalmass", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_setTotalmass(mjModel* m, double newmass);

		/// <summary>
		/// Return a config attribute value of a plugin instance;
		/// NULL: invalid plugin instance ID or attribute name
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_getPluginConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mj_getPluginConfig(mjModel* m, int plugin_id, [MarshalAs(UnmanagedType.LPUTF8Str)] string attrib);

		/// <summary>
		/// Load a dynamic library. The dynamic library is assumed to register one or more plugins.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_loadPluginLibrary", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_loadPluginLibrary([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

		/// <summary>
		/// Scan a directory and load all dynamic libraries. Dynamic libraries in the specified directory
		/// are assumed to register one or more plugins. Optionally, if a callback is specified, it is called
		/// for each dynamic library encountered that registers plugins.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_loadAllPluginLibraries", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_loadAllPluginLibraries([MarshalAs(UnmanagedType.LPUTF8Str)] string directory, delegate* unmanaged[Cdecl]<byte*, int, int, void> callback);

		/// <summary>
		/// Return version number: 1.0.2 is encoded as 102.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_version", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mj_version();

		/// <summary>
		/// Return the current version of MuJoCo as a null-terminated string.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_versionString", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mj_versionString();

		/// <summary>
		/// Intersect ray (pnt+x*vec, x&gt;=0) with visible geoms, except geoms in bodyexclude.
		/// Return distance (x) to nearest surface, or -1 if no intersection.
		/// geomgroup, flg_static are as in mjvOption; geomgroup==NULL skips group exclusion.
		/// Nullable: geomgroup, geomid, normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_ray", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_ray(mjModel* m, mjData* d, double pnt, double vec, byte* geomgroup, byte flg_static, int bodyexclude, int geomid, double normal);

		/// <summary>
		/// Intersect multiple rays emanating from a single point, compute normals if given.
		/// Similar semantics to mj_ray, but vec, normal and dist are arrays.
		/// Geoms further than cutoff are ignored.
		/// Nullable: geomgroup, geomid, normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_multiRay", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_multiRay(mjModel* m, mjData* d, double pnt, double* vec, byte* geomgroup, byte flg_static, int bodyexclude, int* geomid, double* dist, double* normal, int nray, double cutoff);

		/// <summary>
		/// Intersect ray with hfield; return nearest distance or -1 if no intersection.
		/// Nullable: normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_rayHfield", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_rayHfield(mjModel* m, mjData* d, int geomid, double pnt, double vec, double normal);

		/// <summary>
		/// Intersect ray with mesh; return nearest distance or -1 if no intersection.
		/// Nullable: normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_rayMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_rayMesh(mjModel* m, mjData* d, int geomid, double pnt, double vec, double normal);

		/// <summary>
		/// Intersect ray with pure geom; return nearest distance or -1 if no intersection.
		/// Nullable: normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_rayGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_rayGeom(double pos, double mat, double size, double pnt, double vec, int geomtype, double normal);

		/// <summary>
		/// Intersect ray with flex; return nearest distance or -1 if no intersection,
		/// and also output nearest vertex id and surface normal.
		/// Nullable: vertid, normal
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_rayFlex", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mj_rayFlex(mjModel* m, mjData* d, int flex_layer, byte flg_vert, byte flg_edge, byte flg_face, byte flg_skin, int flexid, double pnt, double vec, int vertid, double normal);

		/// <summary>
		/// Intersect ray with skin; return nearest distance or -1 if no intersection,
		/// and also output nearest vertex id.
		/// Nullable: vertid
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_raySkin", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_raySkin(int nface, int nvert, int* face, float* vert, double pnt, double vec, int vertid);

		/// <summary>
		/// Set default camera.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultCamera(mjvCamera* cam);

		/// <summary>
		/// Set default free camera.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultFreeCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultFreeCamera(mjModel* m, mjvCamera* cam);

		/// <summary>
		/// Set default perturbation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultPerturb", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultPerturb(mjvPerturb* pert);

		/// <summary>
		/// Transform pose from room to model space.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_room2model", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_room2model(double modelpos, double modelquat, double roompos, double roomquat, mjvScene* scn);

		/// <summary>
		/// Transform pose from model to room space.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_model2room", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_model2room(double roompos, double roomquat, double modelpos, double modelquat, mjvScene* scn);

		/// <summary>
		/// Get camera info in model space; average left and right OpenGL cameras.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_cameraInModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_cameraInModel(double headpos, double forward, double up, mjvScene* scn);

		/// <summary>
		/// Get camera info in room space; average left and right OpenGL cameras.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_cameraInRoom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_cameraInRoom(double headpos, double forward, double up, mjvScene* scn);

		/// <summary>
		/// Get frustum height at unit distance from camera; average left and right OpenGL cameras.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_frustumHeight", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mjv_frustumHeight(mjvScene* scn);

		/// <summary>
		/// Rotate 3D vec in horizontal plane by angle between (0,1) and (forward_x,forward_y).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_alignToCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_alignToCamera(double res, double vec, double forward);

		/// <summary>
		/// Move camera with mouse; action is mjtMouse.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_moveCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_moveCamera(mjModel* m, int action, double reldx, double reldy, mjvCamera* cam);

		/// <summary>
		/// Move perturb object with mouse; action is mjtMouse.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_movePerturb", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_movePerturb(mjModel* m, mjData* d, int action, double reldx, double reldy, mjvScene* scn, mjvPerturb* pert);

		/// <summary>
		/// Move model with mouse; action is mjtMouse.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_moveModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_moveModel(mjModel* m, int action, double reldx, double reldy, double roomup, mjvScene* scn);

		/// <summary>
		/// Copy perturb pos,quat from selected body; set scale for perturbation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_initPerturb", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_initPerturb(mjModel* m, mjData* d, mjvScene* scn, mjvPerturb* pert);

		/// <summary>
		/// Set perturb pos,quat in d-&gt;mocap when selected body is mocap, and in d-&gt;qpos otherwise.
		/// Write d-&gt;qpos only if flg_paused and subtree root for selected body has free joint.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_applyPerturbPose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_applyPerturbPose(mjModel* m, mjData* d, mjvPerturb* pert, int flg_paused);

		/// <summary>
		/// Set perturb force,torque in d-&gt;xfrc_applied, if selected body is dynamic.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_applyPerturbForce", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_applyPerturbForce(mjModel* m, mjData* d, mjvPerturb* pert);

		/// <summary>
		/// Return the average of two OpenGL cameras.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_averageCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjvGLCamera mjv_averageCamera(mjvGLCamera* cam1, mjvGLCamera* cam2);

		/// <summary>
		/// Select geom, flex or skin with mouse; return bodyid; -1: none selected.
		/// Nullable: geomid, flexid, skinid
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_select", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjv_select(mjModel* m, mjData* d, mjvOption* vopt, double aspectratio, double relx, double rely, mjvScene* scn, double selpnt, int geomid, int flexid, int skinid);

		/// <summary>
		/// Set default visualization options.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultOption", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultOption(mjvOption* opt);

		/// <summary>
		/// Set default figure.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultFigure", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultFigure(mjvFigure* fig);

		/// <summary>
		/// Initialize given geom fields when not NULL, set the rest to their default values.
		/// Nullable: size, pos, mat, rgba
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_initGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_initGeom(mjvGeom* geom, int type, double size, double pos, double mat, float rgba);

		/// <summary>
		/// Set (type, size, pos, mat) for connector-type geom between given points.
		/// Assume that mjv_initGeom was already called to set all other properties.
		/// Width of mjGEOM_LINE is denominated in pixels.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_connector", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_connector(mjvGeom* geom, int type, double width, double from, double to);

		/// <summary>
		/// Set default abstract scene.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_defaultScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_defaultScene(mjvScene* scn);

		/// <summary>
		/// Allocate resources in abstract scene.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_makeScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_makeScene(mjModel* m, mjvScene* scn, int maxgeom);

		/// <summary>
		/// Free abstract scene.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_freeScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_freeScene(mjvScene* scn);

		/// <summary>
		/// Update entire scene given model state.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_updateScene", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_updateScene(mjModel* m, mjData* d, mjvOption* opt, mjvPerturb* pert, mjvCamera* cam, int catmask, mjvScene* scn);

		/// <summary>
		/// Copy mjModel, skip large arrays not required for abstract visualization.
		/// Nullable: dest
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_copyModel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_copyModel(mjModel* dest, mjModel* src);

		/// <summary>
		/// Add geoms from selected categories.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_addGeoms", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_addGeoms(mjModel* m, mjData* d, mjvOption* opt, mjvPerturb* pert, int catmask, mjvScene* scn);

		/// <summary>
		/// Make list of lights.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_makeLights", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_makeLights(mjModel* m, mjData* d, mjvScene* scn);

		/// <summary>
		/// Update camera.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_updateCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_updateCamera(mjModel* m, mjData* d, mjvCamera* cam, mjvScene* scn);

		/// <summary>
		/// Update skins.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_updateSkin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_updateSkin(mjModel* m, mjData* d, mjvScene* scn);

		/// <summary>
		/// Compute camera position and forward, up, and right vectors.
		/// Nullable: headpos, forward, up, right
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_cameraFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_cameraFrame(double headpos, double forward, double up, double right, mjData* d, mjvCamera* cam);

		/// <summary>
		/// Compute camera frustum: vertical, horizontal, and clip planes.
		/// Nullable: zver, zhor, zclip
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjv_cameraFrustum", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjv_cameraFrustum(float zver, float zhor, float zclip, mjModel* m, mjvCamera* cam);

		/// <summary>
		/// Set default mjrContext.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_defaultContext", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_defaultContext(mjrContext* con);

		/// <summary>
		/// Set default mjrRendererInfo.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_defaultRendererInfo", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_defaultRendererInfo(mjrRendererInfo* info);

		/// <summary>
		/// Get active renderer information.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_getRendererInfo", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_getRendererInfo(mjrRendererInfo* info);

		/// <summary>
		/// Allocate resources in custom OpenGL context; fontscale is mjtFontScale.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_makeContext", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_makeContext(mjModel* m, mjrContext* con, int fontscale);

		/// <summary>
		/// Change font of existing context.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_changeFont", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_changeFont(int fontscale, mjrContext* con);

		/// <summary>
		/// Add Aux buffer with given index to context; free previous Aux buffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_addAux", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_addAux(int index, int width, int height, int samples, mjrContext* con);

		/// <summary>
		/// Free resources in custom OpenGL context, set to default.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_freeContext", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_freeContext(mjrContext* con);

		/// <summary>
		/// Resize offscreen buffers.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_resizeOffscreen", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_resizeOffscreen(int width, int height, mjrContext* con);

		/// <summary>
		/// Upload texture to GPU, overwriting previous upload if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_uploadTexture", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_uploadTexture(mjModel* m, mjrContext* con, int texid);

		/// <summary>
		/// Upload mesh to GPU, overwriting previous upload if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_uploadMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_uploadMesh(mjModel* m, mjrContext* con, int meshid);

		/// <summary>
		/// Upload height field to GPU, overwriting previous upload if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_uploadHField", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_uploadHField(mjModel* m, mjrContext* con, int hfieldid);

		/// <summary>
		/// Make con-&gt;currentBuffer current again.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_restoreBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_restoreBuffer(mjrContext* con);

		/// <summary>
		/// Set OpenGL framebuffer for rendering: mjFB_WINDOW or mjFB_OFFSCREEN.
		/// If only one buffer is available, set that buffer and ignore framebuffer argument.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_setBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_setBuffer(int framebuffer, mjrContext* con);

		/// <summary>
		/// Read pixels from current OpenGL framebuffer to client buffer.
		/// Viewport is in OpenGL framebuffer; client buffer starts at (0,0).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_readPixels", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_readPixels(byte* rgb, float* depth, mjrRect viewport, mjrContext* con);

		/// <summary>
		/// Draw pixels from client buffer to current OpenGL framebuffer.
		/// Viewport is in OpenGL framebuffer; client buffer starts at (0,0).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_drawPixels", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_drawPixels([MarshalAs(UnmanagedType.LPUTF8Str)] string rgb, float* depth, mjrRect viewport, mjrContext* con);

		/// <summary>
		/// Blit from src viewpoint in current framebuffer to dst viewport in other framebuffer.
		/// If src, dst have different size and flg_depth==0, color is interpolated with GL_LINEAR.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_blitBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_blitBuffer(mjrRect src, mjrRect dst, int flg_color, int flg_depth, mjrContext* con);

		/// <summary>
		/// Set Aux buffer for custom OpenGL rendering (call restoreBuffer when done).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_setAux", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_setAux(int index, mjrContext* con);

		/// <summary>
		/// Blit from Aux buffer to con-&gt;currentBuffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_blitAux", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_blitAux(int index, mjrRect src, int left, int bottom, mjrContext* con);

		/// <summary>
		/// Draw text at (x,y) in relative coordinates; font is mjtFont.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_text", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_text(int font, [MarshalAs(UnmanagedType.LPUTF8Str)] string txt, mjrContext* con, float x, float y, float r, float g, float b);

		/// <summary>
		/// Draw text overlay; font is mjtFont; gridpos is mjtGridPos.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_overlay", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_overlay(int font, int gridpos, mjrRect viewport, [MarshalAs(UnmanagedType.LPUTF8Str)] string overlay, [MarshalAs(UnmanagedType.LPUTF8Str)] string overlay2, mjrContext* con);

		/// <summary>
		/// Get maximum viewport for active buffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_maxViewport", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjrRect mjr_maxViewport(mjrContext* con);

		/// <summary>
		/// Draw rectangle.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_rectangle", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_rectangle(mjrRect viewport, float r, float g, float b, float a);

		/// <summary>
		/// Draw rectangle with centered text.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_label", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_label(mjrRect viewport, int font, [MarshalAs(UnmanagedType.LPUTF8Str)] string txt, float r, float g, float b, float a, float rt, float gt, float bt, mjrContext* con);

		/// <summary>
		/// Draw 2D figure.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_figure", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_figure(mjrRect viewport, mjvFigure* fig, mjrContext* con);

		/// <summary>
		/// Render 3D scene.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_render", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_render(mjrRect viewport, mjvScene* scn, mjrContext* con);

		/// <summary>
		/// Call glFinish.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_finish", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjr_finish();

		/// <summary>
		/// Call glGetError and return result.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_getError", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjr_getError();

		/// <summary>
		/// Find first rectangle containing mouse, -1: not found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjr_findRect", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjr_findRect(int x, int y, int nrect, mjrRect* rect);

		/// <summary>
		/// Get builtin UI theme spacing (ind: 0-1).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_themeSpacing", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjuiThemeSpacing mjui_themeSpacing(int ind);

		/// <summary>
		/// Get builtin UI theme color (ind: 0-3).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_themeColor", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjuiThemeColor mjui_themeColor(int ind);

		/// <summary>
		/// Add definitions to UI.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_add", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjui_add(mjUI* ui, mjuiDef* def);

		/// <summary>
		/// Add definitions to UI section.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_addToSection", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjui_addToSection(mjUI* ui, int sect, mjuiDef* def);

		/// <summary>
		/// Compute UI sizes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_resize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjui_resize(mjUI* ui, mjrContext* con);

		/// <summary>
		/// Update specific section/item; -1: update all.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_update", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjui_update(int section, int item, mjUI* ui, mjuiState* state, mjrContext* con);

		/// <summary>
		/// Handle UI event; return pointer to changed item, NULL if no change.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_event", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjuiItem* mjui_event(mjUI* ui, mjuiState* state, mjrContext* con);

		/// <summary>
		/// Copy UI image to current buffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjui_render", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjui_render(mjUI* ui, mjuiState* state, mjrContext* con);

		/// <summary>
		/// Main error function; does not return to caller.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_error", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		/// <summary>
		/// Main warning function; returns to caller.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_warning", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_warning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		/// <summary>
		/// Clear user error and memory handlers.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_clearHandlers", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_clearHandlers();

		/// <summary>
		/// Set the active log handler; return the previous handler.
		/// If handler is NULL, restore the default handler.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_setLogHandler", CallingConvention = CallingConvention.Cdecl)]
		public static extern delegate* unmanaged[Cdecl]<mjLogMessage*, void> mju_setLogHandler(delegate* unmanaged[Cdecl]<mjLogMessage*, void> handler);

		/// <summary>
		/// Get default handler configuration.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_getLogConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjLogConfig mju_getLogConfig();

		/// <summary>
		/// Set default handler configuration.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_setLogConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_setLogConfig(mjLogConfig config);

		/// <summary>
		/// Log an info message with optional topic filtering.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_info", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_info(int topic, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		/// <summary>
		/// Dispatch a structured log message to the active handler.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_message", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_message(mjLogMessage* msg);

		/// <summary>
		/// Allocate memory; byte-align on 64; pad size to multiple of 64.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_malloc", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* mju_malloc(nuint size);

		/// <summary>
		/// Free memory, using free() by default.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_free", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_free(void* ptr);

		/// <summary>
		/// High-level warning function: count warnings in mjData, print only the first.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mj_warning", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mj_warning(mjData* d, int warning, int info);

		/// <summary>
		/// Write [datetime, type: message] to MUJOCO_LOG.TXT.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_writeLog", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_writeLog([MarshalAs(UnmanagedType.LPUTF8Str)] string type, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		/// <summary>
		/// Get compiler error message from spec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getError", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_getError(mjSpec* s);

		/// <summary>
		/// Get compiler timing diagnostics from spec, returns pointer to array of size mjNCTIMER.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getTimer", CallingConvention = CallingConvention.Cdecl)]
		public static extern double* mjs_getTimer(mjSpec* s);

		/// <summary>
		/// Return 1 if compiler error is a warning. Deprecated: use mjs_numWarnings(s) &gt; 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_isWarning", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_isWarning(mjSpec* s);

		/// <summary>
		/// Get number of warnings accumulated in the spec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_numWarnings", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_numWarnings(mjSpec* spec);

		/// <summary>
		/// Get the i-th warning message (returns nullptr if index out of bounds).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWarning", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_getWarning(mjSpec* spec, int index);

		/// <summary>
		/// Set res = 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_zero3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_zero3(double res);

		/// <summary>
		/// Set res = vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_copy3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_copy3(double res, double data);

		/// <summary>
		/// Set res = vec*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_scl3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_scl3(double res, double vec, double scl);

		/// <summary>
		/// Set res = vec1 + vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_add3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_add3(double res, double vec1, double vec2);

		/// <summary>
		/// Set res = vec1 - vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sub3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_sub3(double res, double vec1, double vec2);

		/// <summary>
		/// Set res = res + vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addTo3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addTo3(double res, double vec);

		/// <summary>
		/// Set res = res - vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_subFrom3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_subFrom3(double res, double vec);

		/// <summary>
		/// Set res = res + vec*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addToScl3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addToScl3(double res, double vec, double scl);

		/// <summary>
		/// Set res = vec1 + vec2*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addScl3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addScl3(double res, double vec1, double vec2, double scl);

		/// <summary>
		/// Normalize vector; return length before normalization.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_normalize3", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_normalize3(double vec);

		/// <summary>
		/// Return vector length (without normalizing the vector).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_norm3", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_norm3(double vec);

		/// <summary>
		/// Return dot-product of vec1 and vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_dot3", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_dot3(double vec1, double vec2);

		/// <summary>
		/// Return Cartesian distance between 3D vectors pos1 and pos2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_dist3", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_dist3(double pos1, double pos2);

		/// <summary>
		/// Multiply 3-by-3 matrix by vector: res = mat * vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatVec3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatVec3(double res, double mat, double vec);

		/// <summary>
		/// Multiply transposed 3-by-3 matrix by vector: res = mat' * vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatTVec3", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatTVec3(double res, double mat, double vec);

		/// <summary>
		/// Compute cross-product: res = cross(a, b).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cross", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_cross(double res, double a, double b);

		/// <summary>
		/// Set res = 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_zero4", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_zero4(double res);

		/// <summary>
		/// Set res = (1,0,0,0).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_unit4", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_unit4(double res);

		/// <summary>
		/// Set res = vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_copy4", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_copy4(double res, double data);

		/// <summary>
		/// Normalize vector; return length before normalization.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_normalize4", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_normalize4(double vec);

		/// <summary>
		/// Set res = 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_zero", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_zero(double* res, int n);

		/// <summary>
		/// Set res = val.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_fill", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_fill(double* res, double val, int n);

		/// <summary>
		/// Set res = vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_copy", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_copy(double* res, double* vec, int n);

		/// <summary>
		/// Return sum(vec).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sum", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_sum(double* vec, int n);

		/// <summary>
		/// Return L1 norm: sum(abs(vec)).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_L1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_L1(double* vec, int n);

		/// <summary>
		/// Set res = vec*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_scl", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_scl(double* res, double* vec, double scl, int n);

		/// <summary>
		/// Set res = vec1 + vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_add", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_add(double* res, double* vec1, double* vec2, int n);

		/// <summary>
		/// Set res = vec1 - vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sub", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_sub(double* res, double* vec1, double* vec2, int n);

		/// <summary>
		/// Set res = res + vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addTo", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addTo(double* res, double* vec, int n);

		/// <summary>
		/// Set res = res - vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_subFrom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_subFrom(double* res, double* vec, int n);

		/// <summary>
		/// Set res = res + vec*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addToScl", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addToScl(double* res, double* vec, double scl, int n);

		/// <summary>
		/// Set res = vec1 + vec2*scl.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_addScl", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_addScl(double* res, double* vec1, double* vec2, double scl, int n);

		/// <summary>
		/// Normalize vector; return length before normalization.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_normalize", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_normalize(double* res, int n);

		/// <summary>
		/// Return vector length (without normalizing vector).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_norm", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_norm(double* res, int n);

		/// <summary>
		/// Return dot-product of vec1 and vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_dot", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_dot(double* vec1, double* vec2, int n);

		/// <summary>
		/// Multiply matrix and vector: res = mat * vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatVec(double* res, double* mat, double* vec, int nr, int nc);

		/// <summary>
		/// Multiply transposed matrix and vector: res = mat' * vec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatTVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatTVec(double* res, double* mat, double* vec, int nr, int nc);

		/// <summary>
		/// Multiply square matrix with vectors on both sides: return vec1' * mat * vec2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulVecMatVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_mulVecMatVec(double* vec1, double* mat, double* vec2, int n);

		/// <summary>
		/// Transpose matrix: res = mat'.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_transpose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_transpose(double* res, double* mat, int nr, int nc);

		/// <summary>
		/// Symmetrize square matrix res = (mat + mat')/2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_symmetrize", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_symmetrize(double* res, double* mat, int n);

		/// <summary>
		/// Set mat to the identity matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_eye", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_eye(double* mat, int n);

		/// <summary>
		/// Multiply matrices: res = mat1 * mat2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatMat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatMat(double* res, double* mat1, double* mat2, int r1, int c1, int c2);

		/// <summary>
		/// Multiply matrices, second argument transposed: res = mat1 * mat2'.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatMatT", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatMatT(double* res, double* mat1, double* mat2, int r1, int c1, int r2);

		/// <summary>
		/// Multiply matrices, first argument transposed: res = mat1' * mat2.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulMatTMat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulMatTMat(double* res, double* mat1, double* mat2, int r1, int c1, int c2);

		/// <summary>
		/// Set res = mat' * diag * mat if diag is not NULL, and res = mat' * mat otherwise.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sqrMatTD", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_sqrMatTD(double* res, double* mat, double* diag, int nr, int nc);

		/// <summary>
		/// Coordinate transform of 6D motion or force vector in rotation:translation format.
		/// rotnew2old is 3-by-3, NULL means no rotation; flg_force specifies force or motion type.
		/// Nullable: rotnew2old
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_transformSpatial", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_transformSpatial(double res, double vec, int flg_force, double newpos, double oldpos, double rotnew2old);

		/// <summary>
		/// Convert matrix from dense to sparse.
		/// nnz is size of res and colind; return 1 if too small, 0 otherwise.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_dense2sparse", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_dense2sparse(double* res, double* mat, int nr, int nc, int* rownnz, int* rowadr, int* colind, int nnz);

		/// <summary>
		/// Convert matrix from sparse to dense.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sparse2dense", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_sparse2dense(double* res, double* mat, int nr, int nc, int* rownnz, int* rowadr, int* colind);

		/// <summary>
		/// Convert lower-triangular symmetric CSR matrix to full dense matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sym2dense", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_sym2dense(double* res, double* mat, int n, int* rownnz, int* rowadr, int* colind);

		/// <summary>
		/// Rotate vector by quaternion.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_rotVecQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_rotVecQuat(double res, double vec, double quat);

		/// <summary>
		/// Conjugate quaternion, corresponding to opposite rotation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_negQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_negQuat(double res, double quat);

		/// <summary>
		/// Multiply quaternions.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulQuat(double res, double quat1, double quat2);

		/// <summary>
		/// Multiply quaternion and axis.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulQuatAxis", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulQuatAxis(double res, double quat, double axis);

		/// <summary>
		/// Convert axisAngle to quaternion.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_axisAngle2Quat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_axisAngle2Quat(double res, double axis, double angle);

		/// <summary>
		/// Convert quaternion (corresponding to orientation difference) to 3D velocity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_quat2Vel", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_quat2Vel(double res, double quat, double dt);

		/// <summary>
		/// Subtract quaternions, express as 3D velocity: qb*quat(res) = qa.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_subQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_subQuat(double res, double qa, double qb);

		/// <summary>
		/// Convert quaternion to 3D rotation matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_quat2Mat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_quat2Mat(double res, double quat);

		/// <summary>
		/// Convert 3D rotation matrix to quaternion.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mat2Quat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mat2Quat(double quat, double mat);

		/// <summary>
		/// Compute time-derivative of quaternion, given 3D rotational velocity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_derivQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_derivQuat(double res, double quat, double vel);

		/// <summary>
		/// Integrate quaternion given 3D angular velocity.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_quatIntegrate", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_quatIntegrate(double quat, double vel, double scale);

		/// <summary>
		/// Construct quaternion performing rotation from z-axis to given vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_quatZ2Vec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_quatZ2Vec(double quat, double vec);

		/// <summary>
		/// Extract 3D rotation from an arbitrary 3x3 matrix by refining the input quaternion.
		/// Return the number of iterations required to converge.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mat2Rot", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_mat2Rot(double quat, double mat);

		/// <summary>
		/// Convert sequence of Euler angles (radians) to quaternion.
		/// seq[0,1,2] must be in 'xyzXYZ', lower/upper-case mean intrinsic/extrinsic rotations.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_euler2Quat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_euler2Quat(double quat, double euler, [MarshalAs(UnmanagedType.LPUTF8Str)] string seq);

		/// <summary>
		/// Multiply two poses.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_mulPose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_mulPose(double posres, double quatres, double pos1, double quat1, double pos2, double quat2);

		/// <summary>
		/// Conjugate pose, corresponding to the opposite spatial transformation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_negPose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_negPose(double posres, double quatres, double pos, double quat);

		/// <summary>
		/// Transform vector by pose.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_trnVecPose", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_trnVecPose(double res, double pos, double quat, double vec);

		/// <summary>
		/// Cholesky decomposition: mat = L*L'; return rank, decomposition performed in-place into mat.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cholFactor", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_cholFactor(double* mat, int n, double mindiag);

		/// <summary>
		/// Solve (mat*mat') * res = vec, where mat is a Cholesky factor.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cholSolve", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_cholSolve(double* res, double* mat, double* vec, int n);

		/// <summary>
		/// Cholesky rank-one update: L*L' +/- x*x'; return rank.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cholUpdate", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_cholUpdate(double* mat, double* x, int n, int flg_plus);

		/// <summary>
		/// Band-dense Cholesky decomposition.
		/// Return minimum value in the factorized diagonal, or 0 if rank-deficient.
		/// mat has (ntotal-ndense) x nband + ndense x ntotal elements.
		/// The first (ntotal-ndense) x nband store the band part, left of diagonal, inclusive.
		/// The second ndense x ntotal store the band part as entire dense rows.
		/// Add diagadd+diagmul*mat_ii to diagonal before factorization.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cholFactorBand", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_cholFactorBand(double* mat, int ntotal, int nband, int ndense, double diagadd, double diagmul);

		/// <summary>
		/// Solve (mat*mat')*res = vec where mat is a band-dense Cholesky factor.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_cholSolveBand", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_cholSolveBand(double* res, double* mat, double* vec, int ntotal, int nband, int ndense);

		/// <summary>
		/// Convert banded matrix to dense matrix, fill upper triangle if flg_sym&gt;0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_band2Dense", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_band2Dense(double* res, double* mat, int ntotal, int nband, int ndense, byte flg_sym);

		/// <summary>
		/// Convert dense matrix to banded matrix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_dense2Band", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_dense2Band(double* res, double* mat, int ntotal, int nband, int ndense);

		/// <summary>
		/// Multiply band-diagonal matrix with nvec vectors, include upper triangle if flg_sym&gt;0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_bandMulMatVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_bandMulMatVec(double* res, double* mat, double* vec, int ntotal, int nband, int ndense, int nvec, byte flg_sym);

		/// <summary>
		/// Address of diagonal element i in band-dense matrix representation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_bandDiag", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_bandDiag(int i, int ntotal, int nband, int ndense);

		/// <summary>
		/// Eigenvalue decomposition of symmetric 3x3 matrix, mat = eigvec * diag(eigval) * eigvec'.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_eig3", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_eig3(double eigval, double eigvec, double quat, double mat);

		/// <summary>
		/// minimize 0.5*x'*H*x + x'*g  s.t. lower
		/// &lt;
		/// = x
		/// &lt;
		/// = upper; return rank or -1 if failed
		/// inputs:
		/// n           - problem dimension
		/// H           - SPD matrix                n*n
		/// g           - bias vector               n
		/// lower       - lower bounds              n
		/// upper       - upper bounds              n
		/// res         - solution warmstart        n
		/// return value:
		/// nfree
		/// &lt;
		/// = n  - rank of unconstrained subspace, -1 if failure
		/// outputs (required):
		/// res         - solution                  n
		/// R           - subspace Cholesky factor  nfree*nfree    allocated: n*(n+7)
		/// outputs (optional):
		/// index       - set of free dimensions    nfree          allocated: n
		/// notes:
		/// the initial value of res is used to warmstart the solver
		/// R must have allocatd size n*(n+7), but only nfree*nfree values are used in output
		/// index (if given) must have allocated size n, but only nfree values are used in output
		/// only the lower triangles of H and R and are read from and written to, respectively
		/// the convenience function mju_boxQPmalloc allocates the required data structures
		/// Nullable: index, lower, upper
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_boxQP", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_boxQP(double* res, double* R, int* index, double* H, double* g, int n, double* lower, double* upper);

		/// <summary>
		/// allocate heap memory for box-constrained Quadratic Program
		/// as in mju_boxQP, index, lower, and upper are optional
		/// free all pointers with mju_free()
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_boxQPmalloc", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_boxQPmalloc(double** res, double** R, int** index, double** H, double** g, int n, double** lower, double** upper);

		/// <summary>
		/// Muscle active force, prm = (range[2], force, scale, lmin, lmax, vmax, fpmax, fvmax).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_muscleGain", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_muscleGain(double len, double vel, double lengthrange, double acc0, double prm);

		/// <summary>
		/// Muscle passive force, prm = (range[2], force, scale, lmin, lmax, vmax, fpmax, fvmax).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_muscleBias", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_muscleBias(double len, double lengthrange, double acc0, double prm);

		/// <summary>
		/// Muscle activation dynamics, prm = (tau_act, tau_deact, smoothing_width).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_muscleDynamics", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_muscleDynamics(double ctrl, double act, double prm);

		/// <summary>
		/// Convert contact force to pyramid representation.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_encodePyramid", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_encodePyramid(double* pyramid, double* force, double* mu, int dim);

		/// <summary>
		/// Convert pyramid representation to contact force.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_decodePyramid", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_decodePyramid(double* force, double* pyramid, double* mu, int dim);

		/// <summary>
		/// Integrate spring-damper analytically; return pos(dt).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_springDamper", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_springDamper(double pos0, double vel0, double Kp, double Kv, double dt);

		/// <summary>
		/// Return min(a,b) with single evaluation of a and b.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_min", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_min(double a, double b);

		/// <summary>
		/// Return max(a,b) with single evaluation of a and b.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_max", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_max(double a, double b);

		/// <summary>
		/// Clip x to the range [min, max].
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_clip", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_clip(double x, double min, double max);

		/// <summary>
		/// Return sign of x: +1, -1 or 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sign", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_sign(double x);

		/// <summary>
		/// Round x to nearest integer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_round", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_round(double x);

		/// <summary>
		/// Convert type id (mjtObj) to type name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_type2Str", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mju_type2Str(int type);

		/// <summary>
		/// Convert type name to type id (mjtObj).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_str2Type", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_str2Type([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

		/// <summary>
		/// Return human readable number of bytes using standard letter suffix.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_writeNumBytes", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mju_writeNumBytes(nuint nbytes);

		/// <summary>
		/// Construct a warning message given the warning type and info.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_warningText", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mju_warningText(int warning, nuint info);

		/// <summary>
		/// Return 1 if nan or abs(x)&gt;mjMAXVAL, 0 otherwise. Used by check functions.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_isBad", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_isBad(double x);

		/// <summary>
		/// Return 1 if all elements are 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_isZero", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_isZero(double* vec, int n);

		/// <summary>
		/// Standard normal random number generator (optional second number).
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_standardNormal", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_standardNormal(double* num2);

		/// <summary>
		/// Convert from float to mjtNum.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_f2n", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_f2n(double* res, float* vec, int n);

		/// <summary>
		/// Convert from mjtNum to float.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_n2f", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_n2f(float* res, double* vec, int n);

		/// <summary>
		/// Convert from double to mjtNum.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_d2n", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_d2n(double* res, double* vec, int n);

		/// <summary>
		/// Convert from mjtNum to double.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_n2d", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_n2d(double* res, double* vec, int n);

		/// <summary>
		/// Insertion sort, resulting list is in increasing order.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_insertionSort", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_insertionSort(double* list, int n);

		/// <summary>
		/// Integer insertion sort, resulting list is in increasing order.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_insertionSortInt", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_insertionSortInt(int* list, int n);

		/// <summary>
		/// Generate Halton sequence.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_Halton", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_Halton(int index, int @base);

		/// <summary>
		/// Call strncpy, then set dst[n-1] = 0.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_strncpy", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mju_strncpy(byte* dst, [MarshalAs(UnmanagedType.LPUTF8Str)] string src, int n);

		/// <summary>
		/// Sigmoid function over 0
		/// &lt;
		/// =x
		/// &lt;
		/// =1 using quintic polynomial.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_sigmoid", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mju_sigmoid(double x);

		/// <summary>
		/// get sdf from geom id
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjc_getSDF", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpPlugin* mjc_getSDF(mjModel* m, int id);

		/// <summary>
		/// signed distance function
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjc_distance", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mjc_distance(mjModel* m, mjData* d, mjSDF* s, double x);

		/// <summary>
		/// gradient of sdf
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjc_gradient", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjc_gradient(mjModel* m, mjData* d, mjSDF* s, double gradient, double x);

		/// <summary>
		/// Finite differenced transition matrices (control theory notation)
		/// d(x_next) = A*dx + B*du
		/// d(sensor) = C*dx + D*du
		/// required output matrix dimensions:
		/// A: (2*nv+na x 2*nv+na)
		/// B: (2*nv+na x nu)
		/// D: (nsensordata x 2*nv+na)
		/// C: (nsensordata x nu)
		/// Nullable: A, B, C, D
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjd_transitionFD", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjd_transitionFD(mjModel* m, mjData* d, double eps, byte flg_centered, double* A, double* B, double* C, double* D);

		/// <summary>
		/// Finite differenced Jacobians of (force, sensors) = mj_inverse(state, acceleration)
		/// All outputs are optional. Output dimensions (transposed w.r.t Control Theory convention):
		/// DfDq: (nv x nv)
		/// DfDv: (nv x nv)
		/// DfDa: (nv x nv)
		/// DsDq: (nv x nsensordata)
		/// DsDv: (nv x nsensordata)
		/// DsDa: (nv x nsensordata)
		/// DmDq: (nv x nC)
		/// single-letter shortcuts:
		/// inputs: q=qpos, v=qvel, a=qacc
		/// outputs: f=qfrc_inverse, s=sensordata, m=M
		/// notes:
		/// optionally computes mass matrix Jacobian DmDq
		/// flg_actuation specifies whether to subtract qfrc_actuator from qfrc_inverse
		/// Nullable: DfDq, DfDv, DfDa, DsDq, DsDv, DsDa, DmDq
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjd_inverseFD", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjd_inverseFD(mjModel* m, mjData* d, double eps, byte flg_actuation, double* DfDq, double* DfDv, double* DfDa, double* DsDq, double* DsDv, double* DsDa, double* DmDq);

		/// <summary>
		/// Derivatives of mju_subQuat.
		/// Nullable: Da, Db
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjd_subQuat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjd_subQuat(double qa, double qb, double Da, double Db);

		/// <summary>
		/// Derivatives of mju_quatIntegrate.
		/// Nullable: Dquat, Dvel, Dscale
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjd_quatIntegrate", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjd_quatIntegrate(double vel, double scale, double Dquat, double Dvel, double Dscale);

		/// <summary>
		/// Set default plugin definition.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_defaultPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_defaultPlugin(mjpPlugin* plugin);

		/// <summary>
		/// Globally register a plugin. This function is thread-safe.
		/// If an identical mjpPlugin is already registered, this function does nothing.
		/// If a non-identical mjpPlugin with the same name is already registered, an mju_error is raised.
		/// Two mjpPlugins are considered identical if all member function pointers and numbers are equal,
		/// and the name and attribute strings are all identical, however the char pointers to the strings
		/// need not be the same.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_registerPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjp_registerPlugin(mjpPlugin* plugin);

		/// <summary>
		/// Return the number of globally registered plugins.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_pluginCount", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjp_pluginCount();

		/// <summary>
		/// Look up a plugin by name. If slot is not NULL, also write its registered slot number into it.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_getPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpPlugin* mjp_getPlugin([MarshalAs(UnmanagedType.LPUTF8Str)] string name, int* slot);

		/// <summary>
		/// Look up a plugin by the registered slot number that was returned by mjp_registerPlugin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_getPluginAtSlot", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpPlugin* mjp_getPluginAtSlot(int slot);

		/// <summary>
		/// Set default resource provider definition.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_defaultResourceProvider", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_defaultResourceProvider(mjpResourceProvider* provider);

		/// <summary>
		/// Globally register a resource provider in a thread-safe manner. The provider must have a prefix
		/// that is not a sub-prefix or super-prefix of any current registered providers.
		/// Return a slot number &gt;= 0 on success, -1 on failure.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_registerResourceProvider", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjp_registerResourceProvider(mjpResourceProvider* provider);

		/// <summary>
		/// Return the number of globally registered resource providers.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_resourceProviderCount", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjp_resourceProviderCount();

		/// <summary>
		/// Return the resource provider with the prefix that matches against the resource name.
		/// If no match, return NULL.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_getResourceProvider", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpResourceProvider* mjp_getResourceProvider([MarshalAs(UnmanagedType.LPUTF8Str)] string resource_name);

		/// <summary>
		/// Look up a resource provider by slot number returned by mjp_registerResourceProvider.
		/// If invalid slot number, return NULL.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_getResourceProviderAtSlot", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpResourceProvider* mjp_getResourceProviderAtSlot(int slot);

		/// <summary>
		/// Globally register a decoder. This function is thread-safe.
		/// If an identical mjpDecoder is already registered, this function does nothing.
		/// If a non-identical mjpDecoder with the same name is already registered, an mju_error is raised.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_registerDecoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_registerDecoder(mjpDecoder* decoder);

		/// <summary>
		/// Set default resource decoder definition.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_defaultDecoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_defaultDecoder(mjpDecoder* decoder);

		/// <summary>
		/// Return the resource provider with the prefix that matches against the resource name.
		/// If no match, return NULL.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_findDecoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpDecoder* mjp_findDecoder(mjResource* resource, [MarshalAs(UnmanagedType.LPUTF8Str)] string content_type);

		/// <summary>
		/// Globally register an encoder. This function is thread-safe.
		/// If an identical mjpEncoder is already registered, this function does nothing.
		/// If a non-identical mjpEncoder with the same name is already registered, an mju_error is raised.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_registerEncoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_registerEncoder(mjpEncoder* encoder);

		/// <summary>
		/// Set default resource encoder definition.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_defaultEncoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjp_defaultEncoder(mjpEncoder* encoder);

		/// <summary>
		/// Return the encoder that matches against the content type or filename extension.
		/// If no match, return NULL.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjp_findEncoder", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjpEncoder* mjp_findEncoder([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string content_type);

		/// <summary>
		/// Open a resource; if the name doesn't have a prefix matching a registered resource provider,
		/// then the OS filesystem is used.
		/// Nullable: dir, vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_openResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjResource* mju_openResource([MarshalAs(UnmanagedType.LPUTF8Str)] string dir, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, mjVFS* vfs, byte* error, nuint nerror);

		/// <summary>
		/// Close a resource; no-op if resource is NULL.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_closeResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_closeResource(mjResource* resource);

		/// <summary>
		/// Set buffer to bytes read from the resource and return number of bytes in buffer;
		/// return negative value if error.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_readResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_readResource(mjResource* resource, void** buffer);

		/// <summary>
		/// Write resource data via its resource provider, return bytes written or -1 on error.
		/// Nullable: vfs, error
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_writeResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern long mju_writeResource([MarshalAs(UnmanagedType.LPUTF8Str)] string name, void* buffer, long nbytes, mjVFS* vfs, byte* error, nuint nerror);

		/// <summary>
		/// For a resource with a name partitioned as {dir}{filename}, get the dir and ndir pointers.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_getResourceDir", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_getResourceDir(mjResource* resource, byte** dir, int* ndir);

		/// <summary>
		/// Compare resource timestamp to provided timestamp.
		/// Return 0 if timestamps match, &gt;0 if resource is newer,
		/// &lt;
		/// 0 if resource is older.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_isModifiedResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mju_isModifiedResource(mjResource* resource, [MarshalAs(UnmanagedType.LPUTF8Str)] string timestamp);

		/// <summary>
		/// Find the decoder for a resource and return the decoded spec.
		/// The caller takes ownership of the spec and is responsible for cleaning it up.
		/// Nullable: vfs
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_decodeResource", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mju_decodeResource(mjResource* resource, [MarshalAs(UnmanagedType.LPUTF8Str)] string content_type, mjVFS* vfs);

		/// <summary>
		/// Create a thread pool with nthread worker threads.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mju_threadpool", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mju_threadpool(mjData* d, int nthread);

		/// <summary>
		/// Attach child to a parent; return the attached element if success or NULL otherwise.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_attach", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_attach(mjsElement* parent, mjsElement* child, [MarshalAs(UnmanagedType.LPUTF8Str)] string prefix, [MarshalAs(UnmanagedType.LPUTF8Str)] string suffix);

		/// <summary>
		/// Add child body to body; return child.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addBody", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsBody* mjs_addBody(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add site to body; return site spec.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSite* mjs_addSite(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add joint to body.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addJoint", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsJoint* mjs_addJoint(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add freejoint to body.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addFreeJoint", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsJoint* mjs_addFreeJoint(mjsBody* body);

		/// <summary>
		/// Add geom to body.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsGeom* mjs_addGeom(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add camera to body.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsCamera* mjs_addCamera(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add light to body.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addLight", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsLight* mjs_addLight(mjsBody* body, mjsDefault* def);

		/// <summary>
		/// Add frame to body.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFrame* mjs_addFrame(mjsBody* body, mjsFrame* parentframe);

		/// <summary>
		/// Remove object corresponding to the given element; return 0 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_delete", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_delete(mjSpec* spec, mjsElement* element);

		/// <summary>
		/// Add actuator.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addActuator", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsActuator* mjs_addActuator(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Add sensor.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addSensor", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSensor* mjs_addSensor(mjSpec* s);

		/// <summary>
		/// Add flex.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addFlex", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFlex* mjs_addFlex(mjSpec* s);

		/// <summary>
		/// Add flexcomp: create flex with auto-generated bodies/joints, return flex spec.
		/// Nullable: type, dof, count, cellcount, spacing, scale, pos, quat, origin, file, vfs
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_makeFlex", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFlex* mjs_makeFlex(mjsBody* body, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string type, int dim, [MarshalAs(UnmanagedType.LPUTF8Str)] string dof, int count, int cellcount, double spacing, double scale, double radius, double mass, double inertiabox, int equality, int rigid, int flatskin, int elastic2d, double pos, double quat, double origin, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, mjVFS* vfs);

		/// <summary>
		/// Add contact pair.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addPair", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsPair* mjs_addPair(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Add excluded body pair.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addExclude", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsExclude* mjs_addExclude(mjSpec* s);

		/// <summary>
		/// Add equality.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addEquality", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsEquality* mjs_addEquality(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Add tendon.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addTendon", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTendon* mjs_addTendon(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Wrap site using tendon.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_wrapSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsWrap* mjs_wrapSite(mjsTendon* tendon, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Wrap geom using tendon.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_wrapGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsWrap* mjs_wrapGeom(mjsTendon* tendon, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string sidesite);

		/// <summary>
		/// Wrap joint using tendon.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_wrapJoint", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsWrap* mjs_wrapJoint(mjsTendon* tendon, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, double coef);

		/// <summary>
		/// Wrap pulley using tendon.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_wrapPulley", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsWrap* mjs_wrapPulley(mjsTendon* tendon, double divisor);

		/// <summary>
		/// Add numeric.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addNumeric", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsNumeric* mjs_addNumeric(mjSpec* s);

		/// <summary>
		/// Add text.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addText", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsText* mjs_addText(mjSpec* s);

		/// <summary>
		/// Add tuple.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addTuple", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTuple* mjs_addTuple(mjSpec* s);

		/// <summary>
		/// Add keyframe.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addKey", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsKey* mjs_addKey(mjSpec* s);

		/// <summary>
		/// Add plugin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsPlugin* mjs_addPlugin(mjSpec* s);

		/// <summary>
		/// Add default.
		/// Nullable: parent
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addDefault", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsDefault* mjs_addDefault(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string classname, mjsDefault* parent);

		/// <summary>
		/// Set actuator to motor; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToMotor", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToMotor(mjsActuator* actuator);

		/// <summary>
		/// Set actuator to position; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToPosition", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToPosition(mjsActuator* actuator, double kp, double kv, double dampratio, double timeconst, double inheritrange);

		/// <summary>
		/// Set actuator to integrated velocity; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToIntVelocity", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToIntVelocity(mjsActuator* actuator, double kp, double kv, double dampratio, double timeconst, double inheritrange);

		/// <summary>
		/// Set actuator to velocity servo; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToVelocity", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToVelocity(mjsActuator* actuator, double kv);

		/// <summary>
		/// Set actuator to orientation servo.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToOrientation", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToOrientation(mjsActuator* actuator, double kp, double kv, double dampratio, int ctrlspec);

		/// <summary>
		/// Set actuator to activate damper; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToDamper", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToDamper(mjsActuator* actuator, double kv);

		/// <summary>
		/// Set actuator to hydraulic or pneumatic cylinder; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToCylinder", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToCylinder(mjsActuator* actuator, double timeconst, double bias, double area, double diameter);

		/// <summary>
		/// Set actuator to muscle; return error if any.a
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToMuscle", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToMuscle(mjsActuator* actuator, double timeconst, double tausmooth, double range, double force, double scale, double lmin, double lmax, double vmax, double fpmax, double fvmax);

		/// <summary>
		/// Set actuator to active adhesion; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToAdhesion", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToAdhesion(mjsActuator* actuator, double gain);

		/// <summary>
		/// Set actuator to DC motor; return error if any.
		/// Nullable: motorconst, nominal, saturation, inductance, cogging, controller, thermal, lugre
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setToDCMotor", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_setToDCMotor(mjsActuator* actuator, double motorconst, double resistance, double nominal, double saturation, double inductance, double cogging, double controller, double thermal, double lugre, int input_mode);

		/// <summary>
		/// Add mesh.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsMesh* mjs_addMesh(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Add height field.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addHField", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsHField* mjs_addHField(mjSpec* s);

		/// <summary>
		/// Add skin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addSkin", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSkin* mjs_addSkin(mjSpec* s);

		/// <summary>
		/// Add texture.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addTexture", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTexture* mjs_addTexture(mjSpec* s);

		/// <summary>
		/// Add material.
		/// Nullable: def
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_addMaterial", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsMaterial* mjs_addMaterial(mjSpec* s, mjsDefault* def);

		/// <summary>
		/// Sets the vertices and normals of a mesh.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_makeMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_makeMesh(mjsMesh* mesh, mjtMeshBuiltin builtin, double* @params, int nparams);

		/// <summary>
		/// Get spec from body.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mjs_getSpec(mjsElement* element);

		/// <summary>
		/// get spec that originally defined an element
		/// contrary to mjs_getSpec, this does not change after attachment
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getOriginSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mjs_getOriginSpec(mjsElement* element);

		/// <summary>
		/// Get compiler associated with element's origin spec.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getCompiler", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsCompiler* mjs_getCompiler(mjsElement* element);

		/// <summary>
		/// Find spec (model asset) by name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjSpec* mjs_findSpec(mjSpec* spec, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Find body in spec by name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findBody", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsBody* mjs_findBody(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Find element in spec by name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findElement", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_findElement(mjSpec* s, mjtObj type, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Find child body by name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findChild", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsBody* mjs_findChild(mjsBody* body, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Get parent body.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getParent", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsBody* mjs_getParent(mjsElement* element);

		/// <summary>
		/// Get parent frame.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFrame* mjs_getFrame(mjsElement* element);

		/// <summary>
		/// Find frame by name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFrame* mjs_findFrame(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Get default corresponding to an element.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getDefault", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsDefault* mjs_getDefault(mjsElement* element);

		/// <summary>
		/// Find default in model by class name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_findDefault", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsDefault* mjs_findDefault(mjSpec* s, [MarshalAs(UnmanagedType.LPUTF8Str)] string classname);

		/// <summary>
		/// Get global default from model.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getSpecDefault", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsDefault* mjs_getSpecDefault(mjSpec* s);

		/// <summary>
		/// Get element id.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getId", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_getId(mjsElement* element);

		/// <summary>
		/// Return body's first child of given type. If recurse is nonzero, also search the body's subtree.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_firstChild", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_firstChild(mjsBody* body, mjtObj type, int recurse);

		/// <summary>
		/// Return body's next child of the same type; return NULL if child is last.
		/// If recurse is nonzero, also search the body's subtree.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_nextChild", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_nextChild(mjsBody* body, mjsElement* child, int recurse);

		/// <summary>
		/// Return spec's first element of selected type.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_firstElement", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_firstElement(mjSpec* s, mjtObj type);

		/// <summary>
		/// Return spec's next element; return NULL if element is last.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_nextElement", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_nextElement(mjSpec* s, mjsElement* element);

		/// <summary>
		/// Get wrapped element in tendon path.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrapTarget", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsElement* mjs_getWrapTarget(mjsWrap* wrap);

		/// <summary>
		/// Get wrapped element side site in tendon path if it has one, nullptr otherwise.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrapSideSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSite* mjs_getWrapSideSite(mjsWrap* wrap);

		/// <summary>
		/// Get divisor of mjsWrap wrapping a puller.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrapDivisor", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mjs_getWrapDivisor(mjsWrap* wrap);

		/// <summary>
		/// Get coefficient of mjsWrap wrapping a joint.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrapCoef", CallingConvention = CallingConvention.Cdecl)]
		public static extern double mjs_getWrapCoef(mjsWrap* wrap);

		/// <summary>
		/// Set element's name; return 0 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setName", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_setName(mjsElement* element, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

		/// <summary>
		/// Copy buffer.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setBuffer", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setBuffer(void* dest, void* array, int size);

		/// <summary>
		/// Copy text to string.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setString", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setString(void* dest, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

		/// <summary>
		/// Split text to entries and copy to string vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setStringVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setStringVec(void* dest, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

		/// <summary>
		/// Set entry in string vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setInStringVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte mjs_setInStringVec(void* dest, int i, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

		/// <summary>
		/// Append text entry to string vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_appendString", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_appendString(void* dest, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

		/// <summary>
		/// Copy int array to vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setInt", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setInt(void* dest, int* array, int size);

		/// <summary>
		/// Append int array to vector of arrays.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_appendIntVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_appendIntVec(void* dest, int* array, int size);

		/// <summary>
		/// Copy float array to vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setFloat", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setFloat(void* dest, float* array, int size);

		/// <summary>
		/// Append float array to vector of arrays.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_appendFloatVec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_appendFloatVec(void* dest, float* array, int size);

		/// <summary>
		/// Copy double array to vector.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setDouble", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setDouble(void* dest, double* array, int size);

		/// <summary>
		/// Set plugin attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setPluginAttributes", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setPluginAttributes(mjsPlugin* plugin, void* attributes);

		/// <summary>
		/// Get element's name.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getName", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* mjs_getName(mjsElement* element);

		/// <summary>
		/// Get string contents.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getString", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_getString(void* source);

		/// <summary>
		/// Get double array contents and optionally its size.
		/// Nullable: size
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getDouble", CallingConvention = CallingConvention.Cdecl)]
		public static extern double* mjs_getDouble(void* source, int* size);

		/// <summary>
		/// Get number of elements a tendon wraps.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrapNum", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_getWrapNum(mjsTendon* tendonspec);

		/// <summary>
		/// Get mjsWrap element at position i in the tendon path.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getWrap", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsWrap* mjs_getWrap(mjsTendon* tendonspec, int i);

		/// <summary>
		/// Get plugin attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getPluginAttributes", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* mjs_getPluginAttributes(mjsPlugin* plugin);

		/// <summary>
		/// Set element's default.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setDefault", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setDefault(mjsElement* element, mjsDefault* def);

		/// <summary>
		/// Set element's enclosing frame; return 0 on success.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_setFrame(mjsElement* dest, mjsFrame* frame);

		/// <summary>
		/// Resolve alternative orientations to quat; return error if any.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_resolveOrientation", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte* mjs_resolveOrientation(double quat, byte degree, [MarshalAs(UnmanagedType.LPUTF8Str)] string sequence, mjsOrientation* orientation);

		/// <summary>
		/// Transform body into a frame.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_bodyToFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFrame* mjs_bodyToFrame(mjsBody** body);

		/// <summary>
		/// Set user payload, overriding the existing value for the specified key if present.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setUserValue", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setUserValue(mjsElement* element, [MarshalAs(UnmanagedType.LPUTF8Str)] string key, void* data);

		/// <summary>
		/// Set user payload, overriding the existing value for the specified key if
		/// present. This version differs from mjs_setUserValue in that it takes a
		/// cleanup function that will be called when the user payload is deleted.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_setUserValueWithCleanup", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_setUserValueWithCleanup(mjsElement* element, [MarshalAs(UnmanagedType.LPUTF8Str)] string key, void* data, delegate* unmanaged[Cdecl]<void*, void> cleanup);

		/// <summary>
		/// Return user payload or NULL if none found.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_getUserValue", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* mjs_getUserValue(mjsElement* element, [MarshalAs(UnmanagedType.LPUTF8Str)] string key);

		/// <summary>
		/// Delete user payload.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_deleteUserValue", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_deleteUserValue(mjsElement* element, [MarshalAs(UnmanagedType.LPUTF8Str)] string key);

		/// <summary>
		/// Return sensor dimension.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_sensorDim", CallingConvention = CallingConvention.Cdecl)]
		public static extern int mjs_sensorDim(mjsSensor* sensor);

		/// <summary>
		/// Default spec attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultSpec", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultSpec(mjSpec* spec);

		/// <summary>
		/// Default orientation attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultOrientation", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultOrientation(mjsOrientation* orient);

		/// <summary>
		/// Default body attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultBody", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultBody(mjsBody* body);

		/// <summary>
		/// Default frame attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultFrame(mjsFrame* frame);

		/// <summary>
		/// Default joint attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultJoint", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultJoint(mjsJoint* joint);

		/// <summary>
		/// Default geom attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultGeom(mjsGeom* geom);

		/// <summary>
		/// Default site attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultSite(mjsSite* site);

		/// <summary>
		/// Default camera attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultCamera(mjsCamera* camera);

		/// <summary>
		/// Default light attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultLight", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultLight(mjsLight* light);

		/// <summary>
		/// Default flex attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultFlex", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultFlex(mjsFlex* flex);

		/// <summary>
		/// Default mesh attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultMesh(mjsMesh* mesh);

		/// <summary>
		/// Default height field attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultHField", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultHField(mjsHField* hfield);

		/// <summary>
		/// Default skin attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultSkin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultSkin(mjsSkin* skin);

		/// <summary>
		/// Default texture attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultTexture", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultTexture(mjsTexture* texture);

		/// <summary>
		/// Default material attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultMaterial", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultMaterial(mjsMaterial* material);

		/// <summary>
		/// Default pair attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultPair", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultPair(mjsPair* pair);

		/// <summary>
		/// Default equality attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultEquality", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultEquality(mjsEquality* equality);

		/// <summary>
		/// Default tendon attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultTendon", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultTendon(mjsTendon* tendon);

		/// <summary>
		/// Default actuator attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultActuator", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultActuator(mjsActuator* actuator);

		/// <summary>
		/// Default sensor attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultSensor", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultSensor(mjsSensor* sensor);

		/// <summary>
		/// Default numeric attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultNumeric", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultNumeric(mjsNumeric* numeric);

		/// <summary>
		/// Default text attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultText", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultText(mjsText* text);

		/// <summary>
		/// Default tuple attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultTuple", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultTuple(mjsTuple* tuple);

		/// <summary>
		/// Default keyframe attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultKey", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultKey(mjsKey* key);

		/// <summary>
		/// Default plugin attributes.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_defaultPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void mjs_defaultPlugin(mjsPlugin* plugin);

		/// <summary>
		/// Safely cast an element as mjsBody, or return NULL if the element is not an mjsBody.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asBody", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsBody* mjs_asBody(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsGeom, or return NULL if the element is not an mjsGeom.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asGeom", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsGeom* mjs_asGeom(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsJoint, or return NULL if the element is not an mjsJoint.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asJoint", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsJoint* mjs_asJoint(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsSite, or return NULL if the element is not an mjsSite.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asSite", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSite* mjs_asSite(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsCamera, or return NULL if the element is not an mjsCamera.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asCamera", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsCamera* mjs_asCamera(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsLight, or return NULL if the element is not an mjsLight.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asLight", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsLight* mjs_asLight(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsFrame, or return NULL if the element is not an mjsFrame.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFrame* mjs_asFrame(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsActuator, or return NULL if the element is not an mjsActuator.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asActuator", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsActuator* mjs_asActuator(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsSensor, or return NULL if the element is not an mjsSensor.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asSensor", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSensor* mjs_asSensor(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsFlex, or return NULL if the element is not an mjsFlex.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asFlex", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsFlex* mjs_asFlex(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsPair, or return NULL if the element is not an mjsPair.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asPair", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsPair* mjs_asPair(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsEquality, or return NULL if the element is not an mjsEquality.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asEquality", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsEquality* mjs_asEquality(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsExclude, or return NULL if the element is not an mjsExclude.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asExclude", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsExclude* mjs_asExclude(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsTendon, or return NULL if the element is not an mjsTendon.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asTendon", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTendon* mjs_asTendon(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsNumeric, or return NULL if the element is not an mjsNumeric.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asNumeric", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsNumeric* mjs_asNumeric(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsText, or return NULL if the element is not an mjsText.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asText", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsText* mjs_asText(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsTuple, or return NULL if the element is not an mjsTuple.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asTuple", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTuple* mjs_asTuple(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsKey, or return NULL if the element is not an mjsKey.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asKey", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsKey* mjs_asKey(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsMesh, or return NULL if the element is not an mjsMesh.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asMesh", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsMesh* mjs_asMesh(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsHField, or return NULL if the element is not an mjsHField.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asHField", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsHField* mjs_asHField(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsSkin, or return NULL if the element is not an mjsSkin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asSkin", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsSkin* mjs_asSkin(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsTexture, or return NULL if the element is not an mjsTexture.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asTexture", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsTexture* mjs_asTexture(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsMaterial, or return NULL if the element is not an mjsMaterial.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asMaterial", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsMaterial* mjs_asMaterial(mjsElement* element);

		/// <summary>
		/// Safely cast an element as mjsPlugin, or return NULL if the element is not an mjsPlugin.
		/// </summary>
		[DllImport("mujoco", EntryPoint = "mjs_asPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern mjsPlugin* mjs_asPlugin(mjsElement* element);
	}
}
