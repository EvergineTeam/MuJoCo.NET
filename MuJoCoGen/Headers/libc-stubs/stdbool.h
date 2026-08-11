// Minimal stand-in for <stdbool.h>. See stdlib.h in this folder for why these stubs exist.
//
// mjtype.h includes this header, but no MuJoCo declaration uses bare `bool`: booleans are always
// mjtBool, which resolves to _Bool on the C path that mujoco_capi.h selects.

#pragma once

#define bool _Bool
#define true 1
#define false 0
