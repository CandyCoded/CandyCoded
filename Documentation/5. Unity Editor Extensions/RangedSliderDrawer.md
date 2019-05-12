# RangedSliderDrawer

Creates a stepable range selector in the inspector panel on a `RangedFloat`.

## Min/Max Properties Set

```csharp
[SerializeField]
[RangedSlider(0, 1)]
private RangedFloat volume;
```

## Min/Max/Step Properties Set

```csharp
[SerializeField]
[RangedStepSlider(0, 1, 0.1f)]
private RangedFloat volume;
```

![](https://media.giphy.com/media/J2IUzelKC3PlVZGmhD/giphy.gif)
