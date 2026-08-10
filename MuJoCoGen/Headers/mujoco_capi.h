// Translation unit used by MuJoCoGen instead of including <mujoco/mujoco.h> directly.
//
// CppAst always drives libclang in C++ mode (CppParserOptions.ParseAsCpp = false yields an empty
// AST in 0.21.1), but MuJoCo's headers expose a different API surface to C++ than to C:
//
//   * mjspec.h aliases mjString/mjIntVec/mjByteVec to std::string/std::vector<...> under
//     __cplusplus, which are not blittable and cannot be marshalled; the C branch declares them as
//     opaque `void`, which is exactly what a P/Invoke binding needs.
//   * mujoco.h wraps its declarations in `extern "C"` under __cplusplus.
//
// Undefining __cplusplus selects the C branch of every one of those guards. _Bool is then required
// by mjtype.h's C branch and does not exist in C++, so it is mapped to its ABI equivalent.

#undef __cplusplus
#define _Bool unsigned char

#include <mujoco/mujoco.h>
