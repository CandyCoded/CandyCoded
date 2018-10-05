### LayerMask

#### Contains

Tests LayerMask for the supplied Layer name or int.

```csharp
LayerMask layerMask = ~0;
Debug.Log(layerMask.Contains("Water")); // true
```

```csharp
LayerMask layerMask = ~0;
Debug.Log(layerMask.Contains(4)); // true
```
