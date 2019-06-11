### GameObjectPool

The GameObjectPool ScriptableObject is used to quickly Instantiate and Destroy hundreds of GameObjects without running into performance issues due to garbage collection.

Start by creating a new GameObjectPoolReference ScriptableObject from **Assets** > **Create** > **CandyCoded** > **GameObjectPoolReference**.

Drag the prefab you are going to Instantiate into the newly created GameObjectPoolReference and specify the number of GameObjects to Instantiate on populate. You can also specify a parent transform here.

![](https://i.imgur.com/yDf5zHK.png)

In a script, create a private, serialized field for the GameObjectPoolReference.

```csharp
public CandyCoded.GameObjectPoolReference gameObjectPoolRef;
```

Then populate the GameObject pool on either Awake or Start.

```csharp
private void Awake()
{

    gameObjectPoolRef.PopulatePool();

}
```

Then create an action that retrieves and shows prefabs. In this case, a prefab will be shown every frame a key is down.

```csharp
private void Update()
{

    if (Input.anyKey)
    {

        gameObjectPoolRef.Spawn(Vector3.zero, Quaternion.identity);

    }

}
```
