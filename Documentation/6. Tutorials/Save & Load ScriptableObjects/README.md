# Save & Load ScriptableObjects

This tutorial will walk you through creating persistent state across play sessions using a `ScriptableObject` and CandyCoded's `SaveManager` feature.

First, we will start by creating a `ScriptableObject`.

```csharp
[CreateAssetMenu(fileName = "GameStateReference", menuName = "GameStateReference")]
public class GameStateReference : ScriptableObject
{

}
```

I've given the `ScriptableObject` a `CreateAssetMenu` name, so I can right-click within the asset panel and create a new instance of this `ScriptableObject` for use.

Next, we will add state to the `ScriptableObject`. I've opted to keep this example simple and store a few properties related to the player and score.

```csharp
[Serializable]
public struct Player
{

    public string playerName;

    public float currentHealth;

}

[Serializable]
public struct Score
{

    public int currentScore;

    public int highScore;

}
```

Note: Both of these structs must be `Serializable`, or the `SaveManager` won't be able to save data out or load data into them.

Next, we add the structs to the `ScriptableObject`.

```csharp
[CreateAssetMenu(fileName = "GameStateReference", menuName = "GameStateReference")]
public class GameStateReference : ScriptableObject
{

    public Player player;

    public Score score;

}
```

Now, we add methods for saving and loading data in and out of the `ScriptableObject`.

```csharp
[CreateAssetMenu(fileName = "GameStateReference", menuName = "GameStateReference")]
public class GameStateReference : ScriptableObject
{

    public Player player;

    public Score score;

    public void SavePlayerData()
    {

        SaveManager.SaveData(player, "Player.dat");

    }

    public void SaveScoreData()
    {

        SaveManager.SaveData(score, "Score.dat");

    }

    public void Load()
    {

        try
        {

            player = SaveManager.LoadData<Player>("Player.dat");
            score = SaveManager.LoadData<Score>("Score.dat");

        }
        catch (Exception err)
        {

            Debug.LogWarning(err.Message);

        }

    }

}
```

The try/catch block around the `LoadData` method call is there because when you first run this, those files won't exist. `LoadData` bubbles up an exception to let you know this. In most cases, this won't be something you would need to act on, but the exception is there if you need it.

Finally, let's add this to your game! I've made a simple script to store a reference to the `ScriptableObject` and have it load on enable and save on disable.

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameStateReference _gameStateReference;

    private void OnEnable()
    {

        _gameStateReference.Load();

    }

    private void OnDisable()
    {

        _gameStateReference.SavePlayerData();
        _gameStateReference.SaveScoreData();

    }

}
```

When using this in your game, you would most likely want to call `SavePlayerData` or `SaveScoreData` when a significant change was made to those files to make sure the change is stored.
