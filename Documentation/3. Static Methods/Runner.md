### Runner

#### OneShot

Wraps an anonymous method in an IEnumerator.

Runs method and then continues after the defined number of seconds.

```csharp
private void Start()
{

    StartCoroutine(Sequence());

}

private IEnumerator Sequence()
{

    yield return CandyCoded.Runner.OneShot(() => { Debug.Log("Hello!"); }, 2.0f);

}
```

Runs method and then continues on the next frame.

```csharp
private void Start()
{

    StartCoroutine(Sequence());

}

private IEnumerator Sequence()
{

    yield return CandyCoded.Runner.OneShot(() => { Debug.Log("Hello!"); });

}
```

Used in a sequence.

```csharp
public class RunnerTest : MonoBehaviour
{

    private void Start()
    {

        StartCoroutine(Sequence());

    }

    private IEnumerator Sequence()
    {

        yield return CandyCoded.Runner.OneShot(() => { Debug.Log("Hello,"); });

        yield return new WaitForSeconds(2.0f);

        yield return CandyCoded.Runner.OneShot(() => { Debug.Log("World!"); });

    }

}
```
