using System;
using UnityEngine;
using CandyCoded;

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