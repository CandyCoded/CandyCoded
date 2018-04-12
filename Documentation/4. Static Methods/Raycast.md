### Raycast

#### Reflect

Creates a raycast that can reflect off certain objects in a layer mask.

```csharp
Vector3[] linePositions = CandyCoded.Raycast.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask);

lineRenderer.positionCount = linePositions.Length;
lineRenderer.SetPositions(linePositions);
```

Objects that are hit can also be returned to an array by reference.

```csharp
List<RaycastHit> hits;

Vector3[] linePositions = CandyCoded.Raycast.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask, out hits);
```

![](https://media.giphy.com/media/55tArjOMKt3uUQp9KQ/giphy.gif)
