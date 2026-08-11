// Minimal stand-in for <stdint.h>. See stdlib.h in this folder for why these stubs exist.
//
// MuJoCo's headers currently use only int64_t, uint64_t and uintptr_t, but the whole fixed-width
// family is declared so that a future upstream header does not fail to parse over a missing
// typedef. The types come from clang's own predefined macros, so they always match the target.

#pragma once

typedef __INT8_TYPE__ int8_t;
typedef __INT16_TYPE__ int16_t;
typedef __INT32_TYPE__ int32_t;
typedef __INT64_TYPE__ int64_t;

typedef __UINT8_TYPE__ uint8_t;
typedef __UINT16_TYPE__ uint16_t;
typedef __UINT32_TYPE__ uint32_t;
typedef __UINT64_TYPE__ uint64_t;

typedef __INTPTR_TYPE__ intptr_t;
typedef __UINTPTR_TYPE__ uintptr_t;
