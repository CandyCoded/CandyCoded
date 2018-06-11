### Float

Each ScriptableObject has a `value` and a `defaultValue`. The `value` can be modified via script, the `defaultValue` can not.

A `Reset` method is publicly available to reset the `value` to equal the `defaultValue`. This method is also accessible via the inspector.

![](https://i.imgur.com/xMX202E.png)

Event handlers for update and reset events are available to each ScriptableObject with `value` and `defaultValue` properties.

```csharp
private void OnEnable()
{

    floatReference.UpdateEvent += OnScriptableObjectUpdate;
    floatReference.ResetEvent += OnScriptableObjectReset;

}
```

Make sure that when adding a handler to either event to make sure and remove it when the script it is associated with is disabled.

```csharp
private void OnDisable()
{

    floatReference.UpdateEvent -= OnScriptableObjectUpdate;
    floatReference.ResetEvent -= OnScriptableObjectReset;

}
```
