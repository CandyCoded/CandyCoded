### PoolReference

The PoolReference ScriptableObject is used to create ScriptableObjects that can pool generic objects for performant reuse.

#### Basic Setup

Create a new class, extend `PoolReference<T>` with a type (in this case `GameObject`) and setup the override method `Create`. The `Create` method must return a new object with the same time as was specified in the class signature.

```csharp
using UnityEngine;
using CandyCoded;

public class GameObjectPool : PoolReference<GameObject>
{

    protected override GameObject Create()
    {

        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        gameObject.SetActive(false);

        return gameObject;

    }

}
```

#### Populate

Populates pool with objects generated via the Create method.

```csharp
poolReference.Populate();
```

#### Retrieve

Retrieves an object from the pool if available. If no objects are available, a new one is created and returned.

```csharp
Debug.Log(poolReference.Retrieve());
```

#### Release

Releases an object back into the object pool.

```csharp
poolReference.Release(item);
```

#### ReleaseAllObjects

Releases all objects back into the object pool.

```csharp
poolReference.ReleaseAllObjects();
```
