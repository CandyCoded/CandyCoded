# UnityUtilities

## Gizmo

## InputManager

```csharp
Debug.Log(ScottDoxey.InputManager.InputDown);
Debug.Log(ScottDoxey.InputManager.InputScreenPosition);
Debug.Log(ScottDoxey.InputManager.InputUp);
```

## LineRenderer

### Reflect

```csharp
Vector3[] linePositions = ScottDoxey.LineRenderer.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask);

lineRenderer.positionCount = linePositions.Length;
lineRenderer.SetPositions(linePositions);
```

![](https://media.giphy.com/media/xUOxeRFdNUuntIuxva/giphy.gif)

## Singleton

```csharp
public class InputController : ScottDoxey.Singleton {

}
```
