### GameObject

#### AddOrGetComponent

Returns a reference to an existing component or a new component if it didn't already exist.

```csharp
private Rigidbody rb;

private void Awake() {

    rb = gameObject.AddOrGetComponent<Rigidbody>();

}
```


#### GetLayerMask

Creates a LayerMask from a GameObject's layer property.

```csharp
private void Start() {

    Debug.Log(gameObject.GetLayerMask())

}
```
