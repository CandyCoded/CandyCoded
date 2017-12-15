# UnityUtilities

## Calculation

### ParentBounds

```csharp
void OnDrawGizmosSelected() {

    Bounds bounds = ScottDoxey.Calculation.ParentBounds(gameObject);

    Gizmos.DrawWireSphere(bounds.center, 1f);
    Gizmos.DrawWireSphere(bounds.min, 1f);
    Gizmos.DrawWireSphere(bounds.max, 1f);
    Gizmos.DrawWireCube(bounds.center, bounds.size);

}
```

![](https://i.imgur.com/yX5f6rk.png)

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
