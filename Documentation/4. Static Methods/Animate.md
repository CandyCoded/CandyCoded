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
