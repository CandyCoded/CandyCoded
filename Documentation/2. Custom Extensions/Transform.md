### Transform

#### GetChildrenByName

Get children transforms of parent transform by GameObject name.

```csharp
Transform[] children = gameObject.transform.GetChildrenByName("Item");
```

#### LookAt2D

Rotates transform so the forward vector (or supplied Vector3) points at target's position.

```csharp
gameObject.transform.rotation = gameObject.transform.LookAt2D(currentMousePosition);
```

```csharp
gameObject.transform.rotation = gameObject.transform.LookAt2D(currentMousePosition, Vector3.right);
```

#### RotateWithDelta

Rotate transform with delta input position.

```csharp
gameObject.transform.RotateWithDelta(delta, rotateSpeed, mainCameraTransform);
```

Rotate transform along a custom axis with delta input position.

```csharp
gameObject.transform.RotateWithDelta(delta, rotateSpeed, mainCameraTransform, RotationAxis.Horizontal);
```
