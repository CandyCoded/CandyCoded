### ObjectPool

The ObjectPool ScriptableObject is used to quickly Instantiate and Destroy hundreds of GameObjects without running into performance issues due to garbage collection.

Start by creating a new ObjectPoolReference ScriptableObject from Assets > Create > CandyCoded > ObjectPoolReference.

Drag the prefab you are going to Instantiate into the newly created ObjectPoolReference and specify the number of GameObjects to Instantiate on start.

![](https://i.imgur.com/2cUdZZ0.png)

In a script create a public or private, serialized field for the ObjectPoolReference.

```csharp
public CandyCoded.ObjectPoolReference objectPoolRef;
```

Then populate the object pool on either Awake or Start.

```csharp
private void Awake()
{

    objectPoolRef.PopulatePool();

}
```

Then create an action that spawns your prefabs. In this case, a prefab gets spawned every frame a key is down.

```csharp
private void Update()
{

    if (Input.anyKey)
    {

        objectPoolRef.Spawn(Vector3.zero, Quaternion.identity);

    }

}
```
