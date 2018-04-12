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
