### Runner

#### OneShot

Wraps an anonymous method in an IEnumerator.

Runs method and then continues after the defined number of seconds.

```csharp
CandyCoded.Runner.OneShot(() => { Debug.Log("Hello!"); }, 2.0f);
```

Runs method and then continues on the next frame.

```csharp
CandyCoded.Runner.OneShot(() => { Debug.Log("Hello!"); });
```
