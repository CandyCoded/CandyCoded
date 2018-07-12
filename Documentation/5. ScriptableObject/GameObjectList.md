### GameObjectList

This ScriptableObject is extended from [List](List.md).

A `Reset` method is publicly available to clear the `Items` list. This method is also accessible via the inspector.

![](https://i.imgur.com/x60IcUO.png)

Event handlers for add, remove and clear events are available on GameObjectList objects.

```csharp
private void OnEnable()
{

    list.AddEvent += OnAddEvent;
    list.ClearEvent += OnClearEvent;
    list.RemoveEvent += OnRemoveEvent;

}
```

Make sure that when adding a handler to any event to make sure and remove it when the script it is associated with is disabled.

```csharp
private void OnDisable()
{

    list.AddEvent -= OnAddEvent;
    list.ClearEvent -= OnClearEvent;
    list.RemoveEvent -= OnRemoveEvent;

}
```
