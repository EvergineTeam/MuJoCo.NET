// Minimal stand-in for the C library's <stdlib.h>, used only while parsing MuJoCo's headers.
//
// mujoco.h includes <stdlib.h> and <math.h>. libclang ships its own freestanding headers
// (stddef.h, stdint.h, stdbool.h) but no libc, so on a bare Linux CI runner the include fails and
// the parse dies with "'stdlib.h' file not found" while it succeeds on Windows, where the Windows
// SDK happens to be on the search path.
//
// Rather than teach the generator where each platform keeps its libc, these stubs make parsing
// hermetic: the generated bindings no longer depend on the host's libc version, and Windows and
// Linux produce byte-identical output. Nothing from these headers ever reaches the bindings —
// CsCodeGenerator only emits declarations whose source file lives under Headers/mujoco/.
//
// All MuJoCo needs from <stdlib.h> is size_t.

#pragma once

#include <stddef.h>
