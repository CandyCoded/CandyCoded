### InputManager

> **Note:** `ref currentFingetId` is now a null reference type and should be setup as `int? currentFingerId;`. This change was made to fix an issue in a previous release (3.x) that would cause multiple touch inputs to act as one.

#### GetInputDown

Returns true if the user has either pressed the primary mouse button or touched the screen over a specific GameObject.

```csharp
if (InputManager.GetInputDown(gameObject, mainCamera, ref currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has either pressed the primary mouse button or touched the screen.

```csharp
if (InputManager.GetInputDown(ref currentFingerId))
{

    Debug.Log("Input down");

}
```

```csharp
if (InputManager.GetInputDown())
{

    Debug.Log("Input down");

}
```

#### GetInputPosition

Returns the position of either the mouse or a specific touch.

> **Note:** This method will not return a vector if `currentFingerId` has not been populated by a previous call to `Input.GetInputDown`.

```csharp
Debug.Log(InputManager.GetInputPosition(currentFingerId));
```

#### GetInputUp

Returns true if the user has either released the primary mouse button or ended a touch on the screen over a specific GameObject.

> **Note:** This method will not return true if `currentFingerId` has not been populated by a previous call to `Input.GetInputDown`.

```csharp
if (InputManager.GetInputUp(gameObject, mainCamera, ref currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has either released the primary mouse button or ended a touch on the screen.

```csharp
if (InputManager.GetInputUp(ref currentFingerId))
{

    Debug.Log("Input up");

}
```

```csharp
if (InputManager.GetInputUp())
{

    Debug.Log("Input up");

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

Returns true if the user has pressed the primary mouse button.

```csharp
if (InputManager.GetMouseButtonDown())
{

    Debug.Log("Mouse button down");

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

Returns true if the user has released the primary mouse button.

```csharp
if (InputManager.GetMouseButtonUp())
{

    Debug.Log("Mouse button up");

}
```

#### GetMousePosition

Returns the position of the mouse.

```csharp
Debug.Log(InputManager.GetMousePosition());
```

#### GetActiveTouch

Returns the active touch based on a unique finger ID and a [TouchPhase](https://docs.unity3d.com/ScriptReference/TouchPhase.html) enum filter.

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

```csharp
var touch = InputManager.GetActiveTouch(TouchPhase.Began);

if (touch.HasValue)
{

    Debug.Log(touch.Value.position);

}
```

#### GetTouchDown

Returns true if the user has touched the screen over a specific GameObject.

```csharp
if (InputManager.GetTouchDown(gameObject, mainCamera, ref currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has touched the screen.

```csharp
if (InputManager.GetTouchDown(ref currentFingerId))
{

    Debug.Log("Touch down");

}
```

```csharp
if (InputManager.GetTouchDown())
{

    Debug.Log("Touch down");

}
```

#### GetTouchPosition

Returns the position of a specific touch.

> **Note:** This method will not return a vector if `currentFingerId` has not been populated by a previous call to `Input.GetTouchDown`.

```csharp
Debug.Log(InputManager.GetTouchPosition(currentFingerId));
```

#### GetTouchUp

Returns true if the user has ended a touch on the screen over a specific GameObject.

> **Note:** This method will not return true if `currentFingerId` has not been populated by a previous call to `Input.GetTouchDown`.

```csharp
if (InputManager.GetTouchUp(gameObject, mainCamera, ref currentFingerId, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

Returns true if the user has ended a touch on the screen.

```csharp
if (InputManager.GetTouchUp(ref currentFingerId))
{

    Debug.Log("Touch up");

}
```

```csharp
if (InputManager.GetTouchUp())
{

    Debug.Log("Touch up");

}
```

#### RaycastToGameObject

Returns true if a position collides with a GameObject.

```csharp
if (InputManager.RaycastToGameObject(gameObject, mainCamera, Vector3.zero, out RaycastHit2D hit))
{

    Debug.Log(gameObject.name);

}
```

```csharp
if (InputManager.RaycastToGameObject(gameObject, mainCamera, Vector3.zero, out RaycastHit hit))
{

    Debug.Log(gameObject.name);

}
```
