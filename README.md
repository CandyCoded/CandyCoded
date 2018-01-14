# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

_**Note:** The APIs in CandyCoded may change as this library is currently in development and hasn't reached a point where semver make sense._

## Contents

- [Components](#components)
    - [CameraFollow](#camerafollow)
    - [Gizmo](#gizmo)
    - [ScreenShake](#screenshake)
    - [SelfDestructParticleSystem](#selfdestructparticlesystem)
- [Static Methods](#static-methods)
    - [Animate](#animate)
    - [Calculation](#calculation)
    - [Debug](#debug)
    - [InputManager](#inputmanager)
    - [Materials](#materials)
    - [Raycast](#raycast)
    - [Singleton](#singleton)
- [ScriptableObject](#scriptableobject)
    - [Bool](#bool)
    - [Float](#float)
    - [GameObjectList](#gameobjectlist)
    - [Int](#int)
    - [String](#string)
    - [Creating Custom Scriptable Objects](#creating-custom-scriptable-objects)
- [Unity Editor Extensions](#unity-editor-extensions)
    - [EnumMask](#enummask)
- [Unity Editor Inspector Methods](#unity-editor-inspector-methods)
    - [StandardShader](#standardshader)

## Components

### CameraFollow

Attach the CameraFollow component to any gameobject that moves independently of the camera. Utilizing the constraint options allows for the camera to either stay a certain distance from the object or lock any of the axis from moving at all. This component works with both 2D and 3D scenes.

![](https://media.giphy.com/media/3ohc19nAziNNVAQ4I8/giphy.gif)

### Gizmo

Attach this component to any gameobject to render a custom gizmo. These gizmos will appear even when the gameobject is not selected.

![](https://i.imgur.com/uPUyFZU.png)
![](https://i.imgur.com/aCzOiKV.png)

### ScreenShake

Attach this component to your scenes camera and call the method below to cause the screen to shake. This component doesn't alter the position of the camera as it wraps the camera in it's own gameobject.

```csharp
CandyCoded.ScreenShake screenShake = Camera.main.GetComponent<CandyCoded.ScreenShake>();
screenShake.Shake(duration, intensity);
```

```csharp
CandyCoded.ScreenShake screenShake = Camera.main.GetComponent<CandyCoded.ScreenShake>();
screenShake.Shake(duration, intensity, CandyCoded.SCREENSHAKE_DIRECTION.Horizontal);
```

```csharp
CandyCoded.ScreenShake screenShake = Camera.main.GetComponent<CandyCoded.ScreenShake>();
screenShake.Shake(duration, intensity, CandyCoded.SCREENSHAKE_DIRECTION.Vertical);
```

![](https://media.giphy.com/media/xULW8MNwUyL5aqUJ7W/giphy.gif)

### SelfDestructParticleSystem

Attach this component to a gameobject with a ParticleSystem that doesn't loop and once the generated particles are no longer alive, the gameobject will destroy itself.

## Static Methods

### Animate

#### FadeIn

```csharp
CandyCoded.Animate.FadeIn(gameObject, Time.deltaTime);
```

```csharp
AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);
animationCurve.postWrapMode = WrapMode.PingPong;
CandyCoded.Animate.FadeCustom(gameObject, Time.deltaTime, animationCurve);
```

#### FadeOut

```csharp
CandyCoded.Animate.FadeOut(gameObject, Time.deltaTime);
```

```csharp
AnimationCurve animationCurve = AnimationCurve.Linear(0, 1, 1, 0);
animationCurve.postWrapMode = WrapMode.PingPong;
CandyCoded.Animate.FadeCustom(gameObject, Time.deltaTime, animationCurve);
```

![](https://media.giphy.com/media/xULW8zdlmLdaSSXDeU/giphy.gif)

#### Position

```csharp
AnimationCurve animationCurve = AnimationCurve.Linear(0, -5, 1, 5);
animationCurve.postWrapMode = WrapMode.PingPong;
CandyCoded.Animate.Position(gameObject, Time.deltaTime, Vector3.right, animationCurve);
```

![](https://media.giphy.com/media/26gN0r9WRYvJdWtH2/giphy.gif)

#### Scale

```csharp
AnimationCurve animationCurve = AnimationCurve.Linear(0, 1, 1, 0);
animationCurve.postWrapMode = WrapMode.PingPong;
CandyCoded.Animate.Scale(gameObject, Time.deltaTime, Vector3.one, animationCurve);
```

![](https://media.giphy.com/media/3oFzmbso61huQUxQ0U/giphy.gif)

#### Rotate

```csharp
AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 360);
animationCurve.postWrapMode = WrapMode.Loop;
CandyCoded.Animate.Rotate(gameObject, Time.deltaTime, Vector3.up, animationCurve);
```

![](https://media.giphy.com/media/l49JDBAz6Il9HUB5C/giphy.gif)

### Calculation

#### ParentBounds

Calculate the bounds of a gameobject with multiple children.

```csharp
void OnDrawGizmosSelected()
{

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

**Warning: Being considered for deprecation in favor of the new Unity InputSystem** <https://github.com/Unity-Technologies/InputSystem>

```csharp
Debug.Log(CandyCoded.InputManager.InputDown);
Debug.Log(CandyCoded.InputManager.InputScreenPosition);
Debug.Log(CandyCoded.InputManager.InputUp);
```

### Materials

#### GetMaterialsInChildren

Similar in use to GetComponentsInChildren, GetMaterialsInChildren will return all materials attached to renderers that are children of the supplied gameobject.

```csharp
Material[] materials = CandyCoded.Materials.GetMaterialsInChildren(gameObject);
```

#### SetAlphaColor

Set the alpha of a color to a value.

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

Creates a raycast that can reflect off certain objects in a layer mask.

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

**Warning: Being considered for depreciation**

```csharp
public class InputController : CandyCoded.Singleton
{

}
```

## ScriptableObject

Each ScriptableObject has a `value` and a `defaultValue`. The `value` can be modified via script, the `defaultValue` can not. A `Reset` method is publicly available to reset the `value` to equal the `defaultValue`. This method is also accessible via the inspector.

## Bool

![](https://i.imgur.com/BeRRAWO.png)

## Float

![](https://i.imgur.com/xMX202E.png)

## GameObjectList

![](https://i.imgur.com/x60IcUO.png)

## Int

![](https://i.imgur.com/899tEuG.png)

## String

![](https://i.imgur.com/cJslkol.png)

## Creating Custom Scriptable Objects

```csharp
[CreateAssetMenu]
public class Vector3Reference : CandyCoded.CustomGenericScriptableObject<Vector3>
{

}
```

![](https://i.imgur.com/9opk8j8.png)

## Unity Editor Extensions

### EnumMask

```csharp
using UnityEngine;

public class EnumMaskDemo : MonoBehaviour
{

    public enum STATE
    {
        None = 0,
        Idle = 1 << 0,
        Running = 1 << 1,
        Falling = 1 << 2,
        Jumping = 1 << 3,
        All = ~0
    }

    [EnumMask]
    public STATE currentState = STATE.Idle;
    public STATE availableStates = STATE.Idle | STATE.Running | STATE.Falling;

    void Start()
    {

        // Typecast both availableStates and individual enum values to an int
        // to run a bitwise comparison using Contains (part of CandyCoded)
        Debug.Log(((int) availableStates).Contains((int) STATE.Jumping)); // False

    }

}
```

![](https://i.imgur.com/JVrIJ4N.png)

## Unity Editor Inspector Methods

### StandardShader

```csharp
CandyCoded.StandardShader.SetupMaterialWithBlendMode(material, CandyCoded.StandardShader.BlendMode.Fade);
```
