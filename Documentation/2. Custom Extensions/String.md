### String

#### Nicify

Returns displayable string for given value. Adds spaces between uppercase letters and removes `m_`, `_` or `k` from beginning of value.

```csharp
Debug.Log("MyVariable".Nicify()); // My Variable
Debug.Log("m_TheOtherVariable".Nicify()); // The Other Variable
Debug.Log("kSomeConstant".Nicify()); // Some Constant
```
