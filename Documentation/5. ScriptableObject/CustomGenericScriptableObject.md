### CustomGenericScriptableObject

Each ScriptableObject has a `value` and a `defaultValue`. The `value` can be modified via script, the `defaultValue` can not.

A `Reset` method is publicly available to reset the `value` to equal the `defaultValue`. This method is also accessible via the inspector.

```csharp
[CreateAssetMenu]
public class Vector3Reference : CandyCoded.CustomGenericScriptableObject<Vector3>
{

}
```

![](https://i.imgur.com/9opk8j8.png)

Event handlers for update and reset events are available to each ScriptableObject with `value` and `defaultValue` properties.

```csharp
private void OnEnable()
{

    scriptableObjectReference.UpdateEvent += OnScriptableObjectUpdate;
    scriptableObjectReference.ResetEvent += OnScriptableObjectReset;

}
```

Make sure that when adding a handler to either event to make sure and remove it when the script it is associated with is disabled.

```csharp
private void OnDisable()
{

    scriptableObjectReference.UpdateEvent -= OnScriptableObjectUpdate;
    scriptableObjectReference.ResetEvent -= OnScriptableObjectReset;

}
```
