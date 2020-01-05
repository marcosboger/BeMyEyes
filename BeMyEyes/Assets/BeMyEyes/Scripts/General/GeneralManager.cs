using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager>
{
    const string highScoreRacingPrefKey = "highScoreRacing";
    const string highScoreJumpingPrefKey = "highScoreJumping";
    const string highScoreColourPrefKey = "highScoreColour";
    const string highScoreShootingPrefKey = "highScoreShooting";
    const string highScorePlantsPrefKey = "highScorePlants";

    public int racingGameHighScore = 500;
    public int jumpingGameHighScore = 500;
    public int colourGameHighScore = 20;
    public int shootingGameHighScore = 500;
    public int plantsHighScore = 500;
    public string gamePlayed = "Racing Game";

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

        if (PlayerPrefs.HasKey(highScoreShootingPrefKey))
        {
            shootingGameHighScore = PlayerPrefs.GetInt(highScoreShootingPrefKey);
        }

        if (PlayerPrefs.HasKey(highScorePlantsPrefKey))
        {
            plantsHighScore = PlayerPrefs.GetInt(highScorePlantsPrefKey);
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

    public void setShootingHighScore(int score)
    {
        if(score > shootingGameHighScore)
        {
            shootingGameHighScore = score;
            PlayerPrefs.SetInt(highScoreShootingPrefKey, score);
        }
    }

    public void setPlantsHighScore(int score)
    {
        if (score > plantsHighScore)
        {
            plantsHighScore = score;
            PlayerPrefs.SetInt(highScorePlantsPrefKey, score);
        }
    }
}
