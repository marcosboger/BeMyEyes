using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager>
{
    const string highScoreRacingPrefKey = "highScoreRacing";
    const string highScoreJumpingPrefKey = "highScoreJumping";
    const string highScoreColourPrefKey = "highScoreColour";

    public int racingGameHighScore = 500;
    public int jumpingGameHighScore = 500;
    public int colourGameHighScore = 20;
    public string gamePlayed = "RacingGame";

    private void Start()
    {
        if (PlayerPrefs.HasKey(highScoreRacingPrefKey))
        {
            racingGameHighScore = PlayerPrefs.GetInt(highScoreRacingPrefKey);
        }

        if (PlayerPrefs.HasKey(highScoreJumpingPrefKey))
        {
            jumpingGameHighScore = PlayerPrefs.GetInt(highScoreJumpingPrefKey);
        }

        if (PlayerPrefs.HasKey(highScoreColourPrefKey))
        {
            colourGameHighScore = PlayerPrefs.GetInt(highScoreColourPrefKey);
        }
    }

    public void setRacingHighScore(int score)
    {
        if (score > racingGameHighScore)
        { 
            racingGameHighScore = score;
            PlayerPrefs.SetInt(highScoreRacingPrefKey, score);
        }
    }

    public void setJumpingHighScore(int score)
    {
        if (score > jumpingGameHighScore)
        {
            jumpingGameHighScore = score;
            PlayerPrefs.SetInt(highScoreJumpingPrefKey, score);
        }
    }

    public void setColourHighScore(int score)
    {
        if (score > colourGameHighScore)
        {
            colourGameHighScore = score;
            PlayerPrefs.SetInt(highScoreColourPrefKey, score);
        }
    }
}
