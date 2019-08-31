### Camera

#### ScreenToHighPrecisionViewportPoint

Return a high precision viewport point. `(0, 0)` to `(100, 100)`

```csharp
Debug.Log(mainCamera.ScreenToHighPrecisionViewportPoint(Input.mousePosition));
```

Return a custom high precision viewport point. `(0, 0)` to `(n, n)`

```csharp
Debug.Log(mainCamera.ScreenToHighPrecisionViewportPoint(Input.mousePosition, 100));
```
