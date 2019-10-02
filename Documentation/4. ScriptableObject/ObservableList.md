# ObservableList

The ObservableListReference ScriptableObject class is an abstract class used to create ScriptableObjects with lists of items of a specific type. The [GameObjectList](GameObjectList.md) is an example of this. This list is an [ObservableList](../1.%20Objects/ObservableList.md).

#### Events

Event handlers for add, remove and clear events are available on ObservableList objects.

```csharp
private void OnEnable()
{

    list.AddEvent += OnAddEvent;
    list.ClearEvent += OnClearEvent;
    list.RemoveEvent += OnRemoveEvent;

}
```

When adding a handler to any event, make sure and remove it when the script it is associated with is disabled.

```csharp
private void OnDisable()
{

    list.AddEvent -= OnAddEvent;
    list.ClearEvent -= OnClearEvent;
    list.RemoveEvent -= OnRemoveEvent;

}
```

A `Reset` method is publicly available to clear the `Items` list. This method is also accessible via the inspector.

The following example creates a ScriptableObject with a list of Strings.

```csharp
public class StringListReference : CandyCoded.ListReference<String>
{

}
```
