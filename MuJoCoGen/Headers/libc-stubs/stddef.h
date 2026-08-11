// Minimal stand-in for <stddef.h>. See stdlib.h in this folder for why these stubs exist.
//
// The types come from clang's own predefined macros rather than fixed spellings, so they always
// match the target the parser is configured for.

#pragma once

typedef __SIZE_TYPE__ size_t;
typedef __PTRDIFF_TYPE__ ptrdiff_t;

#define NULL ((void*)0)
