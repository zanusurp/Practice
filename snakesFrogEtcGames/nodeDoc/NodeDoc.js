//The assert module provides a set of assertion functions for verifying invariants.
//https://nodejs.org/dist/latest-v14.x/docs/api/assert.html#assert_strict_assertion_mode
//https://v8.dev/docs/embed
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
const assert = require('assert').strict;

assert.deepEqual([[[1, 2, 3]], 4, 5], [[[1, 2, '3']], 4, 5]);

