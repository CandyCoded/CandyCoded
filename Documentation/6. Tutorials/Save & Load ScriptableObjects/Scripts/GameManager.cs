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