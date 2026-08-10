using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Evergine.Bindings.MuJoCo
{

	[InlineArray(25)]
	public unsafe struct InlineArray_mjrRect_25
	{
		private mjrRect element0;
	}

	[InlineArray(4000)]
	public unsafe struct InlineArray_mjSolverStat_4000
	{
		private mjSolverStat element0;
	}

	[InlineArray(15)]
	public unsafe struct InlineArray_mjTimerStat_15
	{
		private mjTimerStat element0;
	}

	[InlineArray(200)]
	public unsafe struct InlineArray_mjuiItem_200
	{
		private mjuiItem element0;
	}

	[InlineArray(10)]
	public unsafe struct InlineArray_mjuiSection_10
	{
		private mjuiSection element0;
	}

	[InlineArray(2)]
	public unsafe struct InlineArray_mjvGLCamera_2
	{
		private mjvGLCamera element0;
	}

	[InlineArray(100)]
	public unsafe struct InlineArray_mjvLight_100
	{
		private mjvLight element0;
	}

	[InlineArray(7)]
	public unsafe struct InlineArray_mjWarningStat_7
	{
		private mjWarningStat element0;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjLogMessage
	{
		/// <summary>
		/// mjtLogLevel
		/// </summary>
		public int level;
		/// <summary>
		/// mjtLogTopic (0 for error/warning/user)
		/// </summary>
		public int topic;
		/// <summary>
		/// message subject (one-liner, printf-formatted)
		/// </summary>
		public fixed byte subject[1024];
		/// <summary>
		/// message body (multi-line detail, or NULL)
		/// </summary>
		public byte* body;
		/// <summary>
		/// __func__ or NULL
		/// </summary>
		public byte* func;
		/// <summary>
		/// __FILE__ or NULL
		/// </summary>
		public byte* file;
		/// <summary>
		/// __LINE__ or 0
		/// </summary>
		public int line;
		/// <summary>
		/// prepend timestamp to output
		/// </summary>
		public byte timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjLogConfig
	{
		/// <summary>
		/// print to console (default: true)
		/// </summary>
		public byte logto_console;
		/// <summary>
		/// print to log file (default: true)
		/// </summary>
		public byte logto_file;
		/// <summary>
		/// log file path (default: "MUJOCO_LOG.TXT")
		/// </summary>
		public fixed byte logfile[1024];
		/// <summary>
		/// enabled info topic bitmask (default: 0)
		/// </summary>
		public int topics;
	}

	/// <summary>
	/// ---------------------------------- mjLROpt -------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjLROpt
	{
		/// <summary>
		/// which actuators to process (mjtLRMode)
		/// </summary>
		public int mode;
		/// <summary>
		/// use existing length range if available
		/// </summary>
		public int useexisting;
		/// <summary>
		/// use joint and tendon limits if available
		/// </summary>
		public int uselimit;
		/// <summary>
		/// target acceleration used to compute force
		/// </summary>
		public double accel;
		/// <summary>
		/// maximum force; 0: no limit
		/// </summary>
		public double maxforce;
		/// <summary>
		/// time constant for velocity reduction; min 0.01
		/// </summary>
		public double timeconst;
		/// <summary>
		/// simulation timestep; 0: use mjOption.timestep
		/// </summary>
		public double timestep;
		/// <summary>
		/// total simulation time interval
		/// </summary>
		public double inttotal;
		/// <summary>
		/// evaluation time interval (at the end)
		/// </summary>
		public double interval;
		/// <summary>
		/// convergence tolerance (relative to range)
		/// </summary>
		public double tolrange;
	}

	/// <summary>
	/// ---------------------------------- mjCache -------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjCache
	{
		/// <summary>
		/// internal pointer to cache
		/// </summary>
		public void* impl_;
	}

	/// <summary>
	/// ---------------------------------- mjVFS ---------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVFS
	{
		/// <summary>
		/// internal pointer to VFS memory
		/// </summary>
		public void* impl_;
	}

	/// <summary>
	/// ---------------------------------- mjOption ------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjOption
	{
		/// <summary>
		/// timestep
		/// </summary>
		public double timestep;
		/// <summary>
		/// ratio of friction-to-normal contact impedance
		/// </summary>
		public double impratio;
		/// <summary>
		/// main solver tolerance
		/// </summary>
		public double tolerance;
		/// <summary>
		/// CG/Newton linesearch tolerance
		/// </summary>
		public double ls_tolerance;
		/// <summary>
		/// noslip solver tolerance
		/// </summary>
		public double noslip_tolerance;
		/// <summary>
		/// convex collision solver tolerance
		/// </summary>
		public double ccd_tolerance;
		/// <summary>
		/// sleep velocity tolerance
		/// </summary>
		public double sleep_tolerance;
		/// <summary>
		/// gravitational acceleration
		/// </summary>
		public fixed double gravity[3];
		/// <summary>
		/// wind (for lift, drag and viscosity)
		/// </summary>
		public fixed double wind[3];
		/// <summary>
		/// global magnetic flux
		/// </summary>
		public fixed double magnetic[3];
		/// <summary>
		/// density of medium
		/// </summary>
		public double density;
		/// <summary>
		/// viscosity of medium
		/// </summary>
		public double viscosity;
		/// <summary>
		/// margin
		/// </summary>
		public double o_margin;
		/// <summary>
		/// solref
		/// </summary>
		public fixed double o_solref[2];
		/// <summary>
		/// solimp
		/// </summary>
		public fixed double o_solimp[5];
		/// <summary>
		/// friction
		/// </summary>
		public fixed double o_friction[5];
		/// <summary>
		/// integration mode (mjtIntegrator)
		/// </summary>
		public int integrator;
		/// <summary>
		/// type of friction cone (mjtCone)
		/// </summary>
		public int cone;
		/// <summary>
		/// type of Jacobian (mjtJacobian)
		/// </summary>
		public int jacobian;
		/// <summary>
		/// solver algorithm (mjtSolver)
		/// </summary>
		public int solver;
		/// <summary>
		/// maximum number of main solver iterations
		/// </summary>
		public int iterations;
		/// <summary>
		/// maximum number of CG/Newton linesearch iterations
		/// </summary>
		public int ls_iterations;
		/// <summary>
		/// maximum number of noslip solver iterations
		/// </summary>
		public int noslip_iterations;
		/// <summary>
		/// maximum number of convex collision solver iterations
		/// </summary>
		public int ccd_iterations;
		/// <summary>
		/// bit flags for disabling standard features
		/// </summary>
		public int disableflags;
		/// <summary>
		/// bit flags for enabling optional features
		/// </summary>
		public int enableflags;
		/// <summary>
		/// bit flags for disabling actuators by group id
		/// </summary>
		public int disableactuator;
		/// <summary>
		/// number of starting points for gradient descent
		/// </summary>
		public int sdf_initpoints;
		/// <summary>
		/// max number of iterations for gradient descent
		/// </summary>
		public int sdf_iterations;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_global
	{
		/// <summary>
		/// initial camera id (-1: free)
		/// </summary>
		public int cameraid;
		/// <summary>
		/// is the free camera orthographic (0: no, 1: yes)
		/// </summary>
		public int orthographic;
		/// <summary>
		/// y field-of-view of free camera (orthographic ? length : degree)
		/// </summary>
		public float fovy;
		/// <summary>
		/// inter-pupilary distance for free camera
		/// </summary>
		public float ipd;
		/// <summary>
		/// initial azimuth of free camera (degrees)
		/// </summary>
		public float azimuth;
		/// <summary>
		/// initial elevation of free camera (degrees)
		/// </summary>
		public float elevation;
		/// <summary>
		/// line width for wireframe and ray rendering
		/// </summary>
		public float linewidth;
		/// <summary>
		/// glow coefficient for selected body
		/// </summary>
		public float glow;
		/// <summary>
		/// initial real-time factor (1: real time)
		/// </summary>
		public float realtime;
		/// <summary>
		/// width of offscreen buffer
		/// </summary>
		public int offwidth;
		/// <summary>
		/// height of offscreen buffer
		/// </summary>
		public int offheight;
		/// <summary>
		/// geom for inertia visualization (0: box, 1: ellipsoid)
		/// </summary>
		public int ellipsoidinertia;
		/// <summary>
		/// visualize active bounding volumes (0: no, 1: yes)
		/// </summary>
		public int bvactive;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_quality
	{
		/// <summary>
		/// size of shadowmap texture
		/// </summary>
		public int shadowsize;
		/// <summary>
		/// number of multisamples for offscreen rendering
		/// </summary>
		public int offsamples;
		/// <summary>
		/// number of slices for builtin geom drawing
		/// </summary>
		public int numslices;
		/// <summary>
		/// number of stacks for builtin geom drawing
		/// </summary>
		public int numstacks;
		/// <summary>
		/// number of quads for box rendering
		/// </summary>
		public int numquads;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_headlight
	{
		/// <summary>
		/// ambient rgb (alpha=1)
		/// </summary>
		public fixed float ambient[3];
		/// <summary>
		/// diffuse rgb (alpha=1)
		/// </summary>
		public fixed float diffuse[3];
		/// <summary>
		/// specular rgb (alpha=1)
		/// </summary>
		public fixed float specular[3];
		/// <summary>
		/// is headlight active
		/// </summary>
		public int active;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_map
	{
		/// <summary>
		/// mouse perturbation stiffness (space-&gt;force)
		/// </summary>
		public float stiffness;
		/// <summary>
		/// mouse perturbation stiffness (space-&gt;torque)
		/// </summary>
		public float stiffnessrot;
		/// <summary>
		/// from force units to space units
		/// </summary>
		public float force;
		/// <summary>
		/// from torque units to space units
		/// </summary>
		public float torque;
		/// <summary>
		/// scale geom alphas when transparency is enabled
		/// </summary>
		public float alpha;
		/// <summary>
		/// OpenGL fog starts at fogstart * mjModel.stat.extent
		/// </summary>
		public float fogstart;
		/// <summary>
		/// OpenGL fog ends at fogend * mjModel.stat.extent
		/// </summary>
		public float fogend;
		/// <summary>
		/// near clipping plane = znear * mjModel.stat.extent
		/// </summary>
		public float znear;
		/// <summary>
		/// far clipping plane = zfar * mjModel.stat.extent
		/// </summary>
		public float zfar;
		/// <summary>
		/// haze ratio
		/// </summary>
		public float haze;
		/// <summary>
		/// directional light: shadowclip * mjModel.stat.extent
		/// </summary>
		public float shadowclip;
		/// <summary>
		/// spot light: shadowscale * light.cutoff
		/// </summary>
		public float shadowscale;
		/// <summary>
		/// scale tendon width
		/// </summary>
		public float actuatortendon;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_scale
	{
		/// <summary>
		/// width of force arrow
		/// </summary>
		public float forcewidth;
		/// <summary>
		/// contact width
		/// </summary>
		public float contactwidth;
		/// <summary>
		/// contact height
		/// </summary>
		public float contactheight;
		/// <summary>
		/// autoconnect capsule width
		/// </summary>
		public float connect;
		/// <summary>
		/// com radius
		/// </summary>
		public float com;
		/// <summary>
		/// camera object
		/// </summary>
		public float camera;
		/// <summary>
		/// light object
		/// </summary>
		public float light;
		/// <summary>
		/// selection point
		/// </summary>
		public float selectpoint;
		/// <summary>
		/// joint length
		/// </summary>
		public float jointlength;
		/// <summary>
		/// joint width
		/// </summary>
		public float jointwidth;
		/// <summary>
		/// actuator length
		/// </summary>
		public float actuatorlength;
		/// <summary>
		/// actuator width
		/// </summary>
		public float actuatorwidth;
		/// <summary>
		/// bodyframe axis length
		/// </summary>
		public float framelength;
		/// <summary>
		/// bodyframe axis width
		/// </summary>
		public float framewidth;
		/// <summary>
		/// constraint width
		/// </summary>
		public float constraint;
		/// <summary>
		/// slidercrank width
		/// </summary>
		public float slidercrank;
		/// <summary>
		/// frustum zfar plane
		/// </summary>
		public float frustum;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual_rgba
	{
		/// <summary>
		/// fog
		/// </summary>
		public fixed float fog[4];
		/// <summary>
		/// haze
		/// </summary>
		public fixed float haze[4];
		/// <summary>
		/// external force
		/// </summary>
		public fixed float force[4];
		/// <summary>
		/// inertia box
		/// </summary>
		public fixed float inertia[4];
		/// <summary>
		/// joint
		/// </summary>
		public fixed float joint[4];
		/// <summary>
		/// actuator, neutral
		/// </summary>
		public fixed float actuator[4];
		/// <summary>
		/// actuator, negative limit
		/// </summary>
		public fixed float actuatornegative[4];
		/// <summary>
		/// actuator, positive limit
		/// </summary>
		public fixed float actuatorpositive[4];
		/// <summary>
		/// center of mass
		/// </summary>
		public fixed float com[4];
		/// <summary>
		/// camera object
		/// </summary>
		public fixed float camera[4];
		/// <summary>
		/// light object
		/// </summary>
		public fixed float light[4];
		/// <summary>
		/// selection point
		/// </summary>
		public fixed float selectpoint[4];
		/// <summary>
		/// auto connect
		/// </summary>
		public fixed float connect[4];
		/// <summary>
		/// contact point
		/// </summary>
		public fixed float contactpoint[4];
		/// <summary>
		/// contact force
		/// </summary>
		public fixed float contactforce[4];
		/// <summary>
		/// contact friction force
		/// </summary>
		public fixed float contactfriction[4];
		/// <summary>
		/// contact torque
		/// </summary>
		public fixed float contacttorque[4];
		/// <summary>
		/// contact point in gap
		/// </summary>
		public fixed float contactgap[4];
		/// <summary>
		/// rangefinder ray
		/// </summary>
		public fixed float rangefinder[4];
		/// <summary>
		/// constraint
		/// </summary>
		public fixed float constraint[4];
		/// <summary>
		/// slidercrank
		/// </summary>
		public fixed float slidercrank[4];
		/// <summary>
		/// used when crank must be stretched/broken
		/// </summary>
		public fixed float crankbroken[4];
		/// <summary>
		/// camera frustum
		/// </summary>
		public fixed float frustum[4];
		/// <summary>
		/// bounding volume
		/// </summary>
		public fixed float bv[4];
		/// <summary>
		/// active bounding volume
		/// </summary>
		public fixed float bvactive[4];
	}

	/// <summary>
	/// ---------------------------------- mjVisual ------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjVisual
	{
		public mjVisual_global global;
		public mjVisual_quality quality;
		public mjVisual_headlight headlight;
		public mjVisual_map map;
		public mjVisual_scale scale;
		public mjVisual_rgba rgba;
	}

	/// <summary>
	/// ---------------------------------- mjStatistic ---------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjStatistic
	{
		/// <summary>
		/// mean diagonal inertia
		/// </summary>
		public double meaninertia;
		/// <summary>
		/// mean body mass
		/// </summary>
		public double meanmass;
		/// <summary>
		/// mean body size
		/// </summary>
		public double meansize;
		/// <summary>
		/// spatial extent
		/// </summary>
		public double extent;
		/// <summary>
		/// center of model
		/// </summary>
		public fixed double center[3];
	}

	/// <summary>
	/// ---------------------------------- mjModel -------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjModel
	{
		/// <summary>
		/// number of generalized coordinates = dim(qpos)
		/// </summary>
		public long nq;
		/// <summary>
		/// number of degrees of freedom = dim(qvel)
		/// </summary>
		public long nv;
		/// <summary>
		/// number of scalar controls = dim(ctrl)
		/// </summary>
		public long nu;
		/// <summary>
		/// number of actuators
		/// </summary>
		public long nactuator;
		/// <summary>
		/// number of force outputs, derived from transmission type
		/// </summary>
		public long nout;
		/// <summary>
		/// number of activation states = dim(act)
		/// </summary>
		public long na;
		/// <summary>
		/// number of bodies
		/// </summary>
		public long nbody;
		/// <summary>
		/// number of total bounding volumes in all bodies
		/// </summary>
		public long nbvh;
		/// <summary>
		/// number of static bounding volumes (aabb stored in mjModel)
		/// </summary>
		public long nbvhstatic;
		/// <summary>
		/// number of dynamic bounding volumes (aabb stored in mjData)
		/// </summary>
		public long nbvhdynamic;
		/// <summary>
		/// number of total octree cells in all meshes
		/// </summary>
		public long noct;
		/// <summary>
		/// number of joints
		/// </summary>
		public long njnt;
		/// <summary>
		/// number of kinematic trees under world body
		/// </summary>
		public long ntree;
		/// <summary>
		/// number of non-zeros in sparse inertia matrix
		/// </summary>
		public long nM;
		/// <summary>
		/// number of non-zeros in sparse body-dof matrix
		/// </summary>
		public long nB;
		/// <summary>
		/// number of non-zeros in sparse reduced dof-dof matrix
		/// </summary>
		public long nC;
		/// <summary>
		/// number of non-zeros in sparse dof-dof matrix
		/// </summary>
		public long nD;
		/// <summary>
		/// number of geoms
		/// </summary>
		public long ngeom;
		/// <summary>
		/// number of sites
		/// </summary>
		public long nsite;
		/// <summary>
		/// number of cameras
		/// </summary>
		public long ncam;
		/// <summary>
		/// number of lights
		/// </summary>
		public long nlight;
		/// <summary>
		/// number of flexes
		/// </summary>
		public long nflex;
		/// <summary>
		/// number of dofs in all flexes
		/// </summary>
		public long nflexnode;
		/// <summary>
		/// number of vertices in all flexes
		/// </summary>
		public long nflexvert;
		/// <summary>
		/// number of edges in all flexes
		/// </summary>
		public long nflexedge;
		/// <summary>
		/// number of elements in all flexes
		/// </summary>
		public long nflexelem;
		/// <summary>
		/// number of element vertex ids in all flexes
		/// </summary>
		public long nflexelemdata;
		/// <summary>
		/// number of stiffness parameters in all flexes
		/// </summary>
		public long nflexstiffness;
		/// <summary>
		/// number of bending parameters in all flexes
		/// </summary>
		public long nflexbending;
		/// <summary>
		/// number of dofs covered by the constant metric factor
		/// </summary>
		public long nefm0dof;
		/// <summary>
		/// number of non-zeros in the constant metric factor
		/// </summary>
		public long nefm0L;
		/// <summary>
		/// number of element edge ids in all flexes
		/// </summary>
		public long nflexelemedge;
		/// <summary>
		/// number of shell fragment vertex ids in all flexes
		/// </summary>
		public long nflexshelldata;
		/// <summary>
		/// number of element-vertex pairs in all flexes
		/// </summary>
		public long nflexevpair;
		/// <summary>
		/// number of vertices with texture coordinates
		/// </summary>
		public long nflextexcoord;
		/// <summary>
		/// number of non-zeros in sparse flexedge Jacobian matrix
		/// </summary>
		public long nJfe;
		/// <summary>
		/// number of non-zeros in sparse flexvert Jacobian matrix
		/// </summary>
		public long nJfv;
		/// <summary>
		/// number of meshes
		/// </summary>
		public long nmesh;
		/// <summary>
		/// number of vertices in all meshes
		/// </summary>
		public long nmeshvert;
		/// <summary>
		/// number of normals in all meshes
		/// </summary>
		public long nmeshnormal;
		/// <summary>
		/// number of texcoords in all meshes
		/// </summary>
		public long nmeshtexcoord;
		/// <summary>
		/// number of triangular faces in all meshes
		/// </summary>
		public long nmeshface;
		/// <summary>
		/// number of ints in mesh auxiliary data
		/// </summary>
		public long nmeshgraph;
		/// <summary>
		/// number of polygons in all meshes
		/// </summary>
		public long nmeshpoly;
		/// <summary>
		/// number of vertices in all polygons
		/// </summary>
		public long nmeshpolyvert;
		/// <summary>
		/// number of polygons in vertex map
		/// </summary>
		public long nmeshpolymap;
		/// <summary>
		/// number of skins
		/// </summary>
		public long nskin;
		/// <summary>
		/// number of vertices in all skins
		/// </summary>
		public long nskinvert;
		/// <summary>
		/// number of vertices with texcoords in all skins
		/// </summary>
		public long nskintexvert;
		/// <summary>
		/// number of triangular faces in all skins
		/// </summary>
		public long nskinface;
		/// <summary>
		/// number of bones in all skins
		/// </summary>
		public long nskinbone;
		/// <summary>
		/// number of vertices in all skin bones
		/// </summary>
		public long nskinbonevert;
		/// <summary>
		/// number of heightfields
		/// </summary>
		public long nhfield;
		/// <summary>
		/// number of data points in all heightfields
		/// </summary>
		public long nhfielddata;
		/// <summary>
		/// number of textures
		/// </summary>
		public long ntex;
		/// <summary>
		/// number of bytes in texture rgb data
		/// </summary>
		public long ntexdata;
		/// <summary>
		/// number of materials
		/// </summary>
		public long nmat;
		/// <summary>
		/// number of predefined geom pairs
		/// </summary>
		public long npair;
		/// <summary>
		/// number of excluded geom pairs
		/// </summary>
		public long nexclude;
		/// <summary>
		/// number of equality constraints
		/// </summary>
		public long neq;
		/// <summary>
		/// number of tendons
		/// </summary>
		public long ntendon;
		/// <summary>
		/// number of non-zeros in sparse ten_J matrix
		/// </summary>
		public long nJten;
		/// <summary>
		/// number of wrap objects in all tendon paths
		/// </summary>
		public long nwrap;
		/// <summary>
		/// number of sensors
		/// </summary>
		public long nsensor;
		/// <summary>
		/// number of numeric custom fields
		/// </summary>
		public long nnumeric;
		/// <summary>
		/// number of mjtNums in all numeric fields
		/// </summary>
		public long nnumericdata;
		/// <summary>
		/// number of text custom fields
		/// </summary>
		public long ntext;
		/// <summary>
		/// number of mjtBytes in all text fields
		/// </summary>
		public long ntextdata;
		/// <summary>
		/// number of tuple custom fields
		/// </summary>
		public long ntuple;
		/// <summary>
		/// number of objects in all tuple fields
		/// </summary>
		public long ntupledata;
		/// <summary>
		/// number of keyframes
		/// </summary>
		public long nkey;
		/// <summary>
		/// number of mocap bodies
		/// </summary>
		public long nmocap;
		/// <summary>
		/// number of plugin instances
		/// </summary>
		public long nplugin;
		/// <summary>
		/// number of chars in all plugin config attributes
		/// </summary>
		public long npluginattr;
		/// <summary>
		/// number of mjtNums in body_user
		/// </summary>
		public long nuser_body;
		/// <summary>
		/// number of mjtNums in jnt_user
		/// </summary>
		public long nuser_jnt;
		/// <summary>
		/// number of mjtNums in geom_user
		/// </summary>
		public long nuser_geom;
		/// <summary>
		/// number of mjtNums in site_user
		/// </summary>
		public long nuser_site;
		/// <summary>
		/// number of mjtNums in cam_user
		/// </summary>
		public long nuser_cam;
		/// <summary>
		/// number of mjtNums in tendon_user
		/// </summary>
		public long nuser_tendon;
		/// <summary>
		/// number of mjtNums in actuator_user
		/// </summary>
		public long nuser_actuator;
		/// <summary>
		/// number of mjtNums in sensor_user
		/// </summary>
		public long nuser_sensor;
		/// <summary>
		/// number of chars in all names
		/// </summary>
		public long nnames;
		/// <summary>
		/// number of chars in all paths
		/// </summary>
		public long npaths;
		/// <summary>
		/// number of slots in the names hash map
		/// </summary>
		public long nnames_map;
		/// <summary>
		/// number of non-zeros in sparse actuator_moment matrix
		/// </summary>
		public long nJmom;
		/// <summary>
		/// number of bodies with nonzero gravcomp
		/// </summary>
		public long ngravcomp;
		/// <summary>
		/// number of potential equality-constraint rows
		/// </summary>
		public long nemax;
		/// <summary>
		/// number of available rows in constraint Jacobian (legacy)
		/// </summary>
		public long njmax;
		/// <summary>
		/// number of potential contacts in contact list (legacy)
		/// </summary>
		public long nconmax;
		/// <summary>
		/// maximum number of vertices in a mesh polygon
		/// </summary>
		public long npolygonmax;
		/// <summary>
		/// maximum number of edges adjacent to a mesh vertex
		/// </summary>
		public long nmeshdegmax;
		/// <summary>
		/// number of mjtNums reserved for the user
		/// </summary>
		public long nuserdata;
		/// <summary>
		/// number of mjtNums in sensor data vector
		/// </summary>
		public long nsensordata;
		/// <summary>
		/// number of mjtNums in plugin state vector
		/// </summary>
		public long npluginstate;
		/// <summary>
		/// number of mjtNums in history buffer
		/// </summary>
		public long nhistory;
		/// <summary>
		/// number of bytes in the mjData arena (inclusive of stack)
		/// </summary>
		public long narena;
		/// <summary>
		/// number of bytes in buffer
		/// </summary>
		public long nbuffer;
		/// <summary>
		/// whether any body has nonzero gravcomp
		/// </summary>
		public byte flg_gravcomp;
		/// <summary>
		/// whether any geom has nonzero surfacevel
		/// </summary>
		public byte flg_surfacevel;
		/// <summary>
		/// whether any geom or pair has nonzero adhesion
		/// </summary>
		public byte flg_adhesion;
		/// <summary>
		/// physics options
		/// </summary>
		public mjOption opt;
		/// <summary>
		/// visualization options
		/// </summary>
		public mjVisual vis;
		/// <summary>
		/// model statistics
		/// </summary>
		public mjStatistic stat;
		/// <summary>
		/// main buffer; all pointers point in it    (nbuffer)
		/// </summary>
		public void* buffer;
		/// <summary>
		/// qpos values at default pose              (nq x 1)
		/// </summary>
		public double* qpos0;
		/// <summary>
		/// reference pose for springs               (nq x 1)
		/// </summary>
		public double* qpos_spring;
		/// <summary>
		/// id of body's parent                      (nbody x 1)
		/// </summary>
		public int* body_parentid;
		/// <summary>
		/// ancestor that is direct child of world   (nbody x 1)
		/// </summary>
		public int* body_rootid;
		/// <summary>
		/// top ancestor with no dofs to this body   (nbody x 1)
		/// </summary>
		public int* body_weldid;
		/// <summary>
		/// id of mocap data; -1: none               (nbody x 1)
		/// </summary>
		public int* body_mocapid;
		/// <summary>
		/// number of joints for this body           (nbody x 1)
		/// </summary>
		public int* body_jntnum;
		/// <summary>
		/// start addr of joints; -1: no joints      (nbody x 1)
		/// </summary>
		public int* body_jntadr;
		/// <summary>
		/// number of motion degrees of freedom      (nbody x 1)
		/// </summary>
		public int* body_dofnum;
		/// <summary>
		/// start addr of dofs; -1: no dofs          (nbody x 1)
		/// </summary>
		public int* body_dofadr;
		/// <summary>
		/// id of body's kinematic tree; -1: static  (nbody x 1)
		/// </summary>
		public int* body_treeid;
		/// <summary>
		/// number of geoms                          (nbody x 1)
		/// </summary>
		public int* body_geomnum;
		/// <summary>
		/// start addr of geoms; -1: no geoms        (nbody x 1)
		/// </summary>
		public int* body_geomadr;
		/// <summary>
		/// 1: diag M; 2: diag M, sliders only       (nbody x 1)
		/// </summary>
		public byte* body_simple;
		/// <summary>
		/// same frame as inertia (mjtSameframe)     (nbody x 1)
		/// </summary>
		public byte* body_sameframe;
		/// <summary>
		/// position offset rel. to parent body      (nbody x 3)
		/// </summary>
		public double* body_pos;
		/// <summary>
		/// orientation offset rel. to parent body   (nbody x 4)
		/// </summary>
		public double* body_quat;
		/// <summary>
		/// local position of center of mass         (nbody x 3)
		/// </summary>
		public double* body_ipos;
		/// <summary>
		/// local orientation of inertia ellipsoid   (nbody x 4)
		/// </summary>
		public double* body_iquat;
		/// <summary>
		/// mass                                     (nbody x 1)
		/// </summary>
		public double* body_mass;
		/// <summary>
		/// mass of subtree starting at this body    (nbody x 1)
		/// </summary>
		public double* body_subtreemass;
		/// <summary>
		/// diagonal inertia in ipos/iquat frame     (nbody x 3)
		/// </summary>
		public double* body_inertia;
		/// <summary>
		/// mean inv inert in qpos0 (trn, rot)       (nbody x 2)
		/// </summary>
		public double* body_invweight0;
		/// <summary>
		/// antigravity force, units of body weight  (nbody x 1)
		/// </summary>
		public double* body_gravcomp;
		/// <summary>
		/// MAX over all geom margins+gaps           (nbody x 1)
		/// </summary>
		public double* body_margin;
		/// <summary>
		/// user data                                (nbody x nuser_body)
		/// </summary>
		public double* body_user;
		/// <summary>
		/// plugin instance id; -1: not in use       (nbody x 1)
		/// </summary>
		public int* body_plugin;
		/// <summary>
		/// OR over all geom contypes                (nbody x 1)
		/// </summary>
		public int* body_contype;
		/// <summary>
		/// OR over all geom conaffinities           (nbody x 1)
		/// </summary>
		public int* body_conaffinity;
		/// <summary>
		/// address of bvh root                      (nbody x 1)
		/// </summary>
		public int* body_bvhadr;
		/// <summary>
		/// number of bounding volumes               (nbody x 1)
		/// </summary>
		public int* body_bvhnum;
		/// <summary>
		/// depth in the bounding volume hierarchy   (nbvh x 1)
		/// </summary>
		public int* bvh_depth;
		/// <summary>
		/// left and right children in tree          (nbvh x 2)
		/// </summary>
		public int* bvh_child;
		/// <summary>
		/// geom or elem id of node; -1: non-leaf    (nbvh x 1)
		/// </summary>
		public int* bvh_nodeid;
		/// <summary>
		/// local bounding box (center, size)        (nbvhstatic x 6)
		/// </summary>
		public double* bvh_aabb;
		/// <summary>
		/// depth in the octree                      (noct x 1)
		/// </summary>
		public int* oct_depth;
		/// <summary>
		/// children of octree node                  (noct x 8)
		/// </summary>
		public int* oct_child;
		/// <summary>
		/// octree node bounding box (center, size)  (noct x 6)
		/// </summary>
		public double* oct_aabb;
		/// <summary>
		/// octree interpolation coefficients        (noct x 8)
		/// </summary>
		public double* oct_coeff;
		/// <summary>
		/// type of joint (mjtJoint)                 (njnt x 1)
		/// </summary>
		public int* jnt_type;
		/// <summary>
		/// start addr in 'qpos' for joint's data    (njnt x 1)
		/// </summary>
		public int* jnt_qposadr;
		/// <summary>
		/// start addr in 'qvel' for joint's data    (njnt x 1)
		/// </summary>
		public int* jnt_dofadr;
		/// <summary>
		/// id of joint's body                       (njnt x 1)
		/// </summary>
		public int* jnt_bodyid;
		/// <summary>
		/// actuator contributing damping / armature (njnt x 1)
		/// </summary>
		public int* jnt_actuatorid;
		/// <summary>
		/// group for visibility                     (njnt x 1)
		/// </summary>
		public int* jnt_group;
		/// <summary>
		/// does joint have limits                   (njnt x 1)
		/// </summary>
		public byte* jnt_limited;
		/// <summary>
		/// does joint have actuator force limits    (njnt x 1)
		/// </summary>
		public byte* jnt_actfrclimited;
		/// <summary>
		/// is gravcomp force applied via actuators  (njnt x 1)
		/// </summary>
		public byte* jnt_actgravcomp;
		/// <summary>
		/// constraint solver reference: limit       (njnt x mjNREF)
		/// </summary>
		public double* jnt_solref;
		/// <summary>
		/// constraint solver impedance: limit       (njnt x mjNIMP)
		/// </summary>
		public double* jnt_solimp;
		/// <summary>
		/// local anchor position                    (njnt x 3)
		/// </summary>
		public double* jnt_pos;
		/// <summary>
		/// local joint axis                         (njnt x 3)
		/// </summary>
		public double* jnt_axis;
		/// <summary>
		/// linear stiffness coefficient             (njnt x 1)
		/// </summary>
		public double* jnt_stiffness;
		/// <summary>
		/// high-order stiffness coefficients        (njnt x mjNPOLY)
		/// </summary>
		public double* jnt_stiffnesspoly;
		/// <summary>
		/// joint limits                             (njnt x 2)
		/// </summary>
		public double* jnt_range;
		/// <summary>
		/// range of total actuator force            (njnt x 2)
		/// </summary>
		public double* jnt_actfrcrange;
		/// <summary>
		/// min distance for limit detection         (njnt x 1)
		/// </summary>
		public double* jnt_margin;
		/// <summary>
		/// user data                                (njnt x nuser_jnt)
		/// </summary>
		public double* jnt_user;
		/// <summary>
		/// id of dof's body                         (nv x 1)
		/// </summary>
		public int* dof_bodyid;
		/// <summary>
		/// id of dof's joint                        (nv x 1)
		/// </summary>
		public int* dof_jntid;
		/// <summary>
		/// id of dof's parent; -1: none             (nv x 1)
		/// </summary>
		public int* dof_parentid;
		/// <summary>
		/// id of dof's kinematic tree               (nv x 1)
		/// </summary>
		public int* dof_treeid;
		/// <summary>
		/// dof address in M-diagonal                (nv x 1)
		/// </summary>
		public int* dof_Madr;
		/// <summary>
		/// number of consecutive simple dofs        (nv x 1)
		/// </summary>
		public int* dof_simplenum;
		/// <summary>
		/// constraint solver reference:frictionloss (nv x mjNREF)
		/// </summary>
		public double* dof_solref;
		/// <summary>
		/// constraint solver impedance:frictionloss (nv x mjNIMP)
		/// </summary>
		public double* dof_solimp;
		/// <summary>
		/// dof friction loss                        (nv x 1)
		/// </summary>
		public double* dof_frictionloss;
		/// <summary>
		/// dof armature inertia/mass                (nv x 1)
		/// </summary>
		public double* dof_armature;
		/// <summary>
		/// linear damping coefficient               (nv x 1)
		/// </summary>
		public double* dof_damping;
		/// <summary>
		/// high-order damping coefficients          (nv x mjNPOLY)
		/// </summary>
		public double* dof_dampingpoly;
		/// <summary>
		/// diag. inverse inertia in qpos0           (nv x 1)
		/// </summary>
		public double* dof_invweight0;
		/// <summary>
		/// diag. inertia in qpos0                   (nv x 1)
		/// </summary>
		public double* dof_M0;
		/// <summary>
		/// linear: 1; angular: approx. length scale (nv x 1)
		/// </summary>
		public double* dof_length;
		/// <summary>
		/// start addr of bodies                     (ntree x 1)
		/// </summary>
		public int* tree_bodyadr;
		/// <summary>
		/// number of bodies in tree                 (ntree x 1)
		/// </summary>
		public int* tree_bodynum;
		/// <summary>
		/// start addr of dofs                       (ntree x 1)
		/// </summary>
		public int* tree_dofadr;
		/// <summary>
		/// number of dofs in tree                   (ntree x 1)
		/// </summary>
		public int* tree_dofnum;
		/// <summary>
		/// sleep policy (mjtSleepPolicy)            (ntree x 1)
		/// </summary>
		public int* tree_sleep_policy;
		/// <summary>
		/// geometric type (mjtGeom)                 (ngeom x 1)
		/// </summary>
		public int* geom_type;
		/// <summary>
		/// geom contact type                        (ngeom x 1)
		/// </summary>
		public int* geom_contype;
		/// <summary>
		/// geom contact affinity                    (ngeom x 1)
		/// </summary>
		public int* geom_conaffinity;
		/// <summary>
		/// contact dimensionality (1, 3, 4, 6)      (ngeom x 1)
		/// </summary>
		public int* geom_condim;
		/// <summary>
		/// id of geom's body                        (ngeom x 1)
		/// </summary>
		public int* geom_bodyid;
		/// <summary>
		/// id of geom's mesh/hfield; -1: none       (ngeom x 1)
		/// </summary>
		public int* geom_dataid;
		/// <summary>
		/// material id for rendering; -1: none      (ngeom x 1)
		/// </summary>
		public int* geom_matid;
		/// <summary>
		/// group for visibility                     (ngeom x 1)
		/// </summary>
		public int* geom_group;
		/// <summary>
		/// geom contact priority                    (ngeom x 1)
		/// </summary>
		public int* geom_priority;
		/// <summary>
		/// plugin instance id; -1: not in use       (ngeom x 1)
		/// </summary>
		public int* geom_plugin;
		/// <summary>
		/// same frame as body (mjtSameframe)        (ngeom x 1)
		/// </summary>
		public byte* geom_sameframe;
		/// <summary>
		/// mixing coef for solref/imp in geom pair  (ngeom x 1)
		/// </summary>
		public double* geom_solmix;
		/// <summary>
		/// constraint solver reference: contact     (ngeom x mjNREF)
		/// </summary>
		public double* geom_solref;
		/// <summary>
		/// constraint solver impedance: contact     (ngeom x mjNIMP)
		/// </summary>
		public double* geom_solimp;
		/// <summary>
		/// geom-specific size parameters            (ngeom x 3)
		/// </summary>
		public double* geom_size;
		/// <summary>
		/// bounding box, (center, size)             (ngeom x 6)
		/// </summary>
		public double* geom_aabb;
		/// <summary>
		/// radius of bounding sphere                (ngeom x 1)
		/// </summary>
		public double* geom_rbound;
		/// <summary>
		/// local position offset rel. to body       (ngeom x 3)
		/// </summary>
		public double* geom_pos;
		/// <summary>
		/// local orientation offset rel. to body    (ngeom x 4)
		/// </summary>
		public double* geom_quat;
		/// <summary>
		/// friction for (slide, spin, roll)         (ngeom x 3)
		/// </summary>
		public double* geom_friction;
		/// <summary>
		/// geometric inflation for contact          (ngeom x 1)
		/// </summary>
		public double* geom_margin;
		/// <summary>
		/// additional contact detection buffer      (ngeom x 1)
		/// </summary>
		public double* geom_gap;
		/// <summary>
		/// surface velocity in local frame: lin,ang (ngeom x 6)
		/// </summary>
		public double* geom_surfacevel;
		/// <summary>
		/// adhesive force of contacts               (ngeom x 1)
		/// </summary>
		public double* geom_adhesion;
		/// <summary>
		/// fluid interaction parameters             (ngeom x mjNFLUID)
		/// </summary>
		public double* geom_fluid;
		/// <summary>
		/// user data                                (ngeom x nuser_geom)
		/// </summary>
		public double* geom_user;
		/// <summary>
		/// rgba when material is omitted            (ngeom x 4)
		/// </summary>
		public float* geom_rgba;
		/// <summary>
		/// geom type for rendering (mjtGeom)        (nsite x 1)
		/// </summary>
		public int* site_type;
		/// <summary>
		/// id of site's body                        (nsite x 1)
		/// </summary>
		public int* site_bodyid;
		/// <summary>
		/// material id for rendering; -1: none      (nsite x 1)
		/// </summary>
		public int* site_matid;
		/// <summary>
		/// group for visibility                     (nsite x 1)
		/// </summary>
		public int* site_group;
		/// <summary>
		/// same frame as body (mjtSameframe)        (nsite x 1)
		/// </summary>
		public byte* site_sameframe;
		/// <summary>
		/// geom size for rendering                  (nsite x 3)
		/// </summary>
		public double* site_size;
		/// <summary>
		/// local position offset rel. to body       (nsite x 3)
		/// </summary>
		public double* site_pos;
		/// <summary>
		/// local orientation offset rel. to body    (nsite x 4)
		/// </summary>
		public double* site_quat;
		/// <summary>
		/// user data                                (nsite x nuser_site)
		/// </summary>
		public double* site_user;
		/// <summary>
		/// rgba when material is omitted            (nsite x 4)
		/// </summary>
		public float* site_rgba;
		/// <summary>
		/// camera tracking mode (mjtCamLight)       (ncam x 1)
		/// </summary>
		public int* cam_mode;
		/// <summary>
		/// id of camera's body                      (ncam x 1)
		/// </summary>
		public int* cam_bodyid;
		/// <summary>
		/// id of targeted body; -1: none            (ncam x 1)
		/// </summary>
		public int* cam_targetbodyid;
		/// <summary>
		/// position rel. to body frame              (ncam x 3)
		/// </summary>
		public double* cam_pos;
		/// <summary>
		/// orientation rel. to body frame           (ncam x 4)
		/// </summary>
		public double* cam_quat;
		/// <summary>
		/// global position rel. to sub-com in qpos0 (ncam x 3)
		/// </summary>
		public double* cam_poscom0;
		/// <summary>
		/// global position rel. to body in qpos0    (ncam x 3)
		/// </summary>
		public double* cam_pos0;
		/// <summary>
		/// global orientation in qpos0              (ncam x 9)
		/// </summary>
		public double* cam_mat0;
		/// <summary>
		/// projection type (mjtProjection)          (ncam x 1)
		/// </summary>
		public int* cam_projection;
		/// <summary>
		/// y field-of-view (ortho ? len : deg)      (ncam x 1)
		/// </summary>
		public double* cam_fovy;
		/// <summary>
		/// inter-pupilary distance                  (ncam x 1)
		/// </summary>
		public double* cam_ipd;
		/// <summary>
		/// resolution: pixels [width, height]       (ncam x 2)
		/// </summary>
		public int* cam_resolution;
		/// <summary>
		/// output types (mjtCamOut bit flags)       (ncam x 1)
		/// </summary>
		public int* cam_output;
		/// <summary>
		/// sensor size: length [width, height]      (ncam x 2)
		/// </summary>
		public float* cam_sensorsize;
		/// <summary>
		/// [focal length; principal point]          (ncam x 4)
		/// </summary>
		public float* cam_intrinsic;
		/// <summary>
		/// user data                                (ncam x nuser_cam)
		/// </summary>
		public double* cam_user;
		/// <summary>
		/// light tracking mode (mjtCamLight)        (nlight x 1)
		/// </summary>
		public int* light_mode;
		/// <summary>
		/// id of light's body                       (nlight x 1)
		/// </summary>
		public int* light_bodyid;
		/// <summary>
		/// id of targeted body; -1: none            (nlight x 1)
		/// </summary>
		public int* light_targetbodyid;
		/// <summary>
		/// spot, directional, etc. (mjtLightType)   (nlight x 1)
		/// </summary>
		public int* light_type;
		/// <summary>
		/// texture id for image lights              (nlight x 1)
		/// </summary>
		public int* light_texid;
		/// <summary>
		/// does light cast shadows                  (nlight x 1)
		/// </summary>
		public byte* light_castshadow;
		/// <summary>
		/// light radius for soft shadows            (nlight x 1)
		/// </summary>
		public float* light_bulbradius;
		/// <summary>
		/// intensity, in candela                    (nlight x 1)
		/// </summary>
		public float* light_intensity;
		/// <summary>
		/// range of effectiveness                   (nlight x 1)
		/// </summary>
		public float* light_range;
		/// <summary>
		/// is light on                              (nlight x 1)
		/// </summary>
		public byte* light_active;
		/// <summary>
		/// position rel. to body frame              (nlight x 3)
		/// </summary>
		public double* light_pos;
		/// <summary>
		/// direction rel. to body frame             (nlight x 3)
		/// </summary>
		public double* light_dir;
		/// <summary>
		/// global position rel. to sub-com in qpos0 (nlight x 3)
		/// </summary>
		public double* light_poscom0;
		/// <summary>
		/// global position rel. to body in qpos0    (nlight x 3)
		/// </summary>
		public double* light_pos0;
		/// <summary>
		/// global direction in qpos0                (nlight x 3)
		/// </summary>
		public double* light_dir0;
		/// <summary>
		/// OpenGL attenuation (quadratic model)     (nlight x 3)
		/// </summary>
		public float* light_attenuation;
		/// <summary>
		/// OpenGL cutoff                            (nlight x 1)
		/// </summary>
		public float* light_cutoff;
		/// <summary>
		/// OpenGL exponent                          (nlight x 1)
		/// </summary>
		public float* light_exponent;
		/// <summary>
		/// ambient rgb (alpha=1)                    (nlight x 3)
		/// </summary>
		public float* light_ambient;
		/// <summary>
		/// diffuse rgb (alpha=1)                    (nlight x 3)
		/// </summary>
		public float* light_diffuse;
		/// <summary>
		/// specular rgb (alpha=1)                   (nlight x 3)
		/// </summary>
		public float* light_specular;
		/// <summary>
		/// flex contact type                        (nflex x 1)
		/// </summary>
		public int* flex_contype;
		/// <summary>
		/// flex contact affinity                    (nflex x 1)
		/// </summary>
		public int* flex_conaffinity;
		/// <summary>
		/// contact dimensionality (1, 3, 4, 6)      (nflex x 1)
		/// </summary>
		public int* flex_condim;
		/// <summary>
		/// flex contact priority                    (nflex x 1)
		/// </summary>
		public int* flex_priority;
		/// <summary>
		/// mix coef for solref/imp in contact pair  (nflex x 1)
		/// </summary>
		public double* flex_solmix;
		/// <summary>
		/// constraint solver reference: contact     (nflex x mjNREF)
		/// </summary>
		public double* flex_solref;
		/// <summary>
		/// constraint solver impedance: contact     (nflex x mjNIMP)
		/// </summary>
		public double* flex_solimp;
		/// <summary>
		/// friction for (slide, spin, roll)         (nflex x 3)
		/// </summary>
		public double* flex_friction;
		/// <summary>
		/// geometric inflation for contact          (nflex x 1)
		/// </summary>
		public double* flex_margin;
		/// <summary>
		/// additional contact detection buffer      (nflex x 1)
		/// </summary>
		public double* flex_gap;
		/// <summary>
		/// internal flex collision enabled          (nflex x 1)
		/// </summary>
		public byte* flex_internal;
		/// <summary>
		/// self collision mode (mjtFlexSelf)        (nflex x 1)
		/// </summary>
		public int* flex_selfcollide;
		/// <summary>
		/// number of active element layers, 3D only (nflex x 1)
		/// </summary>
		public int* flex_activelayers;
		/// <summary>
		/// passive collisions enabled               (nflex x 1)
		/// </summary>
		public int* flex_passive;
		/// <summary>
		/// 1: lines, 2: triangles, 3: tetrahedra    (nflex x 1)
		/// </summary>
		public int* flex_dim;
		/// <summary>
		/// material id for rendering                (nflex x 1)
		/// </summary>
		public int* flex_matid;
		/// <summary>
		/// group for visibility                     (nflex x 1)
		/// </summary>
		public int* flex_group;
		/// <summary>
		/// interpolation (0: vertex, 1: nodes)      (nflex x 1)
		/// </summary>
		public int* flex_interp;
		/// <summary>
		/// finite cell num per dimension            (nflex x 3)
		/// </summary>
		public int* flex_cellnum;
		/// <summary>
		/// first node address                       (nflex x 1)
		/// </summary>
		public int* flex_nodeadr;
		/// <summary>
		/// number of nodes                          (nflex x 1)
		/// </summary>
		public int* flex_nodenum;
		/// <summary>
		/// first vertex address                     (nflex x 1)
		/// </summary>
		public int* flex_vertadr;
		/// <summary>
		/// number of vertices                       (nflex x 1)
		/// </summary>
		public int* flex_vertnum;
		/// <summary>
		/// first edge address                       (nflex x 1)
		/// </summary>
		public int* flex_edgeadr;
		/// <summary>
		/// number of edges                          (nflex x 1)
		/// </summary>
		public int* flex_edgenum;
		/// <summary>
		/// first element address                    (nflex x 1)
		/// </summary>
		public int* flex_elemadr;
		/// <summary>
		/// number of elements                       (nflex x 1)
		/// </summary>
		public int* flex_elemnum;
		/// <summary>
		/// first element vertex id address          (nflex x 1)
		/// </summary>
		public int* flex_elemdataadr;
		/// <summary>
		/// stiffness matrix address                 (nflex x 1)
		/// </summary>
		public int* flex_stiffnessadr;
		/// <summary>
		/// first element edge id address            (nflex x 1)
		/// </summary>
		public int* flex_elemedgeadr;
		/// <summary>
		/// first bending data address               (nflex x 1)
		/// </summary>
		public int* flex_bendingadr;
		/// <summary>
		/// number of shells                         (nflex x 1)
		/// </summary>
		public int* flex_shellnum;
		/// <summary>
		/// first shell data address                 (nflex x 1)
		/// </summary>
		public int* flex_shelldataadr;
		/// <summary>
		/// first evpair address                     (nflex x 1)
		/// </summary>
		public int* flex_evpairadr;
		/// <summary>
		/// number of evpairs                        (nflex x 1)
		/// </summary>
		public int* flex_evpairnum;
		/// <summary>
		/// address in flex_texcoord; -1: none       (nflex x 1)
		/// </summary>
		public int* flex_texcoordadr;
		/// <summary>
		/// node body ids                            (nflexnode x 1)
		/// </summary>
		public int* flex_nodebodyid;
		/// <summary>
		/// vertex body ids                          (nflexvert x 1)
		/// </summary>
		public int* flex_vertbodyid;
		/// <summary>
		/// first edge address                       (nflexvert x 1)
		/// </summary>
		public int* flex_vertedgeadr;
		/// <summary>
		/// number of edges                          (nflexvert x 1)
		/// </summary>
		public int* flex_vertedgenum;
		/// <summary>
		/// edge indices                             (nflexedge x 2)
		/// </summary>
		public int* flex_vertedge;
		/// <summary>
		/// edge vertex ids (2 per edge)             (nflexedge x 2)
		/// </summary>
		public int* flex_edge;
		/// <summary>
		/// adjacent vertex ids (dim=2 only)         (nflexedge x 2)
		/// </summary>
		public int* flex_edgeflap;
		/// <summary>
		/// element vertex ids (dim+1 per elem)      (nflexelemdata x 1)
		/// </summary>
		public int* flex_elem;
		/// <summary>
		/// element texture coordinates (dim+1)      (nflexelemdata x 1)
		/// </summary>
		public int* flex_elemtexcoord;
		/// <summary>
		/// element edge ids                         (nflexelemedge x 1)
		/// </summary>
		public int* flex_elemedge;
		/// <summary>
		/// element distance from surface, 3D only   (nflexelem x 1)
		/// </summary>
		public int* flex_elemlayer;
		/// <summary>
		/// shell fragment vertex ids (dim per frag) (nflexshelldata x 1)
		/// </summary>
		public int* flex_shell;
		/// <summary>
		/// (element, vertex) collision pairs        (nflexevpair x 2)
		/// </summary>
		public int* flex_evpair;
		/// <summary>
		/// vertex positions in local body frames    (nflexvert x 3)
		/// </summary>
		public double* flex_vert;
		/// <summary>
		/// vertex positions in qpos0 on [0, 1]^d    (nflexvert x 3)
		/// </summary>
		public double* flex_vert0;
		/// <summary>
		/// inverse of reference shape matrix        (nflexvert x 4)
		/// </summary>
		public double* flex_vertmetric;
		/// <summary>
		/// node positions in local body frames      (nflexnode x 3)
		/// </summary>
		public double* flex_node;
		/// <summary>
		/// Cartesian node positions in qpos0        (nflexnode x 3)
		/// </summary>
		public double* flex_node0;
		/// <summary>
		/// edge lengths in qpos0                    (nflexedge x 1)
		/// </summary>
		public double* flexedge_length0;
		/// <summary>
		/// edge inv. weight in qpos0                (nflexedge x 1)
		/// </summary>
		public double* flexedge_invweight0;
		/// <summary>
		/// radius around primitive element          (nflex x 1)
		/// </summary>
		public double* flex_radius;
		/// <summary>
		/// vertex bounding box half sizes in qpos0  (nflex x 3)
		/// </summary>
		public double* flex_size;
		/// <summary>
		/// finite element stiffness matrix          (nflexstiffness x 1)
		/// </summary>
		public double* flex_stiffness;
		/// <summary>
		/// bending stiffness                        (nflexbending x 1)
		/// </summary>
		public double* flex_bending;
		/// <summary>
		/// constant metric factor row-&gt;dof address  (nefm0dof x 1)
		/// </summary>
		public int* efm0_dofid;
		/// <summary>
		/// constant metric factor row nonzeros      (nefm0dof x 1)
		/// </summary>
		public int* efm0_L_rownnz;
		/// <summary>
		/// constant metric factor row addresses     (nefm0dof x 1)
		/// </summary>
		public int* efm0_L_rowadr;
		/// <summary>
		/// constant metric factor column indices    (nefm0L x 1)
		/// </summary>
		public int* efm0_L_colind;
		/// <summary>
		/// factor of M + (dt^2+dt*d)*K_bend         (nefm0L x 1)
		/// </summary>
		public double* efm0_L;
		/// <summary>
		/// Rayleigh's damping coefficient           (nflex x 1)
		/// </summary>
		public double* flex_damping;
		/// <summary>
		/// edge stiffness                           (nflex x 1)
		/// </summary>
		public double* flex_edgestiffness;
		/// <summary>
		/// edge damping                             (nflex x 1)
		/// </summary>
		public double* flex_edgedamping;
		/// <summary>
		/// 0:none, 1:edges, 2:vertices, 3:strain    (nflex x 1)
		/// </summary>
		public int* flex_edgeequality;
		/// <summary>
		/// are all vertices in the same body        (nflex x 1)
		/// </summary>
		public byte* flex_rigid;
		/// <summary>
		/// are both edge vertices in same body      (nflexedge x 1)
		/// </summary>
		public byte* flexedge_rigid;
		/// <summary>
		/// are all vertex coordinates (0,0,0)       (nflex x 1)
		/// </summary>
		public byte* flex_centered;
		/// <summary>
		/// render flex skin with flat shading       (nflex x 1)
		/// </summary>
		public byte* flex_flatskin;
		/// <summary>
		/// address of bvh root; -1: no bvh          (nflex x 1)
		/// </summary>
		public int* flex_bvhadr;
		/// <summary>
		/// number of bounding volumes               (nflex x 1)
		/// </summary>
		public int* flex_bvhnum;
		/// <summary>
		/// number of non-zeros in Jacobian row      (nflexedge x 1)
		/// </summary>
		public int* flexedge_J_rownnz;
		/// <summary>
		/// row start address in colind array        (nflexedge x 1)
		/// </summary>
		public int* flexedge_J_rowadr;
		/// <summary>
		/// column indices in sparse Jacobian        (nJfe x 1)
		/// </summary>
		public int* flexedge_J_colind;
		/// <summary>
		/// number of non-zeros in Jacobian row      (nflexvert x 2)
		/// </summary>
		public int* flexvert_J_rownnz;
		/// <summary>
		/// row start address in colind array        (nflexvert x 2)
		/// </summary>
		public int* flexvert_J_rowadr;
		/// <summary>
		/// column indices in sparse Jacobian        (nJfv x 2)
		/// </summary>
		public int* flexvert_J_colind;
		/// <summary>
		/// rgba when material is omitted            (nflex x 4)
		/// </summary>
		public float* flex_rgba;
		/// <summary>
		/// vertex texture coordinates               (nflextexcoord x 2)
		/// </summary>
		public float* flex_texcoord;
		/// <summary>
		/// first vertex address                     (nmesh x 1)
		/// </summary>
		public int* mesh_vertadr;
		/// <summary>
		/// number of vertices                       (nmesh x 1)
		/// </summary>
		public int* mesh_vertnum;
		/// <summary>
		/// first face address                       (nmesh x 1)
		/// </summary>
		public int* mesh_faceadr;
		/// <summary>
		/// number of faces                          (nmesh x 1)
		/// </summary>
		public int* mesh_facenum;
		/// <summary>
		/// address of bvh root                      (nmesh x 1)
		/// </summary>
		public int* mesh_bvhadr;
		/// <summary>
		/// number of bvh                            (nmesh x 1)
		/// </summary>
		public int* mesh_bvhnum;
		/// <summary>
		/// address of octree root                   (nmesh x 1)
		/// </summary>
		public int* mesh_octadr;
		/// <summary>
		/// number of octree nodes                   (nmesh x 1)
		/// </summary>
		public int* mesh_octnum;
		/// <summary>
		/// first normal address                     (nmesh x 1)
		/// </summary>
		public int* mesh_normaladr;
		/// <summary>
		/// number of normals                        (nmesh x 1)
		/// </summary>
		public int* mesh_normalnum;
		/// <summary>
		/// texcoord data address; -1: no texcoord   (nmesh x 1)
		/// </summary>
		public int* mesh_texcoordadr;
		/// <summary>
		/// number of texcoord                       (nmesh x 1)
		/// </summary>
		public int* mesh_texcoordnum;
		/// <summary>
		/// graph data address; -1: no graph         (nmesh x 1)
		/// </summary>
		public int* mesh_graphadr;
		/// <summary>
		/// vertex positions for all meshes          (nmeshvert x 3)
		/// </summary>
		public float* mesh_vert;
		/// <summary>
		/// normals for all meshes                   (nmeshnormal x 3)
		/// </summary>
		public float* mesh_normal;
		/// <summary>
		/// vertex texcoords for all meshes          (nmeshtexcoord x 2)
		/// </summary>
		public float* mesh_texcoord;
		/// <summary>
		/// vertex face data                         (nmeshface x 3)
		/// </summary>
		public int* mesh_face;
		/// <summary>
		/// normal face data                         (nmeshface x 3)
		/// </summary>
		public int* mesh_facenormal;
		/// <summary>
		/// texture face data                        (nmeshface x 3)
		/// </summary>
		public int* mesh_facetexcoord;
		/// <summary>
		/// convex graph data                        (nmeshgraph x 1)
		/// </summary>
		public int* mesh_graph;
		/// <summary>
		/// scaling applied to asset vertices        (nmesh x 3)
		/// </summary>
		public double* mesh_scale;
		/// <summary>
		/// translation applied to asset vertices    (nmesh x 3)
		/// </summary>
		public double* mesh_pos;
		/// <summary>
		/// rotation applied to asset vertices       (nmesh x 4)
		/// </summary>
		public double* mesh_quat;
		/// <summary>
		/// address of asset path for mesh; -1: none (nmesh x 1)
		/// </summary>
		public int* mesh_pathadr;
		/// <summary>
		/// number of polygons per mesh              (nmesh x 1)
		/// </summary>
		public int* mesh_polynum;
		/// <summary>
		/// first polygon address per mesh           (nmesh x 1)
		/// </summary>
		public int* mesh_polyadr;
		/// <summary>
		/// all polygon normals                      (nmeshpoly x 3)
		/// </summary>
		public double* mesh_polynormal;
		/// <summary>
		/// polygon vertex start address             (nmeshpoly x 1)
		/// </summary>
		public int* mesh_polyvertadr;
		/// <summary>
		/// number of vertices per polygon           (nmeshpoly x 1)
		/// </summary>
		public int* mesh_polyvertnum;
		/// <summary>
		/// all polygon vertices                     (nmeshpolyvert x 1)
		/// </summary>
		public int* mesh_polyvert;
		/// <summary>
		/// first polygon address per vertex         (nmeshvert x 1)
		/// </summary>
		public int* mesh_polymapadr;
		/// <summary>
		/// number of polygons per vertex            (nmeshvert x 1)
		/// </summary>
		public int* mesh_polymapnum;
		/// <summary>
		/// vertex to polygon map                    (nmeshpolymap x 1)
		/// </summary>
		public int* mesh_polymap;
		/// <summary>
		/// skin material id; -1: none               (nskin x 1)
		/// </summary>
		public int* skin_matid;
		/// <summary>
		/// group for visibility                     (nskin x 1)
		/// </summary>
		public int* skin_group;
		/// <summary>
		/// skin rgba                                (nskin x 4)
		/// </summary>
		public float* skin_rgba;
		/// <summary>
		/// inflate skin in normal direction         (nskin x 1)
		/// </summary>
		public float* skin_inflate;
		/// <summary>
		/// first vertex address                     (nskin x 1)
		/// </summary>
		public int* skin_vertadr;
		/// <summary>
		/// number of vertices                       (nskin x 1)
		/// </summary>
		public int* skin_vertnum;
		/// <summary>
		/// texcoord data address; -1: no texcoord   (nskin x 1)
		/// </summary>
		public int* skin_texcoordadr;
		/// <summary>
		/// first face address                       (nskin x 1)
		/// </summary>
		public int* skin_faceadr;
		/// <summary>
		/// number of faces                          (nskin x 1)
		/// </summary>
		public int* skin_facenum;
		/// <summary>
		/// first bone in skin                       (nskin x 1)
		/// </summary>
		public int* skin_boneadr;
		/// <summary>
		/// number of bones in skin                  (nskin x 1)
		/// </summary>
		public int* skin_bonenum;
		/// <summary>
		/// vertex positions for all skin meshes     (nskinvert x 3)
		/// </summary>
		public float* skin_vert;
		/// <summary>
		/// vertex texcoords for all skin meshes     (nskintexvert x 2)
		/// </summary>
		public float* skin_texcoord;
		/// <summary>
		/// triangle faces for all skin meshes       (nskinface x 3)
		/// </summary>
		public int* skin_face;
		/// <summary>
		/// first vertex in each bone                (nskinbone x 1)
		/// </summary>
		public int* skin_bonevertadr;
		/// <summary>
		/// number of vertices in each bone          (nskinbone x 1)
		/// </summary>
		public int* skin_bonevertnum;
		/// <summary>
		/// bind pos of each bone                    (nskinbone x 3)
		/// </summary>
		public float* skin_bonebindpos;
		/// <summary>
		/// bind quat of each bone                   (nskinbone x 4)
		/// </summary>
		public float* skin_bonebindquat;
		/// <summary>
		/// body id of each bone                     (nskinbone x 1)
		/// </summary>
		public int* skin_bonebodyid;
		/// <summary>
		/// mesh ids of vertices in each bone        (nskinbonevert x 1)
		/// </summary>
		public int* skin_bonevertid;
		/// <summary>
		/// weights of vertices in each bone         (nskinbonevert x 1)
		/// </summary>
		public float* skin_bonevertweight;
		/// <summary>
		/// address of asset path for skin; -1: none (nskin x 1)
		/// </summary>
		public int* skin_pathadr;
		/// <summary>
		/// (x, y, z_top, z_bottom)                  (nhfield x 4)
		/// </summary>
		public double* hfield_size;
		/// <summary>
		/// number of rows in grid                   (nhfield x 1)
		/// </summary>
		public int* hfield_nrow;
		/// <summary>
		/// number of columns in grid                (nhfield x 1)
		/// </summary>
		public int* hfield_ncol;
		/// <summary>
		/// address in hfield_data                   (nhfield x 1)
		/// </summary>
		public int* hfield_adr;
		/// <summary>
		/// elevation data                           (nhfielddata x 1)
		/// </summary>
		public float* hfield_data;
		/// <summary>
		/// address of hfield asset path; -1: none   (nhfield x 1)
		/// </summary>
		public int* hfield_pathadr;
		/// <summary>
		/// texture type (mjtTexture)                (ntex x 1)
		/// </summary>
		public int* tex_type;
		/// <summary>
		/// texture colorspace (mjtColorSpace)       (ntex x 1)
		/// </summary>
		public int* tex_colorspace;
		/// <summary>
		/// number of rows in texture image          (ntex x 1)
		/// </summary>
		public int* tex_height;
		/// <summary>
		/// number of columns in texture image       (ntex x 1)
		/// </summary>
		public int* tex_width;
		/// <summary>
		/// number of channels in texture image      (ntex x 1)
		/// </summary>
		public int* tex_nchannel;
		/// <summary>
		/// start address in tex_data                (ntex x 1)
		/// </summary>
		public long* tex_adr;
		/// <summary>
		/// pixel values                             (ntexdata x 1)
		/// </summary>
		public byte* tex_data;
		/// <summary>
		/// address of texture asset path; -1: none  (ntex x 1)
		/// </summary>
		public int* tex_pathadr;
		/// <summary>
		/// indices of textures; -1: none            (nmat x mjNTEXROLE)
		/// </summary>
		public int* mat_texid;
		/// <summary>
		/// make texture cube uniform                (nmat x 1)
		/// </summary>
		public byte* mat_texuniform;
		/// <summary>
		/// texture repetition for 2d mapping        (nmat x 2)
		/// </summary>
		public float* mat_texrepeat;
		/// <summary>
		/// emission (x rgb)                         (nmat x 1)
		/// </summary>
		public float* mat_emission;
		/// <summary>
		/// specular (x white)                       (nmat x 1)
		/// </summary>
		public float* mat_specular;
		/// <summary>
		/// shininess coef                           (nmat x 1)
		/// </summary>
		public float* mat_shininess;
		/// <summary>
		/// reflectance (0: disable)                 (nmat x 1)
		/// </summary>
		public float* mat_reflectance;
		/// <summary>
		/// metallic coef                            (nmat x 1)
		/// </summary>
		public float* mat_metallic;
		/// <summary>
		/// roughness coef                           (nmat x 1)
		/// </summary>
		public float* mat_roughness;
		/// <summary>
		/// rgba                                     (nmat x 4)
		/// </summary>
		public float* mat_rgba;
		/// <summary>
		/// contact dimensionality                   (npair x 1)
		/// </summary>
		public int* pair_dim;
		/// <summary>
		/// id of geom1                              (npair x 1)
		/// </summary>
		public int* pair_geom1;
		/// <summary>
		/// id of geom2                              (npair x 1)
		/// </summary>
		public int* pair_geom2;
		/// <summary>
		/// body1
		/// &lt;
		/// &lt;
		/// 16 + body2                      (npair x 1)
		/// </summary>
		public int* pair_signature;
		/// <summary>
		/// solver reference: contact normal         (npair x mjNREF)
		/// </summary>
		public double* pair_solref;
		/// <summary>
		/// solver reference: contact friction       (npair x mjNREF)
		/// </summary>
		public double* pair_solreffriction;
		/// <summary>
		/// solver impedance: contact                (npair x mjNIMP)
		/// </summary>
		public double* pair_solimp;
		/// <summary>
		/// geometric inflation for contact          (npair x 1)
		/// </summary>
		public double* pair_margin;
		/// <summary>
		/// additional contact detection buffer      (npair x 1)
		/// </summary>
		public double* pair_gap;
		/// <summary>
		/// adhesive force of contacts               (npair x 1)
		/// </summary>
		public double* pair_adhesion;
		/// <summary>
		/// tangent1, 2, spin, roll1, 2              (npair x 5)
		/// </summary>
		public double* pair_friction;
		/// <summary>
		/// body1
		/// &lt;
		/// &lt;
		/// 16 + body2                      (nexclude x 1)
		/// </summary>
		public int* exclude_signature;
		/// <summary>
		/// constraint type (mjtEq)                  (neq x 1)
		/// </summary>
		public int* eq_type;
		/// <summary>
		/// id of object 1                           (neq x 1)
		/// </summary>
		public int* eq_obj1id;
		/// <summary>
		/// id of object 2                           (neq x 1)
		/// </summary>
		public int* eq_obj2id;
		/// <summary>
		/// type of both objects (mjtObj)            (neq x 1)
		/// </summary>
		public int* eq_objtype;
		/// <summary>
		/// initial enable/disable constraint state  (neq x 1)
		/// </summary>
		public byte* eq_active0;
		/// <summary>
		/// constraint solver reference              (neq x mjNREF)
		/// </summary>
		public double* eq_solref;
		/// <summary>
		/// constraint solver impedance              (neq x mjNIMP)
		/// </summary>
		public double* eq_solimp;
		/// <summary>
		/// numeric data for constraint              (neq x mjNEQDATA)
		/// </summary>
		public double* eq_data;
		/// <summary>
		/// address of first object in tendon's path (ntendon x 1)
		/// </summary>
		public int* tendon_adr;
		/// <summary>
		/// number of objects in tendon's path       (ntendon x 1)
		/// </summary>
		public int* tendon_num;
		/// <summary>
		/// material id for rendering                (ntendon x 1)
		/// </summary>
		public int* tendon_matid;
		/// <summary>
		/// actuator contributing damping / armature (ntendon x 1)
		/// </summary>
		public int* tendon_actuatorid;
		/// <summary>
		/// group for visibility                     (ntendon x 1)
		/// </summary>
		public int* tendon_group;
		/// <summary>
		/// number of trees along tendon's path      (ntendon x 1)
		/// </summary>
		public int* tendon_treenum;
		/// <summary>
		/// first two trees along tendon's path      (ntendon x 2)
		/// </summary>
		public int* tendon_treeid;
		/// <summary>
		/// number of non-zeros in Jacobian row      (ntendon x 1)
		/// </summary>
		public int* ten_J_rownnz;
		/// <summary>
		/// row start address in colind array        (ntendon x 1)
		/// </summary>
		public int* ten_J_rowadr;
		/// <summary>
		/// column indices in sparse Jacobian        (nJten x 1)
		/// </summary>
		public int* ten_J_colind;
		/// <summary>
		/// does tendon have length limits           (ntendon x 1)
		/// </summary>
		public byte* tendon_limited;
		/// <summary>
		/// does tendon have actuator force limits   (ntendon x 1)
		/// </summary>
		public byte* tendon_actfrclimited;
		/// <summary>
		/// width for rendering                      (ntendon x 1)
		/// </summary>
		public double* tendon_width;
		/// <summary>
		/// constraint solver reference: limit       (ntendon x mjNREF)
		/// </summary>
		public double* tendon_solref_lim;
		/// <summary>
		/// constraint solver impedance: limit       (ntendon x mjNIMP)
		/// </summary>
		public double* tendon_solimp_lim;
		/// <summary>
		/// constraint solver reference: friction    (ntendon x mjNREF)
		/// </summary>
		public double* tendon_solref_fri;
		/// <summary>
		/// constraint solver impedance: friction    (ntendon x mjNIMP)
		/// </summary>
		public double* tendon_solimp_fri;
		/// <summary>
		/// tendon length limits                     (ntendon x 2)
		/// </summary>
		public double* tendon_range;
		/// <summary>
		/// range of total actuator force            (ntendon x 2)
		/// </summary>
		public double* tendon_actfrcrange;
		/// <summary>
		/// min distance for limit detection         (ntendon x 1)
		/// </summary>
		public double* tendon_margin;
		/// <summary>
		/// linear stiffness coefficient             (ntendon x 1)
		/// </summary>
		public double* tendon_stiffness;
		/// <summary>
		/// high-order stiffness coefficients        (ntendon x mjNPOLY)
		/// </summary>
		public double* tendon_stiffnesspoly;
		/// <summary>
		/// linear damping coefficient               (ntendon x 1)
		/// </summary>
		public double* tendon_damping;
		/// <summary>
		/// high-order damping coefficients          (ntendon x mjNPOLY)
		/// </summary>
		public double* tendon_dampingpoly;
		/// <summary>
		/// inertia associated with tendon velocity  (ntendon x 1)
		/// </summary>
		public double* tendon_armature;
		/// <summary>
		/// loss due to friction                     (ntendon x 1)
		/// </summary>
		public double* tendon_frictionloss;
		/// <summary>
		/// spring resting length range              (ntendon x 2)
		/// </summary>
		public double* tendon_lengthspring;
		/// <summary>
		/// tendon length in qpos0                   (ntendon x 1)
		/// </summary>
		public double* tendon_length0;
		/// <summary>
		/// inv. weight in qpos0                     (ntendon x 1)
		/// </summary>
		public double* tendon_invweight0;
		/// <summary>
		/// user data                                (ntendon x nuser_tendon)
		/// </summary>
		public double* tendon_user;
		/// <summary>
		/// rgba when material is omitted            (ntendon x 4)
		/// </summary>
		public float* tendon_rgba;
		/// <summary>
		/// wrap object type (mjtWrap)               (nwrap x 1)
		/// </summary>
		public int* wrap_type;
		/// <summary>
		/// object id: geom, site, joint             (nwrap x 1)
		/// </summary>
		public int* wrap_objid;
		/// <summary>
		/// divisor, joint coef, or site id          (nwrap x 1)
		/// </summary>
		public double* wrap_prm;
		/// <summary>
		/// transmission type (mjtTrn)               (nactuator x 1)
		/// </summary>
		public int* actuator_trntype;
		/// <summary>
		/// dynamics type (mjtDyn)                   (nactuator x 1)
		/// </summary>
		public int* actuator_dyntype;
		/// <summary>
		/// gain type (mjtGain)                      (nactuator x 1)
		/// </summary>
		public int* actuator_gaintype;
		/// <summary>
		/// bias type (mjtBias)                      (nactuator x 1)
		/// </summary>
		public int* actuator_biastype;
		/// <summary>
		/// address of first control                 (nactuator x 1)
		/// </summary>
		public int* actuator_ctrladr;
		/// <summary>
		/// number of controls                       (nactuator x 1)
		/// </summary>
		public int* actuator_ctrlnum;
		/// <summary>
		/// input signature, scoped by gaintype      (nactuator x 1)
		/// </summary>
		public int* actuator_ctrlspec;
		/// <summary>
		/// address of first force output            (nactuator x 1)
		/// </summary>
		public int* actuator_outadr;
		/// <summary>
		/// number of force outputs, from trntype    (nactuator x 1)
		/// </summary>
		public int* actuator_outnum;
		/// <summary>
		/// first activation address; -1: stateless  (nactuator x 1)
		/// </summary>
		public int* actuator_actadr;
		/// <summary>
		/// number of activation variables           (nactuator x 1)
		/// </summary>
		public int* actuator_actnum;
		/// <summary>
		/// transmission id: joint, tendon, site     (nactuator x 2)
		/// </summary>
		public int* actuator_trnid;
		/// <summary>
		/// crank length for slider-crank            (nactuator x 1)
		/// </summary>
		public double* actuator_cranklength;
		/// <summary>
		/// dynamics parameters                      (nactuator x mjNDYN)
		/// </summary>
		public double* actuator_dynprm;
		/// <summary>
		/// gain parameters                          (nactuator x mjNGAIN)
		/// </summary>
		public double* actuator_gainprm;
		/// <summary>
		/// bias parameters                          (nactuator x mjNBIAS)
		/// </summary>
		public double* actuator_biasprm;
		/// <summary>
		/// is activation limited                    (nactuator x 1)
		/// </summary>
		public byte* actuator_actlimited;
		/// <summary>
		/// range of activations                     (nactuator x 2)
		/// </summary>
		public double* actuator_actrange;
		/// <summary>
		/// step activation before force             (nactuator x 1)
		/// </summary>
		public byte* actuator_actearly;
		/// <summary>
		/// history buffer: [nsample, interp]        (nactuator x 2)
		/// </summary>
		public int* actuator_history;
		/// <summary>
		/// address in history buffer; -1: none      (nactuator x 1)
		/// </summary>
		public int* actuator_historyadr;
		/// <summary>
		/// delay time; 0: no delay                  (nactuator x 1)
		/// </summary>
		public double* actuator_delay;
		/// <summary>
		/// linear damping coefficient               (nactuator x 1)
		/// </summary>
		public double* actuator_damping;
		/// <summary>
		/// high-order damping coefficients          (nactuator x mjNPOLY)
		/// </summary>
		public double* actuator_dampingpoly;
		/// <summary>
		/// armature added to target (joint, tendon) (nactuator x 1)
		/// </summary>
		public double* actuator_armature;
		/// <summary>
		/// group for visibility                     (nactuator x 1)
		/// </summary>
		public int* actuator_group;
		/// <summary>
		/// user data                                (nactuator x nuser_actuator)
		/// </summary>
		public double* actuator_user;
		/// <summary>
		/// plugin instance id; -1: not a plugin     (nactuator x 1)
		/// </summary>
		public int* actuator_plugin;
		/// <summary>
		/// is force limited                         (nactuator x 1)
		/// </summary>
		public byte* actuator_forcelimited;
		/// <summary>
		/// range of forces                          (nactuator x 2)
		/// </summary>
		public double* actuator_forcerange;
		/// <summary>
		/// is control limited                       (nu x 1)
		/// </summary>
		public byte* actuator_ctrllimited;
		/// <summary>
		/// range of controls                        (nu x 2)
		/// </summary>
		public double* actuator_ctrlrange;
		/// <summary>
		/// scale length and transmitted force       (nout x 6)
		/// </summary>
		public double* actuator_gear;
		/// <summary>
		/// acceleration from unit force in qpos0    (nout x 1)
		/// </summary>
		public double* actuator_acc0;
		/// <summary>
		/// actuator length in qpos0                 (nout x 1)
		/// </summary>
		public double* actuator_length0;
		/// <summary>
		/// feasible actuator length range           (nout x 2)
		/// </summary>
		public double* actuator_lengthrange;
		/// <summary>
		/// sensor type (mjtSensor)                  (nsensor x 1)
		/// </summary>
		public int* sensor_type;
		/// <summary>
		/// numeric data type (mjtDataType)          (nsensor x 1)
		/// </summary>
		public int* sensor_datatype;
		/// <summary>
		/// required compute stage (mjtStage)        (nsensor x 1)
		/// </summary>
		public int* sensor_needstage;
		/// <summary>
		/// type of sensorized object (mjtObj)       (nsensor x 1)
		/// </summary>
		public int* sensor_objtype;
		/// <summary>
		/// id of sensorized object                  (nsensor x 1)
		/// </summary>
		public int* sensor_objid;
		/// <summary>
		/// type of reference frame (mjtObj)         (nsensor x 1)
		/// </summary>
		public int* sensor_reftype;
		/// <summary>
		/// id of reference frame; -1: global frame  (nsensor x 1)
		/// </summary>
		public int* sensor_refid;
		/// <summary>
		/// sensor parameters                        (nsensor x mjNSENS)
		/// </summary>
		public int* sensor_intprm;
		/// <summary>
		/// number of scalar outputs                 (nsensor x 1)
		/// </summary>
		public int* sensor_dim;
		/// <summary>
		/// address in sensor array                  (nsensor x 1)
		/// </summary>
		public int* sensor_adr;
		/// <summary>
		/// cutoff for real and positive; 0: ignore  (nsensor x 1)
		/// </summary>
		public double* sensor_cutoff;
		/// <summary>
		/// noise standard deviation                 (nsensor x 1)
		/// </summary>
		public double* sensor_noise;
		/// <summary>
		/// history buffer: [nsample, interp]        (nsensor x 2)
		/// </summary>
		public int* sensor_history;
		/// <summary>
		/// address in history buffer; -1: none      (nsensor x 1)
		/// </summary>
		public int* sensor_historyadr;
		/// <summary>
		/// delay time in seconds; 0: no delay       (nsensor x 1)
		/// </summary>
		public double* sensor_delay;
		/// <summary>
		/// interval: [period, phase] in seconds     (nsensor x 2)
		/// </summary>
		public double* sensor_interval;
		/// <summary>
		/// user data                                (nsensor x nuser_sensor)
		/// </summary>
		public double* sensor_user;
		/// <summary>
		/// plugin instance id; -1: not a plugin     (nsensor x 1)
		/// </summary>
		public int* sensor_plugin;
		/// <summary>
		/// globally registered plugin slot number   (nplugin x 1)
		/// </summary>
		public int* plugin;
		/// <summary>
		/// address in the plugin state array        (nplugin x 1)
		/// </summary>
		public int* plugin_stateadr;
		/// <summary>
		/// number of states in the plugin instance  (nplugin x 1)
		/// </summary>
		public int* plugin_statenum;
		/// <summary>
		/// config attributes of plugin instances    (npluginattr x 1)
		/// </summary>
		public byte* plugin_attr;
		/// <summary>
		/// address to each instance's config attrib (nplugin x 1)
		/// </summary>
		public int* plugin_attradr;
		/// <summary>
		/// address of field in numeric_data         (nnumeric x 1)
		/// </summary>
		public int* numeric_adr;
		/// <summary>
		/// size of numeric field                    (nnumeric x 1)
		/// </summary>
		public int* numeric_size;
		/// <summary>
		/// array of all numeric fields              (nnumericdata x 1)
		/// </summary>
		public double* numeric_data;
		/// <summary>
		/// address of text in text_data             (ntext x 1)
		/// </summary>
		public int* text_adr;
		/// <summary>
		/// size of text field (strlen+1)            (ntext x 1)
		/// </summary>
		public int* text_size;
		/// <summary>
		/// array of all text fields (0-terminated)  (ntextdata x 1)
		/// </summary>
		public byte* text_data;
		/// <summary>
		/// address of text in text_data             (ntuple x 1)
		/// </summary>
		public int* tuple_adr;
		/// <summary>
		/// number of objects in tuple               (ntuple x 1)
		/// </summary>
		public int* tuple_size;
		/// <summary>
		/// array of object types in all tuples      (ntupledata x 1)
		/// </summary>
		public int* tuple_objtype;
		/// <summary>
		/// array of object ids in all tuples        (ntupledata x 1)
		/// </summary>
		public int* tuple_objid;
		/// <summary>
		/// array of object params in all tuples     (ntupledata x 1)
		/// </summary>
		public double* tuple_objprm;
		/// <summary>
		/// key time                                 (nkey x 1)
		/// </summary>
		public double* key_time;
		/// <summary>
		/// key position                             (nkey x nq)
		/// </summary>
		public double* key_qpos;
		/// <summary>
		/// key velocity                             (nkey x nv)
		/// </summary>
		public double* key_qvel;
		/// <summary>
		/// key activation                           (nkey x na)
		/// </summary>
		public double* key_act;
		/// <summary>
		/// key mocap position                       (nkey x nmocap*3)
		/// </summary>
		public double* key_mpos;
		/// <summary>
		/// key mocap quaternion                     (nkey x nmocap*4)
		/// </summary>
		public double* key_mquat;
		/// <summary>
		/// key control                              (nkey x nu)
		/// </summary>
		public double* key_ctrl;
		/// <summary>
		/// body name pointers                       (nbody x 1)
		/// </summary>
		public int* name_bodyadr;
		/// <summary>
		/// joint name pointers                      (njnt x 1)
		/// </summary>
		public int* name_jntadr;
		/// <summary>
		/// geom name pointers                       (ngeom x 1)
		/// </summary>
		public int* name_geomadr;
		/// <summary>
		/// site name pointers                       (nsite x 1)
		/// </summary>
		public int* name_siteadr;
		/// <summary>
		/// camera name pointers                     (ncam x 1)
		/// </summary>
		public int* name_camadr;
		/// <summary>
		/// light name pointers                      (nlight x 1)
		/// </summary>
		public int* name_lightadr;
		/// <summary>
		/// flex name pointers                       (nflex x 1)
		/// </summary>
		public int* name_flexadr;
		/// <summary>
		/// mesh name pointers                       (nmesh x 1)
		/// </summary>
		public int* name_meshadr;
		/// <summary>
		/// skin name pointers                       (nskin x 1)
		/// </summary>
		public int* name_skinadr;
		/// <summary>
		/// hfield name pointers                     (nhfield x 1)
		/// </summary>
		public int* name_hfieldadr;
		/// <summary>
		/// texture name pointers                    (ntex x 1)
		/// </summary>
		public int* name_texadr;
		/// <summary>
		/// material name pointers                   (nmat x 1)
		/// </summary>
		public int* name_matadr;
		/// <summary>
		/// geom pair name pointers                  (npair x 1)
		/// </summary>
		public int* name_pairadr;
		/// <summary>
		/// exclude name pointers                    (nexclude x 1)
		/// </summary>
		public int* name_excludeadr;
		/// <summary>
		/// equality constraint name pointers        (neq x 1)
		/// </summary>
		public int* name_eqadr;
		/// <summary>
		/// tendon name pointers                     (ntendon x 1)
		/// </summary>
		public int* name_tendonadr;
		/// <summary>
		/// actuator name pointers                   (nactuator x 1)
		/// </summary>
		public int* name_actuatoradr;
		/// <summary>
		/// sensor name pointers                     (nsensor x 1)
		/// </summary>
		public int* name_sensoradr;
		/// <summary>
		/// numeric name pointers                    (nnumeric x 1)
		/// </summary>
		public int* name_numericadr;
		/// <summary>
		/// text name pointers                       (ntext x 1)
		/// </summary>
		public int* name_textadr;
		/// <summary>
		/// tuple name pointers                      (ntuple x 1)
		/// </summary>
		public int* name_tupleadr;
		/// <summary>
		/// keyframe name pointers                   (nkey x 1)
		/// </summary>
		public int* name_keyadr;
		/// <summary>
		/// plugin instance name pointers            (nplugin x 1)
		/// </summary>
		public int* name_pluginadr;
		/// <summary>
		/// names of all objects, 0-terminated       (nnames x 1)
		/// </summary>
		public byte* names;
		/// <summary>
		/// internal hash map of names               (nnames_map x 1)
		/// </summary>
		public int* names_map;
		/// <summary>
		/// paths to assets, 0-terminated            (npaths x 1)
		/// </summary>
		public byte* paths;
		/// <summary>
		/// body-dof: non-zeros in each row          (nbody x 1)
		/// </summary>
		public int* B_rownnz;
		/// <summary>
		/// body-dof: row addresses                  (nbody x 1)
		/// </summary>
		public int* B_rowadr;
		/// <summary>
		/// body-dof: column indices                 (nB x 1)
		/// </summary>
		public int* B_colind;
		/// <summary>
		/// reduced inertia: non-zeros in each row   (nv x 1)
		/// </summary>
		public int* M_rownnz;
		/// <summary>
		/// reduced inertia: row addresses           (nv x 1)
		/// </summary>
		public int* M_rowadr;
		/// <summary>
		/// reduced inertia: column indices          (nC x 1)
		/// </summary>
		public int* M_colind;
		/// <summary>
		/// index mapping from qM to M               (nC x 1)
		/// </summary>
		public int* mapM2M;
		/// <summary>
		/// full inertia: non-zeros in each row      (nv x 1)
		/// </summary>
		public int* D_rownnz;
		/// <summary>
		/// full inertia: row addresses              (nv x 1)
		/// </summary>
		public int* D_rowadr;
		/// <summary>
		/// full inertia: index of diagonal element  (nv x 1)
		/// </summary>
		public int* D_diag;
		/// <summary>
		/// full inertia: column indices             (nD x 1)
		/// </summary>
		public int* D_colind;
		/// <summary>
		/// index mapping from M to D                (nD x 1)
		/// </summary>
		public int* mapM2D;
		/// <summary>
		/// index mapping from D to M                (nC x 1)
		/// </summary>
		public int* mapD2M;
		/// <summary>
		/// also held by the mjSpec that compiled this model
		/// </summary>
		public ulong signature;
	}

	/// <summary>
	/// ------------------------------------- Contact ----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjPreContact
	{
		public double dist;
		public fixed double pos[3];
		/// <summary>
		/// contact normal of the collision
		/// </summary>
		public fixed double normal[3];
		/// <summary>
		/// first tangent direction
		/// </summary>
		public fixed double tangent[3];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjContact
	{
		/// <summary>
		/// distance between nearest points; neg: penetration
		/// </summary>
		public double dist;
		/// <summary>
		/// position of contact point: midpoint between geoms
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// normal is in [0-2], points from geom[0] to geom[1]
		/// </summary>
		public fixed double frame[9];
		/// <summary>
		/// margin for force generation
		/// </summary>
		public double includemargin;
		/// <summary>
		/// tangent1, 2, spin, roll1, 2
		/// </summary>
		public fixed double friction[5];
		/// <summary>
		/// constraint solver reference, normal direction
		/// </summary>
		public fixed double solref[2];
		/// <summary>
		/// constraint solver reference, friction directions
		/// </summary>
		public fixed double solreffriction[2];
		/// <summary>
		/// constraint solver impedance
		/// </summary>
		public fixed double solimp[5];
		/// <summary>
		/// adhesive force along the contact normal
		/// </summary>
		public double adhesion;
		/// <summary>
		/// friction of regularized cone, set by mj_makeConstraint
		/// </summary>
		public double mu;
		/// <summary>
		/// cone Hessian, set by mj_constraintUpdate
		/// </summary>
		public fixed double H[36];
		/// <summary>
		/// contact space dimensionality: 1, 3, 4 or 6
		/// </summary>
		public int dim;
		/// <summary>
		/// id of geom 1; deprecated, use geom[0]
		/// </summary>
		public int geom1;
		/// <summary>
		/// id of geom 2; deprecated, use geom[1]
		/// </summary>
		public int geom2;
		/// <summary>
		/// geom ids; -1 for flex
		/// </summary>
		public fixed int geom[2];
		/// <summary>
		/// flex ids; -1 for geom
		/// </summary>
		public fixed int flex[2];
		/// <summary>
		/// element ids; -1 for geom or flex vertex
		/// </summary>
		public fixed int elem[2];
		/// <summary>
		/// vertex ids;  -1 for geom or flex element
		/// </summary>
		public fixed int vert[2];
		/// <summary>
		/// 0: include, 1: in gap, 2: fused, 3: no dofs, 4: passive
		/// </summary>
		public int exclude;
		/// <summary>
		/// address in efc; -1: not included
		/// </summary>
		public int efc_address;
	}

	/// <summary>
	/// ---------------------------------- diagnostics ---------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjWarningStat
	{
		/// <summary>
		/// info from last warning
		/// </summary>
		public int lastinfo;
		/// <summary>
		/// how many times was warning raised
		/// </summary>
		public int number;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjTimerStat
	{
		/// <summary>
		/// cumulative duration
		/// </summary>
		public double duration;
		/// <summary>
		/// how many times was timer called
		/// </summary>
		public int number;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjSolverStat
	{
		/// <summary>
		/// cost reduction, scaled by 1/trace(M(qpos0))
		/// </summary>
		public double improvement;
		/// <summary>
		/// gradient norm (primal only, scaled)
		/// </summary>
		public double gradient;
		/// <summary>
		/// slope in linesearch
		/// </summary>
		public double lineslope;
		/// <summary>
		/// number of active constraints
		/// </summary>
		public int nactive;
		/// <summary>
		/// number of constraint state changes
		/// </summary>
		public int nchange;
		/// <summary>
		/// number of cost evaluations in line search
		/// </summary>
		public int neval;
		/// <summary>
		/// number of Cholesky updates in line search
		/// </summary>
		public int nupdate;
	}

	/// <summary>
	/// ---------------------------------- mjData --------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjData
	{
		/// <summary>
		/// size of the arena in bytes (inclusive of the stack)
		/// </summary>
		public long narena;
		/// <summary>
		/// size of main buffer in bytes
		/// </summary>
		public long nbuffer;
		/// <summary>
		/// number of plugin instances
		/// </summary>
		public int nplugin;
		/// <summary>
		/// first available byte in stack (mutable)
		/// </summary>
		public nuint pstack;
		/// <summary>
		/// value of pstack when mj_markStack was last called (mutable)
		/// </summary>
		public nuint pbase;
		/// <summary>
		/// first available byte in arena
		/// </summary>
		public nuint parena;
		/// <summary>
		/// thread pool pointer
		/// </summary>
		public nuint threadpool;
		/// <summary>
		/// disable stack freeing during threaded execution
		/// </summary>
		public byte threadlock;
		/// <summary>
		/// maximum stack allocation in bytes (mutable)
		/// </summary>
		public long maxuse_stack;
		/// <summary>
		/// maximum arena allocation in bytes
		/// </summary>
		public long maxuse_arena;
		/// <summary>
		/// maximum number of contacts
		/// </summary>
		public int maxuse_con;
		/// <summary>
		/// maximum number of scalar constraints
		/// </summary>
		public int maxuse_efc;
		/// <summary>
		/// solver statistics per island, per iteration
		/// </summary>
		public InlineArray_mjSolverStat_4000 solver;
		/// <summary>
		/// number of solver iterations, per island
		/// </summary>
		public fixed int solver_niter[20];
		/// <summary>
		/// number of nonzeros in solver matrix, per island
		/// </summary>
		public fixed int solver_nnz[20];
		/// <summary>
		/// forward-inverse comparison: qfrc, efc
		/// </summary>
		public fixed double solver_fwdinv[2];
		/// <summary>
		/// warning statistics (mutable)
		/// </summary>
		public InlineArray_mjWarningStat_7 warning;
		/// <summary>
		/// timer statistics
		/// </summary>
		public InlineArray_mjTimerStat_15 timer;
		/// <summary>
		/// number of detected contacts
		/// </summary>
		public int ncon;
		/// <summary>
		/// number of equality constraints
		/// </summary>
		public int ne;
		/// <summary>
		/// number of friction constraints
		/// </summary>
		public int nf;
		/// <summary>
		/// number of limit constraints
		/// </summary>
		public int nl;
		/// <summary>
		/// number of constraints
		/// </summary>
		public int nefc;
		/// <summary>
		/// number of non-zeros in constraint Jacobian
		/// </summary>
		public int nJ;
		/// <summary>
		/// implicit effective metric M+K: 0 inactive, 1 active, 2 active + preconditioner exact
		/// </summary>
		public int efm_active;
		/// <summary>
		/// number of non-zeros in effective-stiffness CSR
		/// </summary>
		public int nefmK;
		/// <summary>
		/// number of rows in effective-metric factor
		/// </summary>
		public int nefmdof;
		/// <summary>
		/// number of non-zeros in the effective-metric factor
		/// </summary>
		public int nefmL;
		/// <summary>
		/// number of non-zeros in constraint inverse inertia square root
		/// </summary>
		public int nY;
		/// <summary>
		/// number of non-zeros in constraint inverse inertia matrix
		/// </summary>
		public int nA;
		/// <summary>
		/// number of detected constraint islands
		/// </summary>
		public int nisland;
		/// <summary>
		/// number of dofs in all islands
		/// </summary>
		public int nidof;
		/// <summary>
		/// number of awake trees
		/// </summary>
		public int ntree_awake;
		/// <summary>
		/// number of awake dynamic and static bodies
		/// </summary>
		public int nbody_awake;
		/// <summary>
		/// number of bodies with awake parents
		/// </summary>
		public int nparent_awake;
		/// <summary>
		/// number of awake dofs
		/// </summary>
		public int nv_awake;
		/// <summary>
		/// has mj_energyPos been called
		/// </summary>
		public byte flg_energypos;
		/// <summary>
		/// has mj_energyVel been called
		/// </summary>
		public byte flg_energyvel;
		/// <summary>
		/// has mj_subtreeVel been called
		/// </summary>
		public byte flg_subtreevel;
		/// <summary>
		/// has mj_rnePostConstraint been called
		/// </summary>
		public byte flg_rnepost;
		/// <summary>
		/// simulation time
		/// </summary>
		public double time;
		/// <summary>
		/// potential, kinetic energy
		/// </summary>
		public fixed double energy[2];
		/// <summary>
		/// main buffer; all pointers point in it            (nbuffer bytes)
		/// </summary>
		public void* buffer;
		/// <summary>
		/// arena+stack buffer                               (narena bytes)
		/// </summary>
		public void* arena;
		/// <summary>
		/// position                                         (nq x 1)
		/// </summary>
		public double* qpos;
		/// <summary>
		/// velocity                                         (nv x 1)
		/// </summary>
		public double* qvel;
		/// <summary>
		/// actuator activation                              (na x 1)
		/// </summary>
		public double* act;
		/// <summary>
		/// history buffer                                   (nhistory x 1)
		/// </summary>
		public double* history;
		/// <summary>
		/// acceleration used for warmstart                  (nv x 1)
		/// </summary>
		public double* qacc_warmstart;
		/// <summary>
		/// plugin state                                     (npluginstate x 1)
		/// </summary>
		public double* plugin_state;
		/// <summary>
		/// control                                          (nu x 1)
		/// </summary>
		public double* ctrl;
		/// <summary>
		/// applied generalized force                        (nv x 1)
		/// </summary>
		public double* qfrc_applied;
		/// <summary>
		/// applied Cartesian force/torque                   (nbody x 6)
		/// </summary>
		public double* xfrc_applied;
		/// <summary>
		/// enable/disable constraints                       (neq x 1)
		/// </summary>
		public byte* eq_active;
		/// <summary>
		/// positions of mocap bodies                        (nmocap x 3)
		/// </summary>
		public double* mocap_pos;
		/// <summary>
		/// orientations of mocap bodies                     (nmocap x 4)
		/// </summary>
		public double* mocap_quat;
		/// <summary>
		/// acceleration                                     (nv x 1)
		/// </summary>
		public double* qacc;
		/// <summary>
		/// time-derivative of actuator activation           (na x 1)
		/// </summary>
		public double* act_dot;
		/// <summary>
		/// user data, not touched by engine                 (nuserdata x 1)
		/// </summary>
		public double* userdata;
		/// <summary>
		/// sensor data array                                (nsensordata x 1)
		/// </summary>
		public double* sensordata;
		/// <summary>
		/// &lt;
		/// 0: awake; &gt;=0: index cycle of sleeping trees    (ntree x 1)
		/// </summary>
		public int* tree_asleep;
		/// <summary>
		/// copy of m-&gt;plugin, required for deletion         (nplugin x 1)
		/// </summary>
		public int* plugin;
		/// <summary>
		/// pointer to plugin-managed data structure         (nplugin x 1)
		/// </summary>
		public nuint* plugin_data;
		/// <summary>
		/// Cartesian position of body frame                 (nbody x 3)
		/// </summary>
		public double* xpos;
		/// <summary>
		/// Cartesian orientation of body frame              (nbody x 4)
		/// </summary>
		public double* xquat;
		/// <summary>
		/// Cartesian orientation of body frame              (nbody x 9)
		/// </summary>
		public double* xmat;
		/// <summary>
		/// Cartesian position of body com                   (nbody x 3)
		/// </summary>
		public double* xipos;
		/// <summary>
		/// Cartesian orientation of body inertia            (nbody x 9)
		/// </summary>
		public double* ximat;
		/// <summary>
		/// Cartesian position of joint anchor               (njnt x 3)
		/// </summary>
		public double* xanchor;
		/// <summary>
		/// Cartesian joint axis                             (njnt x 3)
		/// </summary>
		public double* xaxis;
		/// <summary>
		/// Cartesian geom position                          (ngeom x 3)
		/// </summary>
		public double* geom_xpos;
		/// <summary>
		/// Cartesian geom orientation                       (ngeom x 9)
		/// </summary>
		public double* geom_xmat;
		/// <summary>
		/// Cartesian site position                          (nsite x 3)
		/// </summary>
		public double* site_xpos;
		/// <summary>
		/// Cartesian site orientation                       (nsite x 9)
		/// </summary>
		public double* site_xmat;
		/// <summary>
		/// Cartesian camera position                        (ncam x 3)
		/// </summary>
		public double* cam_xpos;
		/// <summary>
		/// Cartesian camera orientation                     (ncam x 9)
		/// </summary>
		public double* cam_xmat;
		/// <summary>
		/// Cartesian light position                         (nlight x 3)
		/// </summary>
		public double* light_xpos;
		/// <summary>
		/// Cartesian light direction                        (nlight x 3)
		/// </summary>
		public double* light_xdir;
		/// <summary>
		/// center of mass of each subtree                   (nbody x 3)
		/// </summary>
		public double* subtree_com;
		/// <summary>
		/// com-based motion axis of each dof (rot:lin)      (nv x 6)
		/// </summary>
		public double* cdof;
		/// <summary>
		/// com-based body inertia and mass                  (nbody x 10)
		/// </summary>
		public double* cinert;
		/// <summary>
		/// Cartesian flex vertex positions                  (nflexvert x 3)
		/// </summary>
		public double* flexvert_xpos;
		/// <summary>
		/// flex element bounding boxes (center, size)       (nflexelem x 6)
		/// </summary>
		public double* flexelem_aabb;
		/// <summary>
		/// corotated element stiffness (implicit only)      (nflexstiffness x 1)
		/// </summary>
		public double* flexelem_krot;
		/// <summary>
		/// flex edge Jacobian                               (nJfe x 1)
		/// </summary>
		public double* flexedge_J;
		/// <summary>
		/// flex edge lengths                                (nflexedge x 1)
		/// </summary>
		public double* flexedge_length;
		/// <summary>
		/// flex vertex Jacobian                             (nJfv x 2)
		/// </summary>
		public double* flexvert_J;
		/// <summary>
		/// flex vertex lengths                              (nflexvert x 2)
		/// </summary>
		public double* flexvert_length;
		/// <summary>
		/// global bounding box (center, size)               (nbvhdynamic x 6)
		/// </summary>
		public double* bvh_aabb_dyn;
		/// <summary>
		/// start address of tendon's path                   (ntendon x 1)
		/// </summary>
		public int* ten_wrapadr;
		/// <summary>
		/// number of wrap points in path                    (ntendon x 1)
		/// </summary>
		public int* ten_wrapnum;
		/// <summary>
		/// tendon Jacobian                                  (nJten x 1)
		/// </summary>
		public double* ten_J;
		/// <summary>
		/// tendon lengths                                   (ntendon x 1)
		/// </summary>
		public double* ten_length;
		/// <summary>
		/// geom id; -1: site; -2: pulley                    (nwrap x 2)
		/// </summary>
		public int* wrap_obj;
		/// <summary>
		/// Cartesian 3D points in all paths                 (nwrap x 6)
		/// </summary>
		public double* wrap_xpos;
		/// <summary>
		/// actuator lengths, one per force output           (nout x 1)
		/// </summary>
		public double* actuator_length;
		/// <summary>
		/// number of non-zeros in actuator_moment row       (nout x 1)
		/// </summary>
		public int* moment_rownnz;
		/// <summary>
		/// row start address in colind array                (nout x 1)
		/// </summary>
		public int* moment_rowadr;
		/// <summary>
		/// column indices in sparse Jacobian                (nJmom x 1)
		/// </summary>
		public int* moment_colind;
		/// <summary>
		/// actuator moments                                 (nJmom x 1)
		/// </summary>
		public double* actuator_moment;
		/// <summary>
		/// com-based composite inertia and mass             (nbody x 10)
		/// </summary>
		public double* crb;
		/// <summary>
		/// inertia (sparse)                                 (nC x 1)
		/// </summary>
		public double* M;
		/// <summary>
		/// L'*D*L factorization of M (sparse)               (nC x 1)
		/// </summary>
		public double* qLD;
		/// <summary>
		/// 1/diag(D)                                        (nv x 1)
		/// </summary>
		public double* qLDiagInv;
		/// <summary>
		/// was bounding volume checked for collision        (nbvh x 1)
		/// </summary>
		public byte* bvh_active;
		/// <summary>
		/// is tree awake; 0: asleep; 1: awake               (ntree x 1)
		/// </summary>
		public int* tree_awake;
		/// <summary>
		/// body sleep state (mjtSleepState)                 (nbody x 1)
		/// </summary>
		public int* body_awake;
		/// <summary>
		/// indices of awake and static bodies               (nbody x 1)
		/// </summary>
		public int* body_awake_ind;
		/// <summary>
		/// indices of bodies with awake or static parents   (nbody x 1)
		/// </summary>
		public int* parent_awake_ind;
		/// <summary>
		/// indices of awake dofs                            (nv x 1)
		/// </summary>
		public int* dof_awake_ind;
		/// <summary>
		/// flex edge velocities                             (nflexedge x 1)
		/// </summary>
		public double* flexedge_velocity;
		/// <summary>
		/// tendon velocities                                (ntendon x 1)
		/// </summary>
		public double* ten_velocity;
		/// <summary>
		/// actuator velocities, one per force output        (nout x 1)
		/// </summary>
		public double* actuator_velocity;
		/// <summary>
		/// com-based velocity (rot:lin)                     (nbody x 6)
		/// </summary>
		public double* cvel;
		/// <summary>
		/// time-derivative of cdof (rot:lin)                (nv x 6)
		/// </summary>
		public double* cdof_dot;
		/// <summary>
		/// C(qpos,qvel)                                     (nv x 1)
		/// </summary>
		public double* qfrc_bias;
		/// <summary>
		/// passive spring force                             (nv x 1)
		/// </summary>
		public double* qfrc_spring;
		/// <summary>
		/// passive damper force                             (nv x 1)
		/// </summary>
		public double* qfrc_damper;
		/// <summary>
		/// passive gravity compensation force               (nv x 1)
		/// </summary>
		public double* qfrc_gravcomp;
		/// <summary>
		/// passive fluid force                              (nv x 1)
		/// </summary>
		public double* qfrc_fluid;
		/// <summary>
		/// passive contact adhesion force                   (nv x 1)
		/// </summary>
		public double* qfrc_adhesion;
		/// <summary>
		/// total passive force                              (nv x 1)
		/// </summary>
		public double* qfrc_passive;
		/// <summary>
		/// linear velocity of subtree com                   (nbody x 3)
		/// </summary>
		public double* subtree_linvel;
		/// <summary>
		/// angular momentum about subtree com               (nbody x 3)
		/// </summary>
		public double* subtree_angmom;
		/// <summary>
		/// L'*D*L factorization of modified M               (nC x 1)
		/// </summary>
		public double* qH;
		/// <summary>
		/// 1/diag(D) of modified M                          (nv x 1)
		/// </summary>
		public double* qHDiagInv;
		/// <summary>
		/// d (passive + actuator - bias) / d qvel           (nD x 1)
		/// </summary>
		public double* qDeriv;
		/// <summary>
		/// sparse LU of (M - dt*qDeriv)                     (nD x 1)
		/// </summary>
		public double* qLU;
		/// <summary>
		/// actuator force in actuation space                (nout x 1)
		/// </summary>
		public double* actuator_force;
		/// <summary>
		/// actuator force in joint space                    (nv x 1)
		/// </summary>
		public double* qfrc_actuator;
		/// <summary>
		/// net unconstrained force                          (nv x 1)
		/// </summary>
		public double* qfrc_smooth;
		/// <summary>
		/// unconstrained acceleration                       (nv x 1)
		/// </summary>
		public double* qacc_smooth;
		/// <summary>
		/// constraint force                                 (nv x 1)
		/// </summary>
		public double* qfrc_constraint;
		/// <summary>
		/// net external force; should equal:
		/// qfrc_applied + J'*xfrc_applied + qfrc_actuator   (nv x 1)
		/// </summary>
		public double* qfrc_inverse;
		/// <summary>
		/// com-based acceleration                           (nbody x 6)
		/// </summary>
		public double* cacc;
		/// <summary>
		/// com-based interaction force with parent          (nbody x 6)
		/// </summary>
		public double* cfrc_int;
		/// <summary>
		/// com-based external force on body                 (nbody x 6)
		/// </summary>
		public double* cfrc_ext;
		/// <summary>
		/// array of all detected contacts                   (ncon x 1)
		/// </summary>
		public mjContact* contact;
		/// <summary>
		/// constraint type (mjtConstraint)                  (nefc x 1)
		/// </summary>
		public int* efc_type;
		/// <summary>
		/// id of object of specified type                   (nefc x 1)
		/// </summary>
		public int* efc_id;
		/// <summary>
		/// number of non-zeros in constraint Jacobian row   (nefc x 1)
		/// </summary>
		public int* efc_J_rownnz;
		/// <summary>
		/// row start address in colind array                (nefc x 1)
		/// </summary>
		public int* efc_J_rowadr;
		/// <summary>
		/// number of subsequent rows in supernode           (nefc x 1)
		/// </summary>
		public int* efc_J_rowsuper;
		/// <summary>
		/// column indices in constraint Jacobian            (nJ x 1)
		/// </summary>
		public int* efc_J_colind;
		/// <summary>
		/// constraint Jacobian                              (nJ x 1)
		/// </summary>
		public double* efc_J;
		/// <summary>
		/// constraint position (equality, contact)          (nefc x 1)
		/// </summary>
		public double* efc_pos;
		/// <summary>
		/// inclusion margin (contact)                       (nefc x 1)
		/// </summary>
		public double* efc_margin;
		/// <summary>
		/// frictionloss (friction)                          (nefc x 1)
		/// </summary>
		public double* efc_frictionloss;
		/// <summary>
		/// diagonal of A matrix, approximate or exact       (nefc x 1)
		/// </summary>
		public double* efc_diagA;
		/// <summary>
		/// stiffness, damping, impedance, imp'              (nefc x 4)
		/// </summary>
		public double* efc_KBIP;
		/// <summary>
		/// constraint mass                                  (nefc x 1)
		/// </summary>
		public double* efc_D;
		/// <summary>
		/// inverse constraint mass                          (nefc x 1)
		/// </summary>
		public double* efc_R;
		/// <summary>
		/// first efc address involving tendon; -1: none     (ntendon x 1)
		/// </summary>
		public int* tendon_efcadr;
		/// <summary>
		/// island id of this tree; -1: none                 (ntree x 1)
		/// </summary>
		public int* tree_island;
		/// <summary>
		/// number of trees in this island                   (nisland x 1)
		/// </summary>
		public int* island_ntree;
		/// <summary>
		/// island start address in itree vector             (nisland x 1)
		/// </summary>
		public int* island_itreeadr;
		/// <summary>
		/// map from itree to tree                           (ntree x 1)
		/// </summary>
		public int* map_itree2tree;
		/// <summary>
		/// island id of this dof; -1: none                  (nv x 1)
		/// </summary>
		public int* dof_island;
		/// <summary>
		/// number of dofs in this island                    (nisland x 1)
		/// </summary>
		public int* island_nv;
		/// <summary>
		/// island start address in idof vector              (nisland x 1)
		/// </summary>
		public int* island_idofadr;
		/// <summary>
		/// island start address in dof vector               (nisland x 1)
		/// </summary>
		public int* island_dofadr;
		/// <summary>
		/// map from dof to idof                             (nv x 1)
		/// </summary>
		public int* map_dof2idof;
		/// <summary>
		/// map from idof to dof;  &gt;= nidof: unconstrained   (nv x 1)
		/// </summary>
		public int* map_idof2dof;
		/// <summary>
		/// net unconstrained force                          (nidof x 1)
		/// </summary>
		public double* ifrc_smooth;
		/// <summary>
		/// unconstrained acceleration                       (nidof x 1)
		/// </summary>
		public double* iacc_smooth;
		/// <summary>
		/// acceleration                                     (nidof x 1)
		/// </summary>
		public double* iacc;
		/// <summary>
		/// island id of this constraint                     (nefc x 1)
		/// </summary>
		public int* efc_island;
		/// <summary>
		/// number of equality constraints in island         (nisland x 1)
		/// </summary>
		public int* island_ne;
		/// <summary>
		/// number of friction constraints in island         (nisland x 1)
		/// </summary>
		public int* island_nf;
		/// <summary>
		/// number of constraints in island                  (nisland x 1)
		/// </summary>
		public int* island_nefc;
		/// <summary>
		/// start address in iefc vector                     (nisland x 1)
		/// </summary>
		public int* island_iefcadr;
		/// <summary>
		/// map from efc to iefc                             (nefc x 1)
		/// </summary>
		public int* map_efc2iefc;
		/// <summary>
		/// map from iefc to efc                             (nefc x 1)
		/// </summary>
		public int* map_iefc2efc;
		/// <summary>
		/// constraint type (mjtConstraint)                  (nefc x 1)
		/// </summary>
		public int* iefc_type;
		/// <summary>
		/// id of object of specified type                   (nefc x 1)
		/// </summary>
		public int* iefc_id;
		/// <summary>
		/// frictionloss (friction)                          (nefc x 1)
		/// </summary>
		public double* iefc_frictionloss;
		/// <summary>
		/// constraint mass                                  (nefc x 1)
		/// </summary>
		public double* iefc_D;
		/// <summary>
		/// inverse constraint mass                          (nefc x 1)
		/// </summary>
		public double* iefc_R;
		/// <summary>
		/// number of non-zeros in Y row                     (nefc x 1)
		/// </summary>
		public int* efc_Y_rownnz;
		/// <summary>
		/// row start address in Y colind array              (nefc x 1)
		/// </summary>
		public int* efc_Y_rowadr;
		/// <summary>
		/// column indices in sparse Y                       (nY x 1)
		/// </summary>
		public int* efc_Y_colind;
		/// <summary>
		/// whitened Jacobian Y = J*M^(-1/2)                 (nY x 1)
		/// </summary>
		public double* efc_Y;
		/// <summary>
		/// number of non-zeros in AR                        (nefc x 1)
		/// </summary>
		public int* efc_AR_rownnz;
		/// <summary>
		/// row start address in AR colind array             (nefc x 1)
		/// </summary>
		public int* efc_AR_rowadr;
		/// <summary>
		/// column indices in sparse AR                      (nA x 1)
		/// </summary>
		public int* efc_AR_colind;
		/// <summary>
		/// J*inv(M)*J' + R                                  (nA x 1)
		/// </summary>
		public double* efc_AR;
		/// <summary>
		/// velocity in constraint space: J*qvel             (nefc x 1)
		/// </summary>
		public double* efc_vel;
		/// <summary>
		/// reference pseudo-acceleration                    (nefc x 1)
		/// </summary>
		public double* efc_aref;
		/// <summary>
		/// smooth-force shift h*K*qvel                      (nv x 1)
		/// </summary>
		public double* efm_c;
		/// <summary>
		/// effective-stiffness CSR row nonzeros             (nv x 1)
		/// </summary>
		public int* efm_K_rownnz;
		/// <summary>
		/// effective-stiffness CSR row addresses            (nv x 1)
		/// </summary>
		public int* efm_K_rowadr;
		/// <summary>
		/// effective-stiffness CSR column indices           (nefmK x 1)
		/// </summary>
		public int* efm_K_colind;
		/// <summary>
		/// effective-stiffness CSR values                   (nefmK x 1)
		/// </summary>
		public double* efm_K_val;
		/// <summary>
		/// factor row -&gt; dof address                        (nefmdof x 1)
		/// </summary>
		public int* efm_dofid;
		/// <summary>
		/// factor row nonzeros                              (nefmdof x 1)
		/// </summary>
		public int* efm_L_rownnz;
		/// <summary>
		/// factor row addresses                             (nefmdof x 1)
		/// </summary>
		public int* efm_L_rowadr;
		/// <summary>
		/// factor column indices                            (nefmL x 1)
		/// </summary>
		public int* efm_L_colind;
		/// <summary>
		/// Cholesky factor of diag(M)+K, covered dofs       (nefmL x 1)
		/// </summary>
		public double* efm_L;
		/// <summary>
		/// linear cost term: J*qacc_smooth - aref           (nefc x 1)
		/// </summary>
		public double* efc_b;
		/// <summary>
		/// reference pseudo-acceleration                    (nefc x 1)
		/// </summary>
		public double* iefc_aref;
		/// <summary>
		/// constraint state (mjtConstraintState)            (nefc x 1)
		/// </summary>
		public int* iefc_state;
		/// <summary>
		/// constraint force in constraint space             (nefc x 1)
		/// </summary>
		public double* iefc_force;
		/// <summary>
		/// constraint state (mjtConstraintState)            (nefc x 1)
		/// </summary>
		public int* efc_state;
		/// <summary>
		/// constraint force in constraint space             (nefc x 1)
		/// </summary>
		public double* efc_force;
		/// <summary>
		/// constraint force                                 (nidof x 1)
		/// </summary>
		public double* ifrc_constraint;
		/// <summary>
		/// also held by the mjSpec that compiled the model
		/// </summary>
		public ulong signature;
	}

	/// <summary>
	/// -------------------------------- attribute structs (mjs) -----------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsElement
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjtObj elemtype;
		/// <summary>
		/// compilation signature
		/// </summary>
		public ulong signature;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsCompiler
	{
		/// <summary>
		/// infer "limited" attribute based on range
		/// </summary>
		public byte autolimits;
		/// <summary>
		/// enforce minimum body mass
		/// </summary>
		public double boundmass;
		/// <summary>
		/// enforce minimum body diagonal inertia
		/// </summary>
		public double boundinertia;
		/// <summary>
		/// rescale masses and inertias;
		/// &lt;
		/// =0: ignore
		/// </summary>
		public double settotalmass;
		/// <summary>
		/// automatically impose A + B &gt;= C rule
		/// </summary>
		public byte balanceinertia;
		/// <summary>
		/// meshfit to aabb instead of inertia box
		/// </summary>
		public byte fitaabb;
		/// <summary>
		/// angles in radians or degrees
		/// </summary>
		public byte degree;
		/// <summary>
		/// sequence for euler rotations
		/// </summary>
		public fixed byte eulerseq[3];
		/// <summary>
		/// discard visual geoms in parser
		/// </summary>
		public byte discardvisual;
		/// <summary>
		/// use multiple threads to speed up compiler
		/// </summary>
		public byte usethread;
		/// <summary>
		/// fuse static bodies with parent
		/// </summary>
		public byte fusestatic;
		/// <summary>
		/// use geom inertias
		/// </summary>
		public mjtInertiaFromGeom inertiafromgeom;
		/// <summary>
		/// range of geom groups used to compute inertia
		/// </summary>
		public fixed int inertiagrouprange[2];
		/// <summary>
		/// save explicit inertial clause for all bodies to XML
		/// </summary>
		public byte saveinertial;
		/// <summary>
		/// align free joints with inertial frame
		/// </summary>
		public byte alignfree;
		/// <summary>
		/// conflict resolution for attach
		/// </summary>
		public mjtConflict conflict;
		/// <summary>
		/// options for lengthrange computation
		/// </summary>
		public mjLROpt LRopt;
		/// <summary>
		/// mesh and hfield directory
		/// </summary>
		public void* meshdir;
		/// <summary>
		/// texture directory
		/// </summary>
		public void* texturedir;
		/// <summary>
		/// bitmask of authored compiler fields
		/// </summary>
		public ulong authored;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsAuthored
	{
		/// <summary>
		/// authored mjOption fields
		/// </summary>
		public ulong option;
		/// <summary>
		/// individual authored disable flags
		/// </summary>
		public int disableflags;
		/// <summary>
		/// individual authored enable flags
		/// </summary>
		public int enableflags;
		/// <summary>
		/// individual authored actuator groups
		/// </summary>
		public int disableactuator;
		/// <summary>
		/// authored visual.global fields
		/// </summary>
		public ulong visual_global;
		/// <summary>
		/// authored visual.quality fields
		/// </summary>
		public ulong visual_quality;
		/// <summary>
		/// authored visual.headlight fields
		/// </summary>
		public ulong visual_headlight;
		/// <summary>
		/// authored visual.map fields
		/// </summary>
		public ulong visual_map;
		/// <summary>
		/// authored visual.scale fields
		/// </summary>
		public ulong visual_scale;
		/// <summary>
		/// authored visual.rgba fields
		/// </summary>
		public ulong visual_rgba;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjSpec
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// model name
		/// </summary>
		public void* modelname;
		/// <summary>
		/// compiler options
		/// </summary>
		public mjsCompiler compiler;
		/// <summary>
		/// automatically strip paths from mesh files
		/// </summary>
		public byte strippath;
		/// <summary>
		/// physics options
		/// </summary>
		public mjOption option;
		/// <summary>
		/// visual options
		/// </summary>
		public mjVisual visual;
		/// <summary>
		/// statistics override (if defined)
		/// </summary>
		public mjStatistic stat;
		/// <summary>
		/// number of bytes in arena+stack memory
		/// </summary>
		public long memory;
		/// <summary>
		/// max number of equality constraints
		/// </summary>
		public int nemax;
		/// <summary>
		/// number of mjtNums in userdata
		/// </summary>
		public int nuserdata;
		/// <summary>
		/// number of mjtNums in body_user
		/// </summary>
		public int nuser_body;
		/// <summary>
		/// number of mjtNums in jnt_user
		/// </summary>
		public int nuser_jnt;
		/// <summary>
		/// number of mjtNums in geom_user
		/// </summary>
		public int nuser_geom;
		/// <summary>
		/// number of mjtNums in site_user
		/// </summary>
		public int nuser_site;
		/// <summary>
		/// number of mjtNums in cam_user
		/// </summary>
		public int nuser_cam;
		/// <summary>
		/// number of mjtNums in tendon_user
		/// </summary>
		public int nuser_tendon;
		/// <summary>
		/// number of mjtNums in actuator_user
		/// </summary>
		public int nuser_actuator;
		/// <summary>
		/// number of mjtNums in sensor_user
		/// </summary>
		public int nuser_sensor;
		/// <summary>
		/// number of keyframes
		/// </summary>
		public int nkey;
		/// <summary>
		/// (deprecated) max number of constraints
		/// </summary>
		public int njmax;
		/// <summary>
		/// (deprecated) max number of detected contacts
		/// </summary>
		public int nconmax;
		/// <summary>
		/// (deprecated) number of mjtNums in mjData stack
		/// </summary>
		public long nstack;
		/// <summary>
		/// comment at top of XML
		/// </summary>
		public void* comment;
		/// <summary>
		/// path to model file
		/// </summary>
		public void* modelfiledir;
		/// <summary>
		/// already encountered an implicit plugin sensor/actuator
		/// </summary>
		public byte hasImplicitPluginElem;
		/// <summary>
		/// authored tracking bitmasks for mjModel structs
		/// </summary>
		public mjsAuthored authored;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsOrientation
	{
		/// <summary>
		/// active orientation specifier
		/// </summary>
		public mjtOrientation type;
		/// <summary>
		/// axis and angle
		/// </summary>
		public fixed double axisangle[4];
		/// <summary>
		/// x and y axes
		/// </summary>
		public fixed double xyaxes[6];
		/// <summary>
		/// z axis (minimal rotation)
		/// </summary>
		public fixed double zaxis[3];
		/// <summary>
		/// Euler angles
		/// </summary>
		public fixed double euler[3];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsPlugin
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// instance name
		/// </summary>
		public void* name;
		/// <summary>
		/// plugin name
		/// </summary>
		public void* plugin_name;
		/// <summary>
		/// is the plugin active
		/// </summary>
		public byte active;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsBody
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// childclass name
		/// </summary>
		public void* childclass;
		/// <summary>
		/// frame position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// frame orientation
		/// </summary>
		public fixed double quat[4];
		/// <summary>
		/// frame alternative orientation
		/// </summary>
		public mjsOrientation alt;
		/// <summary>
		/// mass
		/// </summary>
		public double mass;
		/// <summary>
		/// inertial frame position
		/// </summary>
		public fixed double ipos[3];
		/// <summary>
		/// inertial frame orientation
		/// </summary>
		public fixed double iquat[4];
		/// <summary>
		/// diagonal inertia (in i-frame)
		/// </summary>
		public fixed double inertia[3];
		/// <summary>
		/// inertial frame alternative orientation
		/// </summary>
		public mjsOrientation ialt;
		/// <summary>
		/// non-axis-aligned inertia matrix
		/// </summary>
		public fixed double fullinertia[6];
		/// <summary>
		/// is this a mocap body
		/// </summary>
		public byte mocap;
		/// <summary>
		/// gravity compensation
		/// </summary>
		public double gravcomp;
		/// <summary>
		/// sleep policy
		/// </summary>
		public mjtSleepPolicy sleep;
		/// <summary>
		/// simple body optimization (0: false, 1: auto)
		/// </summary>
		public byte simple;
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// whether to save the body with explicit inertial clause
		/// </summary>
		public byte explicitinertial;
		/// <summary>
		/// passive force plugin
		/// </summary>
		public mjsPlugin plugin;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsFrame
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// childclass name
		/// </summary>
		public void* childclass;
		/// <summary>
		/// position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// orientation
		/// </summary>
		public fixed double quat[4];
		/// <summary>
		/// alternative orientation
		/// </summary>
		public mjsOrientation alt;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsJoint
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// joint type
		/// </summary>
		public mjtJoint type;
		/// <summary>
		/// anchor position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// joint axis
		/// </summary>
		public fixed double axis[3];
		/// <summary>
		/// value at reference configuration: qpos0
		/// </summary>
		public double @ref;
		/// <summary>
		/// align free joint with body com
		/// </summary>
		public mjtAlignFree align;
		/// <summary>
		/// stiffness coefficients
		/// </summary>
		public fixed double stiffness[3];
		/// <summary>
		/// spring reference value: qpos_spring
		/// </summary>
		public double springref;
		/// <summary>
		/// timeconst, dampratio
		/// </summary>
		public fixed double springdamper[2];
		/// <summary>
		/// does joint have limits
		/// </summary>
		public mjtLimited limited;
		/// <summary>
		/// joint limits
		/// </summary>
		public fixed double range[2];
		/// <summary>
		/// margin value for joint limit detection
		/// </summary>
		public double margin;
		/// <summary>
		/// solver reference: joint limits
		/// </summary>
		public fixed double solref_limit[2];
		/// <summary>
		/// solver impedance: joint limits
		/// </summary>
		public fixed double solimp_limit[5];
		/// <summary>
		/// are actuator forces on joint limited
		/// </summary>
		public mjtLimited actfrclimited;
		/// <summary>
		/// actuator force limits
		/// </summary>
		public fixed double actfrcrange[2];
		/// <summary>
		/// armature inertia (mass for slider)
		/// </summary>
		public double armature;
		/// <summary>
		/// damping coefficients
		/// </summary>
		public fixed double damping[3];
		/// <summary>
		/// friction loss
		/// </summary>
		public double frictionloss;
		/// <summary>
		/// solver reference: dof friction
		/// </summary>
		public fixed double solref_friction[2];
		/// <summary>
		/// solver impedance: dof friction
		/// </summary>
		public fixed double solimp_friction[5];
		/// <summary>
		/// group
		/// </summary>
		public int group;
		/// <summary>
		/// is gravcomp force applied via actuators
		/// </summary>
		public byte actgravcomp;
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsGeom
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// geom type
		/// </summary>
		public mjtGeom type;
		/// <summary>
		/// position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// orientation
		/// </summary>
		public fixed double quat[4];
		/// <summary>
		/// alternative orientation
		/// </summary>
		public mjsOrientation alt;
		/// <summary>
		/// alternative for capsule, cylinder, box, ellipsoid
		/// </summary>
		public fixed double fromto[6];
		/// <summary>
		/// type-specific size
		/// </summary>
		public fixed double size[3];
		/// <summary>
		/// contact type
		/// </summary>
		public int contype;
		/// <summary>
		/// contact affinity
		/// </summary>
		public int conaffinity;
		/// <summary>
		/// contact dimensionality
		/// </summary>
		public int condim;
		/// <summary>
		/// contact priority
		/// </summary>
		public int priority;
		/// <summary>
		/// one-sided friction coefficients: slide, roll, spin
		/// </summary>
		public fixed double friction[3];
		/// <summary>
		/// solver mixing for contact pairs
		/// </summary>
		public double solmix;
		/// <summary>
		/// solver reference
		/// </summary>
		public fixed double solref[2];
		/// <summary>
		/// solver impedance
		/// </summary>
		public fixed double solimp[5];
		/// <summary>
		/// margin for contact detection
		/// </summary>
		public double margin;
		/// <summary>
		/// additional contact detection buffer
		/// </summary>
		public double gap;
		/// <summary>
		/// surface velocity in local frame: linear, angular
		/// </summary>
		public fixed double surfacevel[6];
		/// <summary>
		/// adhesive force of contacts
		/// </summary>
		public double adhesion;
		/// <summary>
		/// used to compute density
		/// </summary>
		public double mass;
		/// <summary>
		/// used to compute mass and inertia from volume or surface
		/// </summary>
		public double density;
		/// <summary>
		/// selects between surface and volume inertia
		/// </summary>
		public mjtGeomInertia typeinertia;
		/// <summary>
		/// whether ellipsoid-fluid model is active
		/// </summary>
		public double fluid_ellipsoid;
		/// <summary>
		/// ellipsoid-fluid interaction coefs
		/// </summary>
		public fixed double fluid_coefs[5];
		/// <summary>
		/// name of material
		/// </summary>
		public void* material;
		/// <summary>
		/// rgba when material is omitted
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// group
		/// </summary>
		public int group;
		/// <summary>
		/// heightfield attached to geom
		/// </summary>
		public void* hfieldname;
		/// <summary>
		/// mesh attached to geom
		/// </summary>
		public void* meshname;
		/// <summary>
		/// scale mesh uniformly
		/// </summary>
		public double fitscale;
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// sdf plugin
		/// </summary>
		public mjsPlugin plugin;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsSite
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// orientation
		/// </summary>
		public fixed double quat[4];
		/// <summary>
		/// alternative orientation
		/// </summary>
		public mjsOrientation alt;
		/// <summary>
		/// alternative for capsule, cylinder, box, ellipsoid
		/// </summary>
		public fixed double fromto[6];
		/// <summary>
		/// geom size
		/// </summary>
		public fixed double size[3];
		/// <summary>
		/// geom type
		/// </summary>
		public mjtGeom type;
		/// <summary>
		/// name of material
		/// </summary>
		public void* material;
		/// <summary>
		/// group
		/// </summary>
		public int group;
		/// <summary>
		/// rgba when material is omitted
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsCamera
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// orientation
		/// </summary>
		public fixed double quat[4];
		/// <summary>
		/// alternative orientation
		/// </summary>
		public mjsOrientation alt;
		/// <summary>
		/// tracking mode
		/// </summary>
		public mjtCamLight mode;
		/// <summary>
		/// target body for tracking/targeting
		/// </summary>
		public void* targetbody;
		/// <summary>
		/// camera projection type
		/// </summary>
		public mjtProjection proj;
		/// <summary>
		/// resolution (pixel)
		/// </summary>
		public fixed int resolution[2];
		/// <summary>
		/// bit flags for output type
		/// </summary>
		public int output;
		/// <summary>
		/// y-field of view
		/// </summary>
		public double fovy;
		/// <summary>
		/// inter-pupillary distance
		/// </summary>
		public double ipd;
		/// <summary>
		/// camera intrinsics (length)
		/// </summary>
		public fixed float intrinsic[4];
		/// <summary>
		/// sensor size (length)
		/// </summary>
		public fixed float sensor_size[2];
		/// <summary>
		/// focal length (length)
		/// </summary>
		public fixed float focal_length[2];
		/// <summary>
		/// focal length (pixel)
		/// </summary>
		public fixed float focal_pixel[2];
		/// <summary>
		/// principal point (length)
		/// </summary>
		public fixed float principal_length[2];
		/// <summary>
		/// principal point (pixel)
		/// </summary>
		public fixed float principal_pixel[2];
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsLight
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// position
		/// </summary>
		public fixed double pos[3];
		/// <summary>
		/// direction
		/// </summary>
		public fixed double dir[3];
		/// <summary>
		/// tracking mode
		/// </summary>
		public mjtCamLight mode;
		/// <summary>
		/// target body for targeting
		/// </summary>
		public void* targetbody;
		/// <summary>
		/// is light active
		/// </summary>
		public byte active;
		/// <summary>
		/// type of light
		/// </summary>
		public mjtLightType type;
		/// <summary>
		/// texture name for image lights
		/// </summary>
		public void* texture;
		/// <summary>
		/// does light cast shadows
		/// </summary>
		public byte castshadow;
		/// <summary>
		/// bulb radius, for soft shadows
		/// </summary>
		public float bulbradius;
		/// <summary>
		/// intensity, in candelas
		/// </summary>
		public float intensity;
		/// <summary>
		/// range of effectiveness
		/// </summary>
		public float range;
		/// <summary>
		/// OpenGL attenuation (quadratic model)
		/// </summary>
		public fixed float attenuation[3];
		/// <summary>
		/// OpenGL cutoff
		/// </summary>
		public float cutoff;
		/// <summary>
		/// OpenGL exponent
		/// </summary>
		public float exponent;
		/// <summary>
		/// ambient color
		/// </summary>
		public fixed float ambient[3];
		/// <summary>
		/// diffuse color
		/// </summary>
		public fixed float diffuse[3];
		/// <summary>
		/// specular color
		/// </summary>
		public fixed float specular[3];
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsFlex
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// contact type
		/// </summary>
		public int contype;
		/// <summary>
		/// contact affinity
		/// </summary>
		public int conaffinity;
		/// <summary>
		/// contact dimensionality
		/// </summary>
		public int condim;
		/// <summary>
		/// contact priority
		/// </summary>
		public int priority;
		/// <summary>
		/// one-sided friction coefficients: slide, roll, spin
		/// </summary>
		public fixed double friction[3];
		/// <summary>
		/// solver mixing for contact pairs
		/// </summary>
		public double solmix;
		/// <summary>
		/// solver reference
		/// </summary>
		public fixed double solref[2];
		/// <summary>
		/// solver impedance
		/// </summary>
		public fixed double solimp[5];
		/// <summary>
		/// margin for contact detection
		/// </summary>
		public double margin;
		/// <summary>
		/// additional contact detection buffer
		/// </summary>
		public double gap;
		/// <summary>
		/// element dimensionality
		/// </summary>
		public int dim;
		/// <summary>
		/// radius around primitive element
		/// </summary>
		public double radius;
		/// <summary>
		/// vertex bounding box half sizes in qpos0
		/// </summary>
		public fixed double size[3];
		/// <summary>
		/// enable internal collisions
		/// </summary>
		public byte @internal;
		/// <summary>
		/// render flex skin with flat shading
		/// </summary>
		public byte flatskin;
		/// <summary>
		/// mode for flex self collision
		/// </summary>
		public mjtFlexSelf selfcollide;
		/// <summary>
		/// mode for passive collisions
		/// </summary>
		public int passive;
		/// <summary>
		/// number of active element layers in 3D
		/// </summary>
		public int activelayers;
		/// <summary>
		/// group for visualization
		/// </summary>
		public int group;
		/// <summary>
		/// edge stiffness
		/// </summary>
		public double edgestiffness;
		/// <summary>
		/// edge damping
		/// </summary>
		public double edgedamping;
		/// <summary>
		/// rgba when material is omitted
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// name of material used for rendering
		/// </summary>
		public void* material;
		/// <summary>
		/// Young's modulus
		/// </summary>
		public double young;
		/// <summary>
		/// Poisson's ratio
		/// </summary>
		public double poisson;
		/// <summary>
		/// Rayleigh's damping
		/// </summary>
		public double damping;
		/// <summary>
		/// thickness (2D only)
		/// </summary>
		public double thickness;
		/// <summary>
		/// 2D passive forces; 0: none, 1: bending, 2: stretching, 3: both
		/// </summary>
		public int elastic2d;
		/// <summary>
		/// grid cell count for finite cell method
		/// </summary>
		public fixed int cellcount[3];
		/// <summary>
		/// interpolation order (1: trilinear, 2: quadratic)
		/// </summary>
		public int order;
		/// <summary>
		/// node body names
		/// </summary>
		public void* nodebody;
		/// <summary>
		/// vertex body names
		/// </summary>
		public void* vertbody;
		/// <summary>
		/// node positions
		/// </summary>
		public void* node;
		/// <summary>
		/// vertex positions
		/// </summary>
		public void* vert;
		/// <summary>
		/// element vertex ids
		/// </summary>
		public void* elem;
		/// <summary>
		/// vertex texture coordinates
		/// </summary>
		public void* texcoord;
		/// <summary>
		/// element texture coordinates
		/// </summary>
		public void* elemtexcoord;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsMesh
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// content type of file
		/// </summary>
		public void* content_type;
		/// <summary>
		/// mesh file
		/// </summary>
		public void* file;
		/// <summary>
		/// reference position
		/// </summary>
		public fixed double refpos[3];
		/// <summary>
		/// reference orientation
		/// </summary>
		public fixed double refquat[4];
		/// <summary>
		/// rescale mesh
		/// </summary>
		public fixed double scale[3];
		/// <summary>
		/// inertia type (convex, legacy, exact, shell)
		/// </summary>
		public mjtMeshInertia inertia;
		/// <summary>
		/// do not exclude large-angle faces from normals
		/// </summary>
		public byte smoothnormal;
		/// <summary>
		/// compute sdf from mesh
		/// </summary>
		public byte needsdf;
		/// <summary>
		/// maximum vertex count for the convex hull
		/// </summary>
		public int maxhullvert;
		/// <summary>
		/// user vertex data
		/// </summary>
		public void* uservert;
		/// <summary>
		/// user normal data
		/// </summary>
		public void* usernormal;
		/// <summary>
		/// user texcoord data
		/// </summary>
		public void* usertexcoord;
		/// <summary>
		/// user vertex indices
		/// </summary>
		public void* userface;
		/// <summary>
		/// user face normal indices
		/// </summary>
		public void* userfacenormal;
		/// <summary>
		/// user texcoord indices
		/// </summary>
		public void* userfacetexcoord;
		/// <summary>
		/// sdf plugin
		/// </summary>
		public mjsPlugin plugin;
		/// <summary>
		/// name of material
		/// </summary>
		public void* material;
		/// <summary>
		/// max octree depth
		/// </summary>
		public int octree_maxdepth;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsHField
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// content type of file
		/// </summary>
		public void* content_type;
		/// <summary>
		/// file: (nrow, ncol, [elevation data])
		/// </summary>
		public void* file;
		/// <summary>
		/// hfield size (ignore referencing geom size)
		/// </summary>
		public fixed double size[4];
		/// <summary>
		/// number of rows
		/// </summary>
		public int nrow;
		/// <summary>
		/// number of columns
		/// </summary>
		public int ncol;
		/// <summary>
		/// user-provided elevation data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsSkin
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// skin file
		/// </summary>
		public void* file;
		/// <summary>
		/// name of material used for rendering
		/// </summary>
		public void* material;
		/// <summary>
		/// rgba when material is omitted
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// inflate in normal direction
		/// </summary>
		public float inflate;
		/// <summary>
		/// group for visualization
		/// </summary>
		public int group;
		/// <summary>
		/// vertex positions
		/// </summary>
		public void* vert;
		/// <summary>
		/// texture coordinates
		/// </summary>
		public void* texcoord;
		/// <summary>
		/// faces
		/// </summary>
		public void* face;
		/// <summary>
		/// body names
		/// </summary>
		public void* bodyname;
		/// <summary>
		/// bind pos
		/// </summary>
		public void* bindpos;
		/// <summary>
		/// bind quat
		/// </summary>
		public void* bindquat;
		/// <summary>
		/// vertex ids
		/// </summary>
		public void* vertid;
		/// <summary>
		/// vertex weights
		/// </summary>
		public void* vertweight;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsTexture
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// texture type
		/// </summary>
		public mjtTexture type;
		/// <summary>
		/// colorspace
		/// </summary>
		public mjtColorSpace colorspace;
		/// <summary>
		/// builtin type
		/// </summary>
		public mjtBuiltin builtin;
		/// <summary>
		/// mark type
		/// </summary>
		public mjtMark mark;
		/// <summary>
		/// first color for builtin
		/// </summary>
		public fixed double rgb1[3];
		/// <summary>
		/// second color for builtin
		/// </summary>
		public fixed double rgb2[3];
		/// <summary>
		/// mark color
		/// </summary>
		public fixed double markrgb[3];
		/// <summary>
		/// probability of random dots
		/// </summary>
		public double random;
		/// <summary>
		/// height in pixels (square for cube and skybox)
		/// </summary>
		public int height;
		/// <summary>
		/// width in pixels
		/// </summary>
		public int width;
		/// <summary>
		/// number of channels
		/// </summary>
		public int nchannel;
		/// <summary>
		/// content type of file
		/// </summary>
		public void* content_type;
		/// <summary>
		/// png file to load; use for all sides of cube
		/// </summary>
		public void* file;
		/// <summary>
		/// size of grid for composite file; (1,1)-repeat
		/// </summary>
		public fixed int gridsize[2];
		/// <summary>
		/// row-major: L,R,F,B,U,D for faces; . for unused
		/// </summary>
		public fixed byte gridlayout[12];
		/// <summary>
		/// different file for each side of the cube
		/// </summary>
		public void* cubefiles;
		/// <summary>
		/// texture data
		/// </summary>
		public void* data;
		/// <summary>
		/// horizontal flip
		/// </summary>
		public byte hflip;
		/// <summary>
		/// vertical flip
		/// </summary>
		public byte vflip;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsMaterial
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// names of textures (empty: none)
		/// </summary>
		public void* textures;
		/// <summary>
		/// make texture cube uniform
		/// </summary>
		public byte texuniform;
		/// <summary>
		/// texture repetition for 2D mapping
		/// </summary>
		public fixed float texrepeat[2];
		/// <summary>
		/// emission
		/// </summary>
		public float emission;
		/// <summary>
		/// specular
		/// </summary>
		public float specular;
		/// <summary>
		/// shininess
		/// </summary>
		public float shininess;
		/// <summary>
		/// reflectance
		/// </summary>
		public float reflectance;
		/// <summary>
		/// metallic
		/// </summary>
		public float metallic;
		/// <summary>
		/// roughness
		/// </summary>
		public float roughness;
		/// <summary>
		/// rgba
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsPair
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// name of geom 1
		/// </summary>
		public void* geomname1;
		/// <summary>
		/// name of geom 2
		/// </summary>
		public void* geomname2;
		/// <summary>
		/// contact dimensionality
		/// </summary>
		public int condim;
		/// <summary>
		/// solver reference, normal direction
		/// </summary>
		public fixed double solref[2];
		/// <summary>
		/// solver reference, frictional directions
		/// </summary>
		public fixed double solreffriction[2];
		/// <summary>
		/// solver impedance
		/// </summary>
		public fixed double solimp[5];
		/// <summary>
		/// margin for contact detection
		/// </summary>
		public double margin;
		/// <summary>
		/// additional contact detection buffer
		/// </summary>
		public double gap;
		/// <summary>
		/// adhesive force of contacts
		/// </summary>
		public double adhesion;
		/// <summary>
		/// full contact friction
		/// </summary>
		public fixed double friction[5];
		/// <summary>
		/// message appended to errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsExclude
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// name of geom 1
		/// </summary>
		public void* bodyname1;
		/// <summary>
		/// name of geom 2
		/// </summary>
		public void* bodyname2;
		/// <summary>
		/// message appended to errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsEquality
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// constraint type
		/// </summary>
		public mjtEq type;
		/// <summary>
		/// type-dependent data
		/// </summary>
		public fixed double data[11];
		/// <summary>
		/// is equality initially active
		/// </summary>
		public byte active;
		/// <summary>
		/// name of object 1
		/// </summary>
		public void* name1;
		/// <summary>
		/// name of object 2
		/// </summary>
		public void* name2;
		/// <summary>
		/// type of both objects
		/// </summary>
		public mjtObj objtype;
		/// <summary>
		/// solver reference
		/// </summary>
		public fixed double solref[2];
		/// <summary>
		/// solver impedance
		/// </summary>
		public fixed double solimp[5];
		/// <summary>
		/// message appended to errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsTendon
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// stiffness coefficients
		/// </summary>
		public fixed double stiffness[3];
		/// <summary>
		/// spring resting length; {-1, -1}: use qpos_spring
		/// </summary>
		public fixed double springlength[2];
		/// <summary>
		/// damping coefficients
		/// </summary>
		public fixed double damping[3];
		/// <summary>
		/// friction loss
		/// </summary>
		public double frictionloss;
		/// <summary>
		/// solver reference: tendon friction
		/// </summary>
		public fixed double solref_friction[2];
		/// <summary>
		/// solver impedance: tendon friction
		/// </summary>
		public fixed double solimp_friction[5];
		/// <summary>
		/// inertia associated with tendon velocity
		/// </summary>
		public double armature;
		/// <summary>
		/// does tendon have limits
		/// </summary>
		public mjtLimited limited;
		/// <summary>
		/// does tendon have actuator force limits
		/// </summary>
		public mjtLimited actfrclimited;
		/// <summary>
		/// length limits
		/// </summary>
		public fixed double range[2];
		/// <summary>
		/// actuator force limits
		/// </summary>
		public fixed double actfrcrange[2];
		/// <summary>
		/// margin value for tendon limit detection
		/// </summary>
		public double margin;
		/// <summary>
		/// solver reference: tendon limits
		/// </summary>
		public fixed double solref_limit[2];
		/// <summary>
		/// solver impedance: tendon limits
		/// </summary>
		public fixed double solimp_limit[5];
		/// <summary>
		/// name of material for rendering
		/// </summary>
		public void* material;
		/// <summary>
		/// width for rendering
		/// </summary>
		public double width;
		/// <summary>
		/// rgba when material is omitted
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// group
		/// </summary>
		public int group;
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// message appended to errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsWrap
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// wrap type
		/// </summary>
		public mjtWrap type;
		/// <summary>
		/// message appended to errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsActuator
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// gain type
		/// </summary>
		public mjtGain gaintype;
		/// <summary>
		/// gain parameters
		/// </summary>
		public fixed double gainprm[10];
		/// <summary>
		/// bias type
		/// </summary>
		public mjtBias biastype;
		/// <summary>
		/// bias parameters
		/// </summary>
		public fixed double biasprm[10];
		/// <summary>
		/// dynamics type
		/// </summary>
		public mjtDyn dyntype;
		/// <summary>
		/// dynamics parameters
		/// </summary>
		public fixed double dynprm[10];
		/// <summary>
		/// number of activation variables
		/// </summary>
		public int actdim;
		/// <summary>
		/// input signature, scoped by gaintype; 0: type default
		/// </summary>
		public int ctrlspec;
		/// <summary>
		/// apply next activations to qfrc
		/// </summary>
		public byte actearly;
		/// <summary>
		/// transmission type
		/// </summary>
		public mjtTrn trntype;
		/// <summary>
		/// length and transmitted force scaling
		/// </summary>
		public fixed double gear[6];
		/// <summary>
		/// name of transmission target
		/// </summary>
		public void* target;
		/// <summary>
		/// reference site, for site transmission
		/// </summary>
		public void* refsite;
		/// <summary>
		/// site defining cylinder, for slider-crank
		/// </summary>
		public void* slidersite;
		/// <summary>
		/// crank length, for slider-crank
		/// </summary>
		public double cranklength;
		/// <summary>
		/// transmission length range
		/// </summary>
		public fixed double lengthrange[2];
		/// <summary>
		/// automatic range setting for position and intvelocity
		/// </summary>
		public double inheritrange;
		/// <summary>
		/// damping coefficients
		/// </summary>
		public fixed double damping[3];
		/// <summary>
		/// armature inertia
		/// </summary>
		public double armature;
		/// <summary>
		/// are control limits defined
		/// </summary>
		public mjtLimited ctrllimited;
		/// <summary>
		/// control range
		/// </summary>
		public fixed double ctrlrange[2];
		/// <summary>
		/// are force limits defined
		/// </summary>
		public mjtLimited forcelimited;
		/// <summary>
		/// force range
		/// </summary>
		public fixed double forcerange[2];
		/// <summary>
		/// are activation limits defined
		/// </summary>
		public mjtLimited actlimited;
		/// <summary>
		/// activation range
		/// </summary>
		public fixed double actrange[2];
		/// <summary>
		/// group
		/// </summary>
		public int group;
		/// <summary>
		/// number of samples in history buffer
		/// </summary>
		public int nsample;
		/// <summary>
		/// interpolation order (0=ZOH, 1=linear, 2=cubic)
		/// </summary>
		public int interp;
		/// <summary>
		/// delay time in seconds; 0: no delay
		/// </summary>
		public double delay;
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// actuator plugin
		/// </summary>
		public mjsPlugin plugin;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsSensor
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// type of sensor
		/// </summary>
		public mjtSensor type;
		/// <summary>
		/// type of sensorized object
		/// </summary>
		public mjtObj objtype;
		/// <summary>
		/// name of sensorized object
		/// </summary>
		public void* objname;
		/// <summary>
		/// type of referenced object
		/// </summary>
		public mjtObj reftype;
		/// <summary>
		/// name of referenced object
		/// </summary>
		public void* refname;
		/// <summary>
		/// integer parameters
		/// </summary>
		public fixed int intprm[3];
		/// <summary>
		/// data type for sensor measurement
		/// </summary>
		public mjtDataType datatype;
		/// <summary>
		/// compute stage needed to simulate sensor
		/// </summary>
		public mjtStage needstage;
		/// <summary>
		/// number of scalar outputs
		/// </summary>
		public int dim;
		/// <summary>
		/// cutoff for real and positive datatypes
		/// </summary>
		public double cutoff;
		/// <summary>
		/// noise stdev
		/// </summary>
		public double noise;
		/// <summary>
		/// number of samples in history buffer
		/// </summary>
		public int nsample;
		/// <summary>
		/// interpolation order (0=ZOH, 1=linear, 2=cubic)
		/// </summary>
		public int interp;
		/// <summary>
		/// delay time in seconds
		/// </summary>
		public double delay;
		/// <summary>
		/// [period, time_prev] in seconds
		/// </summary>
		public fixed double interval[2];
		/// <summary>
		/// user data
		/// </summary>
		public void* userdata;
		/// <summary>
		/// sensor plugin
		/// </summary>
		public mjsPlugin plugin;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsNumeric
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// initialization data
		/// </summary>
		public void* data;
		/// <summary>
		/// array size, can be bigger than data size
		/// </summary>
		public int size;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsText
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// text string
		/// </summary>
		public void* data;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsTuple
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// object types
		/// </summary>
		public void* objtype;
		/// <summary>
		/// object names
		/// </summary>
		public void* objname;
		/// <summary>
		/// object parameters
		/// </summary>
		public void* objprm;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsKey
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// time
		/// </summary>
		public double time;
		/// <summary>
		/// qpos
		/// </summary>
		public void* qpos;
		/// <summary>
		/// qvel
		/// </summary>
		public void* qvel;
		/// <summary>
		/// act
		/// </summary>
		public void* act;
		/// <summary>
		/// mocap pos
		/// </summary>
		public void* mpos;
		/// <summary>
		/// mocap quat
		/// </summary>
		public void* mquat;
		/// <summary>
		/// ctrl
		/// </summary>
		public void* ctrl;
		/// <summary>
		/// message appended to compiler errors
		/// </summary>
		public void* info;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjsDefault
	{
		/// <summary>
		/// element type
		/// </summary>
		public mjsElement* element;
		/// <summary>
		/// joint defaults
		/// </summary>
		public mjsJoint* joint;
		/// <summary>
		/// geom defaults
		/// </summary>
		public mjsGeom* geom;
		/// <summary>
		/// site defaults
		/// </summary>
		public mjsSite* site;
		/// <summary>
		/// camera defaults
		/// </summary>
		public mjsCamera* camera;
		/// <summary>
		/// light defaults
		/// </summary>
		public mjsLight* light;
		/// <summary>
		/// flex defaults
		/// </summary>
		public mjsFlex* flex;
		/// <summary>
		/// mesh defaults
		/// </summary>
		public mjsMesh* mesh;
		/// <summary>
		/// material defaults
		/// </summary>
		public mjsMaterial* material;
		/// <summary>
		/// pair defaults
		/// </summary>
		public mjsPair* pair;
		/// <summary>
		/// equality defaults
		/// </summary>
		public mjsEquality* equality;
		/// <summary>
		/// tendon defaults
		/// </summary>
		public mjsTendon* tendon;
		/// <summary>
		/// actuator defaults
		/// </summary>
		public mjsActuator* actuator;
	}

	/// <summary>
	/// ---------------------------------- mjvPerturb ----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvPerturb
	{
		/// <summary>
		/// selected body id; non-positive: none
		/// </summary>
		public int select;
		/// <summary>
		/// selected flex id; negative: none
		/// </summary>
		public int flexselect;
		/// <summary>
		/// selected skin id; negative: none
		/// </summary>
		public int skinselect;
		/// <summary>
		/// perturbation bitmask (mjtPertBit)
		/// </summary>
		public int active;
		/// <summary>
		/// secondary perturbation bitmask (mjtPertBit)
		/// </summary>
		public int active2;
		/// <summary>
		/// reference position for selected object
		/// </summary>
		public fixed double refpos[3];
		/// <summary>
		/// reference orientation for selected object
		/// </summary>
		public fixed double refquat[4];
		/// <summary>
		/// reference position for selection point
		/// </summary>
		public fixed double refselpos[3];
		/// <summary>
		/// selection point in object coordinates
		/// </summary>
		public fixed double localpos[3];
		/// <summary>
		/// spatial inertia at selection point
		/// </summary>
		public double localmass;
		/// <summary>
		/// relative mouse motion-to-space scaling (set by initPerturb)
		/// </summary>
		public double scale;
	}

	/// <summary>
	/// ---------------------------------- mjvCamera -----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvCamera
	{
		/// <summary>
		/// camera type (mjtCamera)
		/// </summary>
		public int type;
		/// <summary>
		/// fixed camera id
		/// </summary>
		public int fixedcamid;
		/// <summary>
		/// body id to track
		/// </summary>
		public int trackbodyid;
		/// <summary>
		/// lookat point
		/// </summary>
		public fixed double lookat[3];
		/// <summary>
		/// distance to lookat point or tracked body
		/// </summary>
		public double distance;
		/// <summary>
		/// camera azimuth (deg)
		/// </summary>
		public double azimuth;
		/// <summary>
		/// camera elevation (deg)
		/// </summary>
		public double elevation;
		/// <summary>
		/// 0: perspective; 1: orthographic
		/// </summary>
		public int orthographic;
	}

	/// <summary>
	/// ---------------------------------- mjvGLCamera ---------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvGLCamera
	{
		/// <summary>
		/// position
		/// </summary>
		public fixed float pos[3];
		/// <summary>
		/// forward direction
		/// </summary>
		public fixed float forward[3];
		/// <summary>
		/// up direction
		/// </summary>
		public fixed float up[3];
		/// <summary>
		/// hor. center (left,right set to match aspect)
		/// </summary>
		public float frustum_center;
		/// <summary>
		/// width (not used for rendering)
		/// </summary>
		public float frustum_width;
		/// <summary>
		/// bottom
		/// </summary>
		public float frustum_bottom;
		/// <summary>
		/// top
		/// </summary>
		public float frustum_top;
		/// <summary>
		/// near
		/// </summary>
		public float frustum_near;
		/// <summary>
		/// far
		/// </summary>
		public float frustum_far;
		/// <summary>
		/// 0: perspective; 1: orthographic
		/// </summary>
		public int orthographic;
	}

	/// <summary>
	/// ---------------------------------- mjvGeom -------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvGeom
	{
		/// <summary>
		/// geom type (mjtGeom)
		/// </summary>
		public int type;
		/// <summary>
		/// mesh, hfield or plane id; -1: none; mesh: 2*id or 2*id+1 (hull)
		/// </summary>
		public int dataid;
		/// <summary>
		/// mujoco object type; mjOBJ_UNKNOWN for decor
		/// </summary>
		public int objtype;
		/// <summary>
		/// mujoco object id; -1 for decor
		/// </summary>
		public int objid;
		/// <summary>
		/// visual category
		/// </summary>
		public int category;
		/// <summary>
		/// material id; -1: no textured material
		/// </summary>
		public int matid;
		/// <summary>
		/// texture id; -1: none
		/// </summary>
		public int texid;
		/// <summary>
		/// uniform cube mapping
		/// </summary>
		public int texuniform;
		/// <summary>
		/// mesh or flex geom has texture coordinates
		/// </summary>
		public int texcoord;
		/// <summary>
		/// segmentation id; -1: not shown
		/// </summary>
		public int segid;
		/// <summary>
		/// size parameters
		/// </summary>
		public fixed float size[3];
		/// <summary>
		/// Cartesian position
		/// </summary>
		public fixed float pos[3];
		/// <summary>
		/// Cartesian orientation
		/// </summary>
		public fixed float mat[9];
		/// <summary>
		/// color and transparency
		/// </summary>
		public fixed float rgba[4];
		/// <summary>
		/// emission coef
		/// </summary>
		public float emission;
		/// <summary>
		/// specular coef
		/// </summary>
		public float specular;
		/// <summary>
		/// shininess coef
		/// </summary>
		public float shininess;
		/// <summary>
		/// reflectance coef
		/// </summary>
		public float reflectance;
		/// <summary>
		/// texture repetition for 2d mapping
		/// </summary>
		public fixed float texrepeat[2];
		/// <summary>
		/// text label
		/// </summary>
		public fixed byte label[100];
		/// <summary>
		/// distance to camera (used by sorter)
		/// </summary>
		public float camdist;
		/// <summary>
		/// geom rbound from model, 0 if not model geom
		/// </summary>
		public float modelrbound;
		/// <summary>
		/// treat geom as transparent
		/// </summary>
		public byte transparent;
	}

	/// <summary>
	/// ---------------------------------- mjvLight ------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvLight
	{
		/// <summary>
		/// light id, -1 for headlight
		/// </summary>
		public int id;
		/// <summary>
		/// position rel. to body frame
		/// </summary>
		public fixed float pos[3];
		/// <summary>
		/// direction rel. to body frame
		/// </summary>
		public fixed float dir[3];
		/// <summary>
		/// type (mjtLightType)
		/// </summary>
		public int type;
		/// <summary>
		/// texture id for image lights
		/// </summary>
		public int texid;
		/// <summary>
		/// OpenGL attenuation (quadratic model)
		/// </summary>
		public fixed float attenuation[3];
		/// <summary>
		/// OpenGL cutoff
		/// </summary>
		public float cutoff;
		/// <summary>
		/// OpenGL exponent
		/// </summary>
		public float exponent;
		/// <summary>
		/// ambient rgb (alpha=1)
		/// </summary>
		public fixed float ambient[3];
		/// <summary>
		/// diffuse rgb (alpha=1)
		/// </summary>
		public fixed float diffuse[3];
		/// <summary>
		/// specular rgb (alpha=1)
		/// </summary>
		public fixed float specular[3];
		/// <summary>
		/// headlight
		/// </summary>
		public byte headlight;
		/// <summary>
		/// does light cast shadows
		/// </summary>
		public byte castshadow;
		/// <summary>
		/// bulb radius for soft shadows
		/// </summary>
		public float bulbradius;
		/// <summary>
		/// intensity, in candelas
		/// </summary>
		public float intensity;
		/// <summary>
		/// range of effectiveness
		/// </summary>
		public float range;
	}

	/// <summary>
	/// ---------------------------------- mjvOption -----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvOption
	{
		/// <summary>
		/// what objects to label (mjtLabel)
		/// </summary>
		public int label;
		/// <summary>
		/// which frame to show (mjtFrame)
		/// </summary>
		public int frame;
		/// <summary>
		/// geom visualization by group
		/// </summary>
		public fixed byte geomgroup[6];
		/// <summary>
		/// site visualization by group
		/// </summary>
		public fixed byte sitegroup[6];
		/// <summary>
		/// joint visualization by group
		/// </summary>
		public fixed byte jointgroup[6];
		/// <summary>
		/// tendon visualization by group
		/// </summary>
		public fixed byte tendongroup[6];
		/// <summary>
		/// actuator visualization by group
		/// </summary>
		public fixed byte actuatorgroup[6];
		/// <summary>
		/// flex visualization by group
		/// </summary>
		public fixed byte flexgroup[6];
		/// <summary>
		/// skin visualization by group
		/// </summary>
		public fixed byte skingroup[6];
		/// <summary>
		/// visualization flags (indexed by mjtVisFlag)
		/// </summary>
		public fixed byte flags[31];
		/// <summary>
		/// depth of the bounding volume hierarchy to be visualized
		/// </summary>
		public int bvh_depth;
		/// <summary>
		/// element layer to be visualized for 3D flex
		/// </summary>
		public int flex_layer;
	}

	/// <summary>
	/// ---------------------------------- mjvScene ------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvScene
	{
		/// <summary>
		/// size of allocated geom buffer
		/// </summary>
		public int maxgeom;
		/// <summary>
		/// number of geoms currently in buffer
		/// </summary>
		public int ngeom;
		/// <summary>
		/// buffer for geoms (ngeom)
		/// </summary>
		public mjvGeom* geoms;
		/// <summary>
		/// buffer for ordering geoms by distance to camera (ngeom)
		/// </summary>
		public int* geomorder;
		/// <summary>
		/// number of flexes
		/// </summary>
		public int nflex;
		/// <summary>
		/// address of flex edges (nflex)
		/// </summary>
		public int* flexedgeadr;
		/// <summary>
		/// number of edges in flex (nflex)
		/// </summary>
		public int* flexedgenum;
		/// <summary>
		/// address of flex vertices (nflex)
		/// </summary>
		public int* flexvertadr;
		/// <summary>
		/// number of vertices in flex (nflex)
		/// </summary>
		public int* flexvertnum;
		/// <summary>
		/// address of flex faces (nflex)
		/// </summary>
		public int* flexfaceadr;
		/// <summary>
		/// number of flex faces allocated (nflex)
		/// </summary>
		public int* flexfacenum;
		/// <summary>
		/// number of flex faces currently in use (nflex)
		/// </summary>
		public int* flexfaceused;
		/// <summary>
		/// flex edge data (2*nflexedge)
		/// </summary>
		public int* flexedge;
		/// <summary>
		/// flex vertices (3*nflexvert)
		/// </summary>
		public float* flexvert;
		/// <summary>
		/// flex faces vertices (9*sum(flexfacenum))
		/// </summary>
		public float* flexface;
		/// <summary>
		/// flex face normals (9*sum(flexfacenum))
		/// </summary>
		public float* flexnormal;
		/// <summary>
		/// flex face texture coordinates (6*sum(flexfacenum))
		/// </summary>
		public float* flextexcoord;
		/// <summary>
		/// copy of mjVIS_FLEXVERT mjvOption flag
		/// </summary>
		public byte flexvertopt;
		/// <summary>
		/// copy of mjVIS_FLEXEDGE mjvOption flag
		/// </summary>
		public byte flexedgeopt;
		/// <summary>
		/// copy of mjVIS_FLEXFACE mjvOption flag
		/// </summary>
		public byte flexfaceopt;
		/// <summary>
		/// copy of mjVIS_FLEXSKIN mjvOption flag
		/// </summary>
		public byte flexskinopt;
		/// <summary>
		/// number of skins
		/// </summary>
		public int nskin;
		/// <summary>
		/// number of faces in skin (nskin)
		/// </summary>
		public int* skinfacenum;
		/// <summary>
		/// address of skin vertices (nskin)
		/// </summary>
		public int* skinvertadr;
		/// <summary>
		/// number of vertices in skin (nskin)
		/// </summary>
		public int* skinvertnum;
		/// <summary>
		/// skin vertex data (3*nskinvert)
		/// </summary>
		public float* skinvert;
		/// <summary>
		/// skin normal data (3*nskinvert)
		/// </summary>
		public float* skinnormal;
		/// <summary>
		/// number of lights currently in buffer
		/// </summary>
		public int nlight;
		/// <summary>
		/// buffer for lights (nlight)
		/// </summary>
		public InlineArray_mjvLight_100 lights;
		/// <summary>
		/// left and right camera
		/// </summary>
		public InlineArray_mjvGLCamera_2 camera;
		/// <summary>
		/// enable model transformation
		/// </summary>
		public byte enabletransform;
		/// <summary>
		/// model translation
		/// </summary>
		public fixed float translate[3];
		/// <summary>
		/// model quaternion rotation
		/// </summary>
		public fixed float rotate[4];
		/// <summary>
		/// model scaling
		/// </summary>
		public float scale;
		/// <summary>
		/// stereoscopic rendering (mjtStereo)
		/// </summary>
		public int stereo;
		/// <summary>
		/// rendering flags (indexed by mjtRndFlag)
		/// </summary>
		public fixed byte flags[11];
		/// <summary>
		/// frame pixel width; 0: disable framing
		/// </summary>
		public int framewidth;
		/// <summary>
		/// frame color
		/// </summary>
		public fixed float framergb[3];
		/// <summary>
		/// 0: ok, 1: geoms exhausted, warning issued
		/// </summary>
		public int status;
	}

	/// <summary>
	/// ---------------------------------- mjvFigure -----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjvFigure
	{
		/// <summary>
		/// show legend
		/// </summary>
		public int flg_legend;
		/// <summary>
		/// show grid tick labels (x,y)
		/// </summary>
		public fixed int flg_ticklabel[2];
		/// <summary>
		/// automatically extend axis ranges to fit data
		/// </summary>
		public int flg_extend;
		/// <summary>
		/// isolated line segments (i.e. GL_LINES)
		/// </summary>
		public int flg_barplot;
		/// <summary>
		/// vertical selection line
		/// </summary>
		public int flg_selection;
		/// <summary>
		/// symmetric y-axis
		/// </summary>
		public int flg_symmetric;
		/// <summary>
		/// line width
		/// </summary>
		public float linewidth;
		/// <summary>
		/// grid line width
		/// </summary>
		public float gridwidth;
		/// <summary>
		/// number of grid points in (x,y)
		/// </summary>
		public fixed int gridsize[2];
		/// <summary>
		/// grid line rgb
		/// </summary>
		public fixed float gridrgb[3];
		/// <summary>
		/// figure color and alpha
		/// </summary>
		public fixed float figurergba[4];
		/// <summary>
		/// pane color and alpha
		/// </summary>
		public fixed float panergba[4];
		/// <summary>
		/// legend color and alpha
		/// </summary>
		public fixed float legendrgba[4];
		/// <summary>
		/// text color
		/// </summary>
		public fixed float textrgb[3];
		/// <summary>
		/// line colors
		/// </summary>
		public fixed float linergb[300];
		/// <summary>
		/// axis ranges; (min&gt;=max) automatic
		/// </summary>
		public fixed float range[4];
		/// <summary>
		/// x-tick label format for sprintf
		/// </summary>
		public fixed byte xformat[20];
		/// <summary>
		/// y-tick label format for sprintf
		/// </summary>
		public fixed byte yformat[20];
		/// <summary>
		/// string used to determine min y-tick width
		/// </summary>
		public fixed byte minwidth[20];
		/// <summary>
		/// figure title; subplots separated with 2+ spaces
		/// </summary>
		public fixed byte title[1000];
		/// <summary>
		/// x-axis label
		/// </summary>
		public fixed byte xlabel[100];
		/// <summary>
		/// line names for legend
		/// </summary>
		public fixed byte linename[10000];
		/// <summary>
		/// number of lines to offset legend
		/// </summary>
		public int legendoffset;
		/// <summary>
		/// selected subplot (for title rendering)
		/// </summary>
		public int subplot;
		/// <summary>
		/// if point is in legend rect, highlight line
		/// </summary>
		public fixed int highlight[2];
		/// <summary>
		/// if id&gt;=0 and no point, highlight id
		/// </summary>
		public int highlightid;
		/// <summary>
		/// selection line x-value
		/// </summary>
		public float selection;
		/// <summary>
		/// number of points in line; (0) disable
		/// </summary>
		public fixed int linepnt[100];
		/// <summary>
		/// line data (x,y)
		/// </summary>
		public fixed float linedata[200200];
		/// <summary>
		/// range of x-axis in pixels
		/// </summary>
		public fixed int xaxispixel[2];
		/// <summary>
		/// range of y-axis in pixels
		/// </summary>
		public fixed int yaxispixel[2];
		/// <summary>
		/// range of x-axis in data units
		/// </summary>
		public fixed float xaxisdata[2];
		/// <summary>
		/// range of y-axis in data units
		/// </summary>
		public fixed float yaxisdata[2];
	}

	/// <summary>
	/// ---------------------------------- Resource Provider ---------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjResource
	{
		/// <summary>
		/// name of resource (filename, etc)
		/// </summary>
		public byte* name;
		/// <summary>
		/// opaque data pointer
		/// </summary>
		public void* data;
		/// <summary>
		/// pointer to the VFS
		/// </summary>
		public mjVFS* vfs;
		/// <summary>
		/// timestamp of the resource
		/// </summary>
		public fixed byte timestamp[512];
		/// <summary>
		/// pointer to the provider
		/// </summary>
		public mjpResourceProvider* provider;
	}

	/// <summary>
	/// struct describing a single resource provider
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjpResourceProvider
	{
		/// <summary>
		/// prefix for match against a resource name
		/// </summary>
		public byte* prefix;
		/// <summary>
		/// opening callback
		/// </summary>
		public delegate* unmanaged[Cdecl]<int> open;
		/// <summary>
		/// reading callback
		/// </summary>
		public delegate* unmanaged[Cdecl]<int> read;
		/// <summary>
		/// closing callback
		/// </summary>
		public delegate* unmanaged[Cdecl]<void> close;
		/// <summary>
		/// mounting callback (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<int> mount;
		/// <summary>
		/// unmounting callback (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<int> unmount;
		/// <summary>
		/// resource modified callback (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<int> modified;
		/// <summary>
		/// writing callback (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<long> write;
		/// <summary>
		/// opaque data pointer (resource invariant)
		/// </summary>
		public void* data;
	}

	/// <summary>
	/// the struct defining the decoder plugin's interface
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjpDecoder
	{
		public byte* content_type;
		public byte* extension;
		/// <summary>
		/// quickly check if this decoder can handle the resource
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjResource*, int> can_decode;
		/// <summary>
		/// main decoding function
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjResource*, mjVFS*, mjSpec*> decode;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjpEncoder
	{
		public byte* content_type;
		public byte* extension;
		/// <summary>
		/// Function to encode an mjSpec and mjModel to a mjResource.
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjSpec*, mjModel*, mjVFS*, mjResource*, long> encode;
		/// <summary>
		/// Function to close/free the resource.
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjResource*, void> close_resource;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjpPlugin
	{
		/// <summary>
		/// globally unique name identifying the plugin
		/// </summary>
		public byte* name;
		/// <summary>
		/// number of configuration attributes
		/// </summary>
		public int nattribute;
		/// <summary>
		/// name of configuration attributes
		/// </summary>
		public byte** attributes;
		/// <summary>
		/// plugin capabilities: bitfield of mjtPluginCapabilityBit
		/// </summary>
		public int capabilityflags;
		/// <summary>
		/// sensor computation stage (mjtStage)
		/// </summary>
		public int needstage;
		/// <summary>
		/// number of mjtNums needed to store the state of a plugin instance (required)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, int, int> nstate;
		/// <summary>
		/// dimension of the specified sensor's output (required only for sensor plugins)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, int, int, int> nsensordata;
		/// <summary>
		/// called when a new mjData is being created (required), returns 0 on success or -1 on failure
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, mjData*, int, int> init;
		/// <summary>
		/// called when an mjData is being freed (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjData*, int, void> destroy;
		/// <summary>
		/// called when an mjData is being copied (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjData*, mjModel*, mjData*, int, void> copy;
		/// <summary>
		/// called when an mjData is being reset (required)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, double*, void*, int, void> reset;
		/// <summary>
		/// called when the plugin needs to update its outputs (required)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, mjData*, int, int, void> compute;
		/// <summary>
		/// called when time integration occurs (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, mjData*, int, void> advance;
		/// <summary>
		/// called by mjv_updateScene (optional)
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, mjData*, mjvOption*, mjvScene*, int, void> visualize;
		/// <summary>
		/// updates the actuator plugin's entries in act_dot
		/// called after native act_dot is computed and before the compute callback
		/// </summary>
		public delegate* unmanaged[Cdecl]<mjModel*, mjData*, int, void> actuator_act_dot;
		/// <summary>
		/// signed distance from the surface
		/// </summary>
		public delegate* unmanaged[Cdecl]<double, mjData*, int, double> sdf_distance;
		/// <summary>
		/// gradient of distance with respect to local coordinates
		/// </summary>
		public delegate* unmanaged[Cdecl]<double, double, mjData*, int, void> sdf_gradient;
		/// <summary>
		/// called during compilation for marching cubes
		/// </summary>
		public delegate* unmanaged[Cdecl]<double, double*, double> sdf_staticdistance;
		/// <summary>
		/// convert attributes and provide defaults if not present
		/// </summary>
		public delegate* unmanaged[Cdecl]<double, byte*, byte*, void> sdf_attribute;
		/// <summary>
		/// bounding box of implicit surface
		/// </summary>
		public delegate* unmanaged[Cdecl]<double, double*, void> sdf_aabb;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjSDF
	{
		public mjpPlugin** plugin;
		public int* id;
		public mjtSDFType type;
		public double* relpos;
		public double* relmat;
		public mjtGeom* geomtype;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjrRect
	{
		/// <summary>
		/// left (usually 0)
		/// </summary>
		public int left;
		/// <summary>
		/// bottom (usually 0)
		/// </summary>
		public int bottom;
		/// <summary>
		/// width (usually buffer width)
		/// </summary>
		public int width;
		/// <summary>
		/// height (usually buffer height)
		/// </summary>
		public int height;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjrRendererInfo
	{
		/// <summary>
		/// renderer family: classic, filament, noop
		/// </summary>
		public byte* renderer;
		/// <summary>
		/// graphics backend: opengl, vulkan; empty if uninitialized
		/// </summary>
		public byte* backend;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjrVertexAttribute
	{
		/// <summary>
		/// position, normal, etc [mjrVertexAttributeUsage]
		/// </summary>
		public int usage;
		/// <summary>
		/// float3, ubyte4, etc. [mjrVertexAttributeType]
		/// </summary>
		public int type;
	}

	/// <summary>
	/// ---------------------------------- mjrContext ----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjrContext
	{
		/// <summary>
		/// line width for wireframe rendering
		/// </summary>
		public float lineWidth;
		/// <summary>
		/// clipping radius for directional lights
		/// </summary>
		public float shadowClip;
		/// <summary>
		/// fraction of light cutoff for spot lights
		/// </summary>
		public float shadowScale;
		/// <summary>
		/// fog start = stat.extent * vis.map.fogstart
		/// </summary>
		public float fogStart;
		/// <summary>
		/// fog end = stat.extent * vis.map.fogend
		/// </summary>
		public float fogEnd;
		/// <summary>
		/// fog rgba
		/// </summary>
		public fixed float fogRGBA[4];
		/// <summary>
		/// size of shadow map texture
		/// </summary>
		public int shadowSize;
		/// <summary>
		/// width of offscreen buffer
		/// </summary>
		public int offWidth;
		/// <summary>
		/// height of offscreen buffer
		/// </summary>
		public int offHeight;
		/// <summary>
		/// number of offscreen buffer multisamples
		/// </summary>
		public int offSamples;
		/// <summary>
		/// font scale
		/// </summary>
		public int fontScale;
		/// <summary>
		/// auxiliary buffer width
		/// </summary>
		public fixed int auxWidth[10];
		/// <summary>
		/// auxiliary buffer height
		/// </summary>
		public fixed int auxHeight[10];
		/// <summary>
		/// auxiliary buffer multisamples
		/// </summary>
		public fixed int auxSamples[10];
		/// <summary>
		/// offscreen framebuffer object
		/// </summary>
		public uint offFBO;
		/// <summary>
		/// offscreen framebuffer for resolving multisamples
		/// </summary>
		public uint offFBO_r;
		/// <summary>
		/// offscreen color buffer
		/// </summary>
		public uint offColor;
		/// <summary>
		/// offscreen color buffer for resolving multisamples
		/// </summary>
		public uint offColor_r;
		/// <summary>
		/// offscreen depth and stencil buffer
		/// </summary>
		public uint offDepthStencil;
		/// <summary>
		/// offscreen depth and stencil buffer for multisamples
		/// </summary>
		public uint offDepthStencil_r;
		/// <summary>
		/// shadow map framebuffer object
		/// </summary>
		public uint shadowFBO;
		/// <summary>
		/// shadow map texture
		/// </summary>
		public uint shadowTex;
		/// <summary>
		/// auxiliary framebuffer object
		/// </summary>
		public fixed uint auxFBO[10];
		/// <summary>
		/// auxiliary framebuffer object for resolving
		/// </summary>
		public fixed uint auxFBO_r[10];
		/// <summary>
		/// auxiliary color buffer
		/// </summary>
		public fixed uint auxColor[10];
		/// <summary>
		/// auxiliary color buffer for resolving
		/// </summary>
		public fixed uint auxColor_r[10];
		/// <summary>
		/// material texture ids (-1: no texture)
		/// </summary>
		public fixed int mat_texid[10000];
		/// <summary>
		/// uniform cube mapping
		/// </summary>
		public fixed int mat_texuniform[1000];
		/// <summary>
		/// texture repetition for 2d mapping
		/// </summary>
		public fixed float mat_texrepeat[2000];
		/// <summary>
		/// number of allocated textures
		/// </summary>
		public int ntexture;
		/// <summary>
		/// type of texture (mjtTexture) (ntexture)
		/// </summary>
		public fixed int textureType[1000];
		/// <summary>
		/// texture names
		/// </summary>
		public fixed uint texture[1000];
		/// <summary>
		/// all planes from model
		/// </summary>
		public uint basePlane;
		/// <summary>
		/// all meshes from model
		/// </summary>
		public uint baseMesh;
		/// <summary>
		/// all height fields from model
		/// </summary>
		public uint baseHField;
		/// <summary>
		/// all builtin geoms, with quality from model
		/// </summary>
		public uint baseBuiltin;
		/// <summary>
		/// normal font
		/// </summary>
		public uint baseFontNormal;
		/// <summary>
		/// shadow font
		/// </summary>
		public uint baseFontShadow;
		/// <summary>
		/// big font
		/// </summary>
		public uint baseFontBig;
		/// <summary>
		/// all planes from model
		/// </summary>
		public int rangePlane;
		/// <summary>
		/// all meshes from model
		/// </summary>
		public int rangeMesh;
		/// <summary>
		/// all hfields from model
		/// </summary>
		public int rangeHField;
		/// <summary>
		/// all builtin geoms, with quality from model
		/// </summary>
		public int rangeBuiltin;
		/// <summary>
		/// all characters in font
		/// </summary>
		public int rangeFont;
		/// <summary>
		/// number of skins
		/// </summary>
		public int nskin;
		/// <summary>
		/// skin vertex position VBOs (nskin)
		/// </summary>
		public uint* skinvertVBO;
		/// <summary>
		/// skin vertex normal VBOs (nskin)
		/// </summary>
		public uint* skinnormalVBO;
		/// <summary>
		/// skin vertex texture coordinate VBOs (nskin)
		/// </summary>
		public uint* skintexcoordVBO;
		/// <summary>
		/// skin face index VBOs (nskin)
		/// </summary>
		public uint* skinfaceVBO;
		/// <summary>
		/// character widths: normal and shadow
		/// </summary>
		public fixed int charWidth[127];
		/// <summary>
		/// character widths: big
		/// </summary>
		public fixed int charWidthBig[127];
		/// <summary>
		/// character heights: normal and shadow
		/// </summary>
		public int charHeight;
		/// <summary>
		/// character heights: big
		/// </summary>
		public int charHeightBig;
		/// <summary>
		/// is OpenGL initialized
		/// </summary>
		public int glInitialized;
		/// <summary>
		/// is default/window framebuffer available
		/// </summary>
		public int windowAvailable;
		/// <summary>
		/// number of samples for default/window framebuffer
		/// </summary>
		public int windowSamples;
		/// <summary>
		/// is stereo available for default/window framebuffer
		/// </summary>
		public int windowStereo;
		/// <summary>
		/// is default/window framebuffer double buffered
		/// </summary>
		public int windowDoublebuffer;
		/// <summary>
		/// currently active framebuffer: mjFB_WINDOW or mjFB_OFFSCREEN
		/// </summary>
		public int currentBuffer;
		/// <summary>
		/// default color pixel format for mjr_readPixels
		/// </summary>
		public int readPixelFormat;
		/// <summary>
		/// depth mapping: mjDEPTH_ZERONEAR or mjDEPTH_ZEROFAR
		/// </summary>
		public int readDepthMap;
	}

	/// <summary>
	/// ---------------------------------- mjuiState -----------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiState
	{
		/// <summary>
		/// number of rectangles used
		/// </summary>
		public int nrect;
		/// <summary>
		/// rectangles (index 0: entire window)
		/// </summary>
		public InlineArray_mjrRect_25 rect;
		/// <summary>
		/// pointer to user data (for callbacks)
		/// </summary>
		public void* userdata;
		/// <summary>
		/// (type mjtEvent)
		/// </summary>
		public int type;
		/// <summary>
		/// is left button down
		/// </summary>
		public int left;
		/// <summary>
		/// is right button down
		/// </summary>
		public int right;
		/// <summary>
		/// is middle button down
		/// </summary>
		public int middle;
		/// <summary>
		/// is last press a double click
		/// </summary>
		public int doubleclick;
		/// <summary>
		/// which button was pressed (mjtButton)
		/// </summary>
		public int button;
		/// <summary>
		/// time of last button press
		/// </summary>
		public double buttontime;
		/// <summary>
		/// x position
		/// </summary>
		public double x;
		/// <summary>
		/// y position
		/// </summary>
		public double y;
		/// <summary>
		/// x displacement
		/// </summary>
		public double dx;
		/// <summary>
		/// y displacement
		/// </summary>
		public double dy;
		/// <summary>
		/// x scroll
		/// </summary>
		public double sx;
		/// <summary>
		/// y scroll
		/// </summary>
		public double sy;
		/// <summary>
		/// is control down
		/// </summary>
		public int control;
		/// <summary>
		/// is shift down
		/// </summary>
		public int shift;
		/// <summary>
		/// is alt down
		/// </summary>
		public int alt;
		/// <summary>
		/// which key was pressed
		/// </summary>
		public int key;
		/// <summary>
		/// time of last key press
		/// </summary>
		public double keytime;
		/// <summary>
		/// which rectangle contains mouse
		/// </summary>
		public int mouserect;
		/// <summary>
		/// which rectangle is dragged with mouse
		/// </summary>
		public int dragrect;
		/// <summary>
		/// which button started drag (mjtButton)
		/// </summary>
		public int dragbutton;
		/// <summary>
		/// number of files dropped
		/// </summary>
		public int dropcount;
		/// <summary>
		/// paths to files dropped
		/// </summary>
		public byte** droppaths;
	}

	/// <summary>
	/// ---------------------------------- mjuiThemeSpacing ----------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiThemeSpacing
	{
		/// <summary>
		/// total width
		/// </summary>
		public int total;
		/// <summary>
		/// scrollbar width
		/// </summary>
		public int scroll;
		/// <summary>
		/// label width
		/// </summary>
		public int label;
		/// <summary>
		/// section gap
		/// </summary>
		public int section;
		/// <summary>
		/// corner radius for section
		/// </summary>
		public int cornersect;
		/// <summary>
		/// corner radius for separator
		/// </summary>
		public int cornersep;
		/// <summary>
		/// item side gap
		/// </summary>
		public int itemside;
		/// <summary>
		/// item middle gap
		/// </summary>
		public int itemmid;
		/// <summary>
		/// item vertical gap
		/// </summary>
		public int itemver;
		/// <summary>
		/// text horizontal gap
		/// </summary>
		public int texthor;
		/// <summary>
		/// text vertical gap
		/// </summary>
		public int textver;
		/// <summary>
		/// number of pixels to scroll
		/// </summary>
		public int linescroll;
		/// <summary>
		/// number of multisamples
		/// </summary>
		public int samples;
	}

	/// <summary>
	/// ---------------------------------- mjuiThemeColor ------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiThemeColor
	{
		/// <summary>
		/// master background
		/// </summary>
		public fixed float master[3];
		/// <summary>
		/// scrollbar thumb
		/// </summary>
		public fixed float thumb[3];
		/// <summary>
		/// section title
		/// </summary>
		public fixed float secttitle[3];
		/// <summary>
		/// section title: bottom color
		/// </summary>
		public fixed float secttitle2[3];
		/// <summary>
		/// section title with unchecked box
		/// </summary>
		public fixed float secttitleuncheck[3];
		/// <summary>
		/// section title with unchecked box: bottom color
		/// </summary>
		public fixed float secttitleuncheck2[3];
		/// <summary>
		/// section title with checked box
		/// </summary>
		public fixed float secttitlecheck[3];
		/// <summary>
		/// section title with checked box: bottom color
		/// </summary>
		public fixed float secttitlecheck2[3];
		/// <summary>
		/// section font
		/// </summary>
		public fixed float sectfont[3];
		/// <summary>
		/// section symbol
		/// </summary>
		public fixed float sectsymbol[3];
		/// <summary>
		/// section pane
		/// </summary>
		public fixed float sectpane[3];
		/// <summary>
		/// separator title
		/// </summary>
		public fixed float separator[3];
		/// <summary>
		/// separator title: bottom color
		/// </summary>
		public fixed float separator2[3];
		/// <summary>
		/// shortcut background
		/// </summary>
		public fixed float shortcut[3];
		/// <summary>
		/// font active
		/// </summary>
		public fixed float fontactive[3];
		/// <summary>
		/// font inactive
		/// </summary>
		public fixed float fontinactive[3];
		/// <summary>
		/// decor inactive
		/// </summary>
		public fixed float decorinactive[3];
		/// <summary>
		/// inactive slider color 2
		/// </summary>
		public fixed float decorinactive2[3];
		/// <summary>
		/// button
		/// </summary>
		public fixed float button[3];
		/// <summary>
		/// check
		/// </summary>
		public fixed float check[3];
		/// <summary>
		/// radio
		/// </summary>
		public fixed float radio[3];
		/// <summary>
		/// select
		/// </summary>
		public fixed float select[3];
		/// <summary>
		/// select pane
		/// </summary>
		public fixed float select2[3];
		/// <summary>
		/// slider
		/// </summary>
		public fixed float slider[3];
		/// <summary>
		/// slider color 2
		/// </summary>
		public fixed float slider2[3];
		/// <summary>
		/// edit
		/// </summary>
		public fixed float edit[3];
		/// <summary>
		/// edit invalid
		/// </summary>
		public fixed float edit2[3];
		/// <summary>
		/// edit cursor
		/// </summary>
		public fixed float cursor[3];
	}

	/// <summary>
	/// ---------------------------------- mjuiItem ------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiItemSingle
	{
		/// <summary>
		/// 0: none, 1: control, 2: shift; 4: alt
		/// </summary>
		public int modifier;
		/// <summary>
		/// shortcut key; 0: undefined
		/// </summary>
		public int shortcut;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiItemMulti
	{
		/// <summary>
		/// number of elements in group
		/// </summary>
		public int nelem;
		/// <summary>
		/// element names
		/// </summary>
		public fixed byte name[1400];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiItemSlider
	{
		/// <summary>
		/// slider range
		/// </summary>
		public fixed double range[2];
		/// <summary>
		/// number of range divisions
		/// </summary>
		public double divisions;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiItemEdit
	{
		/// <summary>
		/// number of elements in list
		/// </summary>
		public int nelem;
		/// <summary>
		/// element range (min&gt;=max: ignore)
		/// </summary>
		public fixed double range[14];
	}

	[StructLayout(LayoutKind.Explicit)]
	public unsafe struct mjuiItem_anonymous0
	{
		/// <summary>
		/// check and button
		/// </summary>
		[FieldOffset(0)]
		public mjuiItemSingle single;
		/// <summary>
		/// static, radio and select
		/// </summary>
		[FieldOffset(0)]
		public mjuiItemMulti multi;
		/// <summary>
		/// slider
		/// </summary>
		[FieldOffset(0)]
		public mjuiItemSlider slider;
		/// <summary>
		/// edit
		/// </summary>
		[FieldOffset(0)]
		public mjuiItemEdit edit;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiItem
	{
		/// <summary>
		/// type (mjtItem)
		/// </summary>
		public int type;
		/// <summary>
		/// name
		/// </summary>
		public fixed byte name[40];
		/// <summary>
		/// 0: disable, 1: enable, 2+: use predicate
		/// </summary>
		public int state;
		/// <summary>
		/// data pointer (type-specific)
		/// </summary>
		public void* pdata;
		/// <summary>
		/// id of section containing item
		/// </summary>
		public int sectionid;
		/// <summary>
		/// id of item within section
		/// </summary>
		public int itemid;
		/// <summary>
		/// user-supplied id (for event handling)
		/// </summary>
		public int userid;
		/// <summary>
		/// type-specific properties
		/// </summary>
		public mjuiItem_anonymous0 anonymous0;
		/// <summary>
		/// rectangle occupied by item
		/// </summary>
		public mjrRect rect;
		/// <summary>
		/// item skipped due to closed separator
		/// </summary>
		public int skip;
	}

	/// <summary>
	/// ---------------------------------- mjuiSection ---------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiSection
	{
		/// <summary>
		/// name
		/// </summary>
		public fixed byte name[40];
		/// <summary>
		/// section state (mjtSection)
		/// </summary>
		public int state;
		/// <summary>
		/// 0: none, 1: control, 2: shift; 4: alt
		/// </summary>
		public int modifier;
		/// <summary>
		/// shortcut key; 0: undefined
		/// </summary>
		public int shortcut;
		/// <summary>
		/// 0: none, 1: unchecked, 2: checked
		/// </summary>
		public int checkbox;
		/// <summary>
		/// number of items in use
		/// </summary>
		public int nitem;
		/// <summary>
		/// preallocated array of items
		/// </summary>
		public InlineArray_mjuiItem_200 item;
		/// <summary>
		/// rectangle occupied by title
		/// </summary>
		public mjrRect rtitle;
		/// <summary>
		/// rectangle occupied by content
		/// </summary>
		public mjrRect rcontent;
		/// <summary>
		/// last mouse click over this section
		/// </summary>
		public int lastclick;
	}

	/// <summary>
	/// ---------------------------------- mjUI ----------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjUI
	{
		/// <summary>
		/// UI theme spacing
		/// </summary>
		public mjuiThemeSpacing spacing;
		/// <summary>
		/// UI theme color
		/// </summary>
		public mjuiThemeColor color;
		/// <summary>
		/// callback to set item state programmatically
		/// </summary>
		public delegate* unmanaged[Cdecl]<int, void*, int> predicate;
		/// <summary>
		/// pointer to user data (passed to predicate)
		/// </summary>
		public void* userdata;
		/// <summary>
		/// index of this ui rectangle in mjuiState
		/// </summary>
		public int rectid;
		/// <summary>
		/// aux buffer index of this ui
		/// </summary>
		public int auxid;
		/// <summary>
		/// number of radio columns (0 defaults to 2)
		/// </summary>
		public int radiocol;
		/// <summary>
		/// width
		/// </summary>
		public int width;
		/// <summary>
		/// current height
		/// </summary>
		public int height;
		/// <summary>
		/// height when all sections open
		/// </summary>
		public int maxheight;
		/// <summary>
		/// scroll from top of UI
		/// </summary>
		public int scroll;
		/// <summary>
		/// 0: none, -1: scroll, otherwise 1+section
		/// </summary>
		public int mousesect;
		/// <summary>
		/// item within section
		/// </summary>
		public int mouseitem;
		/// <summary>
		/// help button down: print shortcuts
		/// </summary>
		public int mousehelp;
		/// <summary>
		/// number of mouse clicks over UI
		/// </summary>
		public int mouseclicks;
		/// <summary>
		/// 0: none, otherwise 1+section
		/// </summary>
		public int mousesectcheck;
		/// <summary>
		/// 0: none, otherwise 1+section
		/// </summary>
		public int editsect;
		/// <summary>
		/// item within section
		/// </summary>
		public int edititem;
		/// <summary>
		/// cursor position
		/// </summary>
		public int editcursor;
		/// <summary>
		/// horizontal scroll
		/// </summary>
		public int editscroll;
		/// <summary>
		/// current text
		/// </summary>
		public fixed byte edittext[300];
		/// <summary>
		/// pointer to changed edit in last mjui_event
		/// </summary>
		public mjuiItem* editchanged;
		/// <summary>
		/// number of sections in use
		/// </summary>
		public int nsect;
		/// <summary>
		/// preallocated array of sections
		/// </summary>
		public InlineArray_mjuiSection_10 sect;
	}

	/// <summary>
	/// ---------------------------------- mjuiDef -------------------------------------------------------
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mjuiDef
	{
		/// <summary>
		/// type (mjtItem); -1: section
		/// </summary>
		public int type;
		/// <summary>
		/// name
		/// </summary>
		public fixed byte name[40];
		/// <summary>
		/// state
		/// </summary>
		public int state;
		/// <summary>
		/// pointer to data
		/// </summary>
		public void* pdata;
		/// <summary>
		/// string with type-specific properties
		/// </summary>
		public fixed byte other[300];
		/// <summary>
		/// int with type-specific properties
		/// </summary>
		public int otherint;
	}
}
