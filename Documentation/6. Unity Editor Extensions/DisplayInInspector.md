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
