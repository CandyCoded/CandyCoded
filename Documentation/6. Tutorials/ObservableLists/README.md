# ObservableLists

```csharp
using CandyCoded;
using UnityEngine;

public static class CubeManager
{

    public static ObservableList<GameObject> Cubes = new ObservableList<GameObject>();

}
```

```csharp
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _spawnerPrefab;

    public void SpawnCube()
    {

        CubeManager.Cubes.Add(Instantiate(_spawnerPrefab));

    }

}
```

```csharp
using UnityEngine;
using UnityEngine.UI;

public class CubeCount : MonoBehaviour
{

    [SerializeField] private Text _textComp;

    private void CubesOnAddEvent(GameObject item)
    {

        _textComp.text = $"Cubes: {CubeManager.Cubes.Count}";

    }

    private void OnEnable()
    {

        CubeManager.Cubes.AddEvent += CubesOnAddEvent;

    }

    private void OnDisable()
    {

        CubeManager.Cubes.AddEvent -= CubesOnAddEvent;

    }

}
```
