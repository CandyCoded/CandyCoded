### Transform

#### GetChildrenByName

Get children transforms of parent transform by GameObject name.

```csharp
Transform[] children = gameObject.transform.GetChildrenByName("Item");
```

#### LookAt2D

Rotates transform so the forward vector (or supplied Vector3) points at target's position.

```csharp
gameObject.transform.LookAt2D(currentMousePosition);
```

```csharp
gameObject.transform.LookAt2D(currentMousePosition, Vector3.right);
```
