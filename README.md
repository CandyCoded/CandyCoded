# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

## Contents

- Components
    - [CameraFollow](#camerafollow)
    - [Gizmo](#gizmo)
    - [ScreenShake](#screenshake)
    - [SelfDestructParticleSystem](#selfdestructparticlesystem)
- Static Methods
    - [Animate](#animate)
    - [Calculation](#calculation)
    - [Debug](#debug)
    - [InputManager](#inputmanager)
    - [LineRenderer](#linerenderer)
    - [Materials](#materials)
    - [Singleton](#Singleton)
- Unity Editor Insepctor Methods
    - [StandardShader](#standardshader)

## Components

### CameraFollow

![](https://media.giphy.com/media/l49JC79lqlSLFUQlG/giphy.gif)

### Gizmo

### ScreenShake

### SelfDestructParticleSystem


## Static Methods

### Animate

#### FadeIn

```csharp
CandyCoded.Animate.FadeIn(gameObject, Time.deltaTime);
```

```csharp
AnimationCurve animationCurveFadeIn = AnimationCurve.Linear(0, 0, 1, 1);
CandyCoded.Animate.FadeCustom(gameObject, Time.deltaTime, animationCurveFadeIn);
```

#### FadeOut

```csharp
CandyCoded.Animate.FadeOut(gameObject, Time.deltaTime);
```

```csharp
AnimationCurve animationCurveFadeOut = AnimationCurve.Linear(0, 1, 1, 0);
CandyCoded.Animate.FadeCustom(gameObject, Time.deltaTime, animationCurveFadeOut);
```

![](https://media.giphy.com/media/3ohc1bNoAxiYuBm7x6/giphy.gif)

### Calculation

#### ParentBounds

```csharp
void OnDrawGizmosSelected() {

    Bounds bounds = CandyCoded.Calculation.ParentBounds(gameObject);

    Gizmos.DrawWireSphere(bounds.center, 1f);
    Gizmos.DrawWireSphere(bounds.min, 1f);
    Gizmos.DrawWireSphere(bounds.max, 1f);
    Gizmos.DrawWireCube(bounds.center, bounds.size);

}
```

![](https://i.imgur.com/yX5f6rk.png)

### Debug

#### DrawLines

```csharp
CandyCoded.Debug.DrawLines(points, Color.red);
```

### InputManager

```csharp
Debug.Log(CandyCoded.InputManager.InputDown);
Debug.Log(CandyCoded.InputManager.InputScreenPosition);
Debug.Log(CandyCoded.InputManager.InputUp);
```

### LineRenderer

#### Reflect

```csharp
Vector3[] linePositions = CandyCoded.LineRenderer.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask);

lineRenderer.positionCount = linePositions.Length;
lineRenderer.SetPositions(linePositions);
```

![](https://media.giphy.com/media/l3mZp4n2EdtFggeDS/giphy.gif)
![](https://media.giphy.com/media/3ohs7MYwAjHtvGkqrK/giphy.gif)

### Materials

#### GetMaterialsInChildren

```csharp
Material[] materials = CandyCoded.Materials.GetMaterialsInChildren(gameObject);
```

#### SetAlphaColor

```csharp
Debug.Log(CandyCoded.Materials.SetColorAlpha(material.color, 0.5f));
```

#### SetMaterialsToFade

```csharp
CandyCoded.Materials.SetMaterialsToBlendMode(materials, CandyCoded.StandardShader.BlendMode.Opaque);
CandyCoded.Materials.SetMaterialsToBlendMode(materials, CandyCoded.StandardShader.BlendMode.Fade);
```

### Singleton

```csharp
public class InputController : CandyCoded.Singleton {

}
```

## Unity Editor Insepctor Methods

### StandardShader

```csharp
CandyCoded.StandardShader.SetupMaterialWithBlendMode(material, CandyCoded.StandardShader.BlendMode.Fade);
```
