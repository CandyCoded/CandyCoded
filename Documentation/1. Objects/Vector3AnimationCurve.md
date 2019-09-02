### Vector3AnimationCurve

<img src="https://i.imgur.com/OUL02NQ.png" width="400">

Similar to Unity's `AnimationCurve`, but instead contains 3 `AnimationCurve` properties (`x`, `y`, and `z`) and can be evaluated in the same way as `AnimationCurve` to return a new `Vector3`. `Vector2AnimationCurve` and `Vector4AnimationCurve` structs are also available for generating `Vector2` and `Vector4` values respectively.

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

#### IsLooping

Tests to see if Vector3AnimationCurve loops.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    Debug.Log(animationCurve.IsLooping());

}
```

#### MaxTime

Returns duration of the Vector3AnimationCurve.

```csharp
public CandyCoded.Vector3AnimationCurve animationCurve;

private void Start() {

    Debug.Log(animationCurve.MaxTime());

}
```

**Note:** This struct is compatible with CandyCoded's [Animate](#animate) methods [Position](#position) and [Scale](#scale).
