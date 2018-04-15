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
