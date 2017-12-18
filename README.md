# UnityUtilities

## Animate

## FadeIn

```csharp
ScottDoxey.Animate.FadeIn(gameObject, Time.time);
```

```csharp
AnimationCurve animationCurveFadeIn = AnimationCurve.Linear(0, 0, 1, 1);
ScottDoxey.Animate.FadeCustom(gameObject, Time.time, animationCurveFadeIn);
```

## FadeOut

```csharp
ScottDoxey.Animate.FadeOut(gameObject, Time.time);
```

```csharp
AnimationCurve animationCurveFadeOut = AnimationCurve.Linear(0, 1, 1, 0);
ScottDoxey.Animate.FadeOut(gameObject, Time.time, animationCurveFadeOut);
```

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

![](https://media.giphy.com/media/l3mZp4n2EdtFggeDS/giphy.gif)
![](https://media.giphy.com/media/3ohs7MYwAjHtvGkqrK/giphy.gif)

## Materials

### GetMaterialsInChildren

```csharp
Material[] materials = ScottDoxey.Materials.GetMaterialsInChildren(gameObject);
```

### SetAlphaColor

```csharp
Debug.Log(ScottDoxey.Materials.SetColorAlpha(material.color, 0.5f));
```

### SetMaterialsToFade

```csharp
ScottDoxey.Materials.SetMaterialsToBlendMode(materials, ScottDoxey.StandardShader.BlendMode.Opaque);
ScottDoxey.Materials.SetMaterialsToBlendMode(materials, ScottDoxey.StandardShader.BlendMode.Fade);
```

## ScreenShake

## SelfDestructParticleSystem

## Singleton

```csharp
public class InputController : ScottDoxey.Singleton {

}
```

## StandardShader

```csharp
ScottDoxey.StandardShader.SetupMaterialWithBlendMode(material, ScottDoxey.StandardShader.BlendMode.Fade);
```
