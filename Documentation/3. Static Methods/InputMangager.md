### InputManager

#### GetInputDown

Returns true if the user has either pressed the primary mouse button or touched the screen over a specific GameObject.

```csharp
if (InputManager.GetInputDown(gameObject, mainCamera, out currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### GetInputPosition

Returns the position of either the mouse or a specific touch.

```csharp
Debug.Log(InputManager.GetInputPosition(fingerId));
```

#### GetInputUp

Returns true if the user has either released the primary mouse button or ended a touch on the screen over a specific GameObject.

```csharp
if (InputManager.GetInputUp(gameObject, mainCamera, currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### GetMouseButtonDown

Returns true if the user has pressed the primary mouse button over a specific GameObject.

```csharp
if (InputManager.GetMouseButtonDown(gameObject, mainCamera, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### GetMouseButtonUp

Returns true if the user has released the primary mouse button over a specific GameObject.

```csharp
if (InputManager.GetMouseButtonUp(gameObject, mainCamera, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### GetMousePosition

Returns the position of the mouse.

```csharp
Debug.Log(InputManager.GetMousePosition());
```

#### GetActiveTouch

Returns the active touch based on a unique finger ID and a TouchPhase enum filter.

```csharp
var touch = InputManager.GetActiveTouch(TouchPhase.Began);

if (touch.HasValue)
{

    Debug.Log(touch.Value.fingerId);

}
```

```csharp
var touch = InputManager.GetActiveTouch(fingerId);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

```csharp
var touch = InputManager.GetActiveTouch(fingerId, TouchPhase.Ended);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

#### GetTouchDown

Returns true if the user has touched the screen over a specific GameObject.

```csharp
if (InputManager.GetTouchDown(gameObject, mainCamera, out currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### GetTouchPosition

Returns the position of a specific touch.

```csharp
Debug.Log(InputManager.GetTouchPosition(fingerId));
```

#### GetTouchUp

Returns true if the user has ended a touch on the screen over a specific GameObject.

```csharp
if (InputManager.GetTouchUp(gameObject, mainCamera, currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

#### RaycastToGameObject

Returns true if a position collides with a GameObject.

```csharp
if (InputManager.RaycastToGameObject(gameObject, mainCamera, Vector3.zero, out hit))
{

    Debug.Log(gameObject.name);

}
```
