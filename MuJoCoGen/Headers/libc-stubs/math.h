// Minimal stand-in for the C library's <math.h>. See stdlib.h in this folder for why these exist.
//
// MuJoCo includes <math.h> so that mjmacro.h can alias mju_sqrt/mju_exp/... to the libc functions.
// Those aliases are preprocessor macros that the generator discards, and no MuJoCo declaration
// names a math.h type, so an empty header is enough to parse the public API.

#pragma once
