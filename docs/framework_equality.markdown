#How the framework checks for equality


1. Is it a reference type (class)

  * Does it implement IEquatable<T> use it
  * Does it override Equals - use it
  * Are the references the same (space in memory)

2. Is it a value type (struct)

  * Does it override Equals - use it
  * Reflective field by field equality check
