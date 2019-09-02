### EnumMask

Creates a dropdown in the inspector which allows for selecting of one or more enum values.

```csharp
using UnityEngine;

public class EnumMaskDemo : MonoBehaviour
{

    public enum State
    {
        None = 0,
        Idle = 1 << 0,
        Running = 1 << 1,
        Falling = 1 << 2,
        Jumping = 1 << 3,
        All = ~0
    }

    public State currentState = State.Idle;

    [EnumMask]
    public State availableStates = State.Idle | State.Running | State.Falling;

    private void Start()
    {

        // Typecast both availableStates and individual enum values to an int
        // to run a bitwise comparison using Contains (part of CandyCoded)
        Debug.Log(((int) availableStates).Contains((int) State.Jumping)); // False

    }

}
```

<img src="https://i.imgur.com/s5rlIIF.png" width="400">
