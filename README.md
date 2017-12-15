# UnityUtilities

## Calculation

### ParentBounds

```csharp
Debug.Log(ScottDoxey.Calculation.ParentBounds(parentGameObject).center);
```

## CameraFollow2D

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

![](https://media.giphy.com/media/3ohs7KwdbkkXu5LLe8/giphy.gif)

## ScreenShake

## SelfDestructParticleSystem

## Singleton

```csharp
public class InputController : ScottDoxey.Singleton {

}
```
