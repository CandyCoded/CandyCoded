### List

The ListReference ScriptableObject class is an abstract class used to create ScriptableObjects with lists of items of a specific type. The [GameObjectList](GameObjectList.md) is an example of this.

A `Reset` method is publicly available to clear the `Items` list. This method is also accessible via the inspector.

<img src="https://i.imgur.com/x60IcUO.png" width="400">

The following example creates a ScriptableObject with a list of Strings.

```csharp
public class StringListReference : CandyCoded.ListReference<String>
{

}
```
