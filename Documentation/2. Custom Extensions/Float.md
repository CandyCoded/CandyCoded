### Float

#### NearlyEqual

Returns true if the difference between num1 and num2 is less than the default epsilon.

```csharp
float positionX = 0.1001f;
Debug.Log(positionX.NearlyEqual(0.1f)); // true
```

Returns true if the difference between num1 and num2 is less than the supplied epsilon.

```csharp
float positionX = 0.1001f;
float customEpsilon = 0.01f;
Debug.Log(positionX.NearlyEqual(0.1f, customEpsilon)); // true
```
