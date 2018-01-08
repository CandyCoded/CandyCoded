# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

_**Note:** The APIs in CandyCoded may change as this library is currently in development and hasn't reached a point where semver make sense._

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
    - [Materials](#materials)
    - [Raycast](#raycast)
    - [Singleton](#singleton)
- Unity Editor Inspector Methods
    - [StandardShader](#standardshader)

## Components

### CameraFollow

Attach the CameraFollow component to any gameobject that moves independently of the camera. Utilizing the constraint options allows for the camera to either stay a certain distance from the object or lock any of the axis from moving at all.

![](https://media.giphy.com/media/l49JC79lqlSLFUQlG/giphy.gif)

### Gizmo

![](https://i.imgur.com/jjK2N8a.png)
![](https://i.imgur.com/ZOErDc2.png)

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

#### Position

```csharp
CandyCoded.Animate.Position(gameObject, Time.deltaTime, Vector3.right, animationCurve);
```

#### Scale

```csharp
CandyCoded.Animate.Scale(gameObject, Time.deltaTime, Vector3.one, animationCurve);
```

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

### Raycast

#### Reflect

```csharp
Vector3[] linePositions = CandyCoded.Raycast.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask);

lineRenderer.positionCount = linePositions.Length;
lineRenderer.SetPositions(linePositions);
```

```csharp
List<RaycastHit> hits;

Vector3[] linePositions = CandyCoded.Raycast.Reflect(gameObject.transform.position, gameObject.transform.forward, distance, layerMask, out hits);
```

![](https://media.giphy.com/media/l3mZp4n2EdtFggeDS/giphy.gif)
![](https://media.giphy.com/media/3ohs7MYwAjHtvGkqrK/giphy.gif)

### Singleton

```csharp
public class InputController : CandyCoded.Singleton {

}
```

## Unity Editor Inspector Methods

### StandardShader

```csharp
CandyCoded.StandardShader.SetupMaterialWithBlendMode(material, CandyCoded.StandardShader.BlendMode.Fade);
```
