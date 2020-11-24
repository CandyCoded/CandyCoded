### Vector3

#### NearlyEqual

Returns true if the difference between vectors is less than the default epsilon.

```csharp
Vector3 position = new Vector3(0.1001f, 0, 0);
Debug.Log(position.NearlyEqual(new Vector3(0.1f, 0, 0))); // true
```

Returns true if the difference between vectors is less than the supplied epsilon.

```csharp
Vector3 position = new Vector3(0.1001f, 0, 0);
float customEpsilon = 0.01f;
Debug.Log(position.NearlyEqual(new Vector3(0.1f, 0, 0), customEpsilon)); // true
```
