# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

[![Build Status](https://travis-ci.org/neogeek/CandyCoded.svg?branch=master)](https://travis-ci.org/neogeek/CandyCoded)
[![Join the chat at https://discord.gg/nNtFsfd](https://img.shields.io/badge/discord-join%20chat-7289DA.svg)](https://discord.gg/nNtFsfd)

## Installation

[Download Latest `CandyCoded.unitypackage`](https://github.com/neogeek/CandyCoded/releases)

## Contents

- [Structs](#structs)
    - [Vector3AnimationCurve](#vector3animationcurve)
- [Components](#components)
    - [CameraFollow2D](#camerafollow2d)
    - [CameraFollow3D](#camerafollow3d)
    - [Gizmo](#gizmo)
    - [ScreenShake](#screenshake)
    - [SelfDestructParticleSystem](#selfdestructparticlesystem)
- [Custom Extensions](#custom-extensions)
    - [AnimationCurve](#animationcurve)
        - [IsLooping](#islooping)
        - [MaxTime](#maxtime)
    - [GameObject](#gameobject)
        - [AddOrGetComponent](#addorgetcomponent)
    - [Int](#int)
        - [Contains](#contains)
    - [LayerMask](#layermask)
        - [Contains](#contains-1)
    - [List](#list)
        - [Shuffle](#shuffle)
    - [Transform](#transform)
        - [LookAt2D](#lookat2d)
- [Static Methods](#static-methods)
    - [Animate](#animate)
        - [Fade](#fade)
        - [MoveTo](#moveto)
        - [Position](#position)
        - [PositionRelative](#positionrelative)
        - [ScaleTo](#scaleto)
        - [Scale](#scale)
        - [ScaleRelative](#scalerelative)
        - [RotateTo](#rotateto)
        - [Rotate](#rotate)
        - [Stop](#stop)
        - [StopAll](#stopall)
    - [Calculation](#calculation)
        - [ParentBounds](#parentbounds)
    - [Debugger](#debugger)
        - [DrawLines](#drawlines)
    - [Materials](#materials)
        - [GetMaterialsInChildren](#getmaterialsinchildren)
        - [SetColorAlpha](#setcoloralpha)
    - [Raycast](#raycast)
        - [Reflect](#reflect)
- [ScriptableObject](#scriptableobject)
    - [Bool](#bool)
    - [Float](#float)
    - [GameObjectList](#gameobjectlist)
    - [Int](#int-1)
    - [String](#string)
    - [Creating Custom Scriptable Objects](#creating-custom-scriptable-objects)
- [Unity Editor Extensions](#unity-editor-extensions)
    - [DisplayInInspector](#displayininspector)
    - [EnumMask](#enummask)
- [Custom Materials](#custommaterials)
- [Shaders](#shaders)
    - [TiledTexture](#tiledtexture)

## Structs

### Vector3AnimationCurve

![](https://i.imgur.com/OUL02NQ.png)

Similar to Unity's `AnimationCurve`, but instead contains 3 `AnimationCurve` properties (`x`, `y`, and `z`) and can be evaluated in the same way as `AnimationCurve` to return a new `Vector3`. A `Vector2AnimationCurve` struct is also available for generating `Vector2` values.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Update()
{

    gameObject.transform.position = animationCurve.Evaluate(Time.time);

}
```

#### EditKeyframeValue

Edit the values of the corresponding keyframes in a Vector3AnimationCurve leaving the time and curve of each keyframe untouched.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    animationCurve.EditKeyframeValue(0, new Vector3(10, 10, 10));

}
```

**Note:** This struct is compatible with CandyCoded's [Animate](#animate) methods [Position](#position), [Scale](#scale), and [Rotate](#rotate).

## Components

### CameraFollow2D

Attach the CameraFollow2D component to any GameObject that moves independently of the camera. Utilizing the constraint options allows for the camera to be bound to a certain GameObject or custom bounds settings, or locking any of the axis from moving at all.

![](https://media.giphy.com/media/3ohc19nAziNNVAQ4I8/giphy.gif)

### CameraFollow3D

Attach the CameraFollow3D component to any GameObject that moves independently of the camera. Utilizing the constraint options allows for the camera to either stay a certain distance from the object or lock any of the axis from moving at all.

![](https://media.giphy.com/media/e7QN9KYhCIpqV9c1X4/giphy.gif)

This camera also supports a seconday target where in the camera will follow behind the main target, but look towards the seconday target.

![](https://media.giphy.com/media/wZrmr7mSPNmh8u7iLl/giphy.gif)

### Gizmo

Attach this component to any GameObject to render a custom gizmo. These gizmos will appear even when the GameObject is not selected.

![](https://i.imgur.com/PduNRej.png)
![](https://i.imgur.com/4ACDgta.png)
![](https://i.imgur.com/30roCjx.png)

### ScreenShake

Attach this component to your scenes camera and call the method below to cause the screen to shake. This component doesn't alter the position of the camera as it wraps the camera in it's own GameObject.

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

Attach this component to a GameObject with a ParticleSystem that doesn't loop and once the generated particles are no longer alive, the GameObject will destroy itself.

## Custom Extensions

### AnimationCurve

#### EditKeyframeValue

Edit the value of a keyframe in an AnimationCurve leaving the time and curve untouched.

```csharp
public AnimationCurve animationCurve;

private void Start() {

    animationCurve.EditKeyframeValue(0, 10);

}
```

#### IsLooping

Tests to see if AnimationCurve loops.

```csharp
public AnimationCurve animationCurve;

private void Start() {

    Debug.Log(animationCurve.IsLooping());

}
```

#### MaxTime

Returns duration of the AnimationCurve.

```csharp
public AnimationCurve animationCurve;

private void Start() {

    Debug.Log(animationCurve.MaxTime());

}
```

### GameObject

#### AddOrGetComponent

Returns a reference to an existing component or a new component if it didn't already exist.

```csharp
private Rigidbody rb;

private void Awake() {

    rb = gameObject.AddOrGetComponent<Rigidbody>();

}
```

### Int

#### Contains

Tests bitmask int for the supplied int.

```csharp
int mask = 0 | 1;
Debug.Log(mask.Contains(1)); // true
Debug.Log(mask.Contains(2)); // false
```

### LayerMask

#### Contains

Tests LayerMask for the supplied Layer name or int.

```csharp
LayerMask layerMask = ~0;
Debug.Log(layerMask.Contains("Water")); // true
```

```csharp
LayerMask layerMask = ~0;
Debug.Log(layerMask.Contains(4)); // true
```

### List

#### Shuffle

Creates a new copy of a list and shuffles the values.

```csharp
List<float> randomValues = new List<float>();
shuffledRandomValues = randomValues.Shuffle();
```

### Transform

#### LookAt2D

Rotates transform so the forward vector (or supplied Vector3) points at target's position.

```csharp
gameObject.transform.LookAt2D(currentMousePosition);
```

```csharp
gameObject.transform.LookAt2D(currentMousePosition, Vector3.right);
```

## Static Methods

### Animate

**Note:** For fade animations to work you need to have materials with a blend mode of fade.

![](https://i.imgur.com/J9gS7pc.png)

#### Fade

**Note:** 100% alpha is relative to each GameObject's initial alpha value. This is to prevent materials with custom alpha values from being reset.

Fade a GameObject from 0% to 100% with a duration of 1s.

```csharp
CandyCoded.Animate.Fade(gameObject, 0, 1, 1);
```

Fade a GameObject from 100% to 0% with a duration of 1s.

```csharp
CandyCoded.Animate.Fade(gameObject, 1, 0, 1);
```

Fade a GameObject with a custom AnimationCurve.

```csharp
public AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.Fade(gameObject, animationCurve);

}
```

![](https://media.giphy.com/media/xULW8zdlmLdaSSXDeU/giphy.gif)

#### MoveTo

Move a GameObject to a new Vector3 with a duration of 1s.

```csharp
CandyCoded.Animate.MoveTo(target, new Vector3(10, 10, 10), 1);
```

![](https://media.giphy.com/media/3ohc0Wy60RfUYSERW0/giphy.gif)

#### Position

Move GameObject with a custom Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.Position(gameObject, animationCurve);

}
```

#### PositionRelative

Move GameObject, relative to it's original position, with a custom Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.PositionRelative(gameObject, animationCurve);

}
```

#### ScaleTo

Scale a GameObject to a new Vector3 with a duration of 1s.

```csharp
CandyCoded.Animate.ScaleTo(target, new Vector3(2, 2, 2), 1);
```

![](https://media.giphy.com/media/l0HUfPOnvdomnsz0A/giphy.gif)

#### Scale

Scale GameObject with a custom Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.Scale(gameObject, animationCurve);

}
```

#### ScaleRelative

Scale GameObject, relative to it's original scale, with a custom Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.ScaleRelative(gameObject, animationCurve);

}
```

#### RotateTo

Rotate a GameObject to a new Vector3 with a duration of 1s.

```csharp
CandyCoded.Animate.RotateTo(target, new Vector3(360, 0, 0), 1);
```

![](https://media.giphy.com/media/d3OGaCsXxQSUtLgc/giphy.gif)

#### Rotate

Rotate GameObject with a custom Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    CandyCoded.Animate.Rotate(gameObject, animationCurve);

}
```

#### Stop

Stop animation attached to a GameObject by name.

```csharp
private void Start() {

    CandyCoded.Animate.Stop(gameObject, "Fade");

}
```

#### StopAll

Stops all animations attached to a GameObject.

```csharp
private void Start() {

    CandyCoded.Animate.StopAll(gameObject);

}
```

### Calculation

#### ParentBounds

Calculate the bounds of a GameObject with multiple children.

```csharp
private void OnDrawGizmosSelected()
{

    Bounds bounds = CandyCoded.Calculation.ParentBounds(gameObject);

    Gizmos.DrawWireSphere(bounds.center, 1f);
    Gizmos.DrawWireSphere(bounds.min, 1f);
    Gizmos.DrawWireSphere(bounds.max, 1f);
    Gizmos.DrawWireCube(bounds.center, bounds.size);

}
```

![](https://i.imgur.com/yX5f6rk.png)

### Debugger

#### DrawLines

Draws an array (or list) of vectors with Unity's [`Debug.DrawLine`](https://docs.unity3d.com/ScriptReference/Debug.DrawLine.html) method. DrawLines contains the same display parameters as Unity's DrawLine method: color, duration and depthTest.

**Color:** Color of lines.

```csharp
CandyCoded.Debugger.DrawLines(points, Color.red);
```

**Duration:** Duration lines remains visible.

```csharp
CandyCoded.Debugger.DrawLines(points, Color.red, 1f);
```

**DepthTest:** Should lines be obscured with objects closer to camera?

```csharp
CandyCoded.Debugger.DrawLines(points, Color.red, 1f, false);
```

### Materials

#### GetMaterialsInChildren

Returns an array of materials attached to renderers that are children of the supplied GameObject.

```csharp
Material[] materials = CandyCoded.Materials.GetMaterialsInChildren(gameObject);
```

#### SetColorAlpha

Set the alpha value of a color object.

```csharp
Debug.Log(CandyCoded.Materials.SetColorAlpha(material.color, 0.5f));
```

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

### DisplayInInspector

Adds a button, with the name of the method, to the bottom of the inspector that when pressed will run the attached method.

```csharp
using UnityEngine;

public class DisplayInInspectorDemo : MonoBehaviour
{

    [DisplayInInspector]
    private void Boop()
    {

        Debug.Log("boop");

    }

}
```

![](https://i.imgur.com/u8t3Etf.png)

### EnumMask

Creates a dropdown in the inspector which allows for selecting of one or more enum values.

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

    public STATE currentState = STATE.Idle;

    [EnumMask]
    public STATE availableStates = STATE.Idle | STATE.Running | STATE.Falling;

    private void Start()
    {

        // Typecast both availableStates and individual enum values to an int
        // to run a bitwise comparison using Contains (part of CandyCoded)
        Debug.Log(((int) availableStates).Contains((int) STATE.Jumping)); // False

    }

}
```

![](https://i.imgur.com/s5rlIIF.png)

## Custom Materials

![](https://i.imgur.com/tIL3HOQ.png)

## Shaders

### TiledTexture

This shader is used to tile materials without scaling on either a cuboid or plane.

**Tiling:** Used to determine how many times the material should be tiled.

**Offset:** Used to offset the material.

**Use World Space:** Used to position the tile relative to world space, instead of the GameObject.

![](https://i.imgur.com/b7XbN5d.png)

## Credits

Fonts used in logo are [**Escafina**](http://www.losttype.com/font/?name=escafina) and [**Klinic Slab**](http://www.losttype.com/font/?name=klinic), both from [**Lost Type**](http://www.losttype.com/).

