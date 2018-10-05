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
