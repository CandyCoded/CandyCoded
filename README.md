# UnityUtilities

## Gizmo

## LineRenderer

### Reflect

```csharp
Vector3[] linePositions = ScottDoxey.LineRenderer.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask);

lineRenderer.positionCount = linePositions.Length;
lineRenderer.SetPositions(linePositions);
```

## Singleton

```csharp
public class InputController : ScottDoxey.Singleton {

}
```
