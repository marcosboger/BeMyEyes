using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager>
{
    public int racingGameHighScore = 500;
    public int jumpingGameHighScore = 500;
    public int colourGameHighScore = 20;
    public string gamePlayed = "RacingGame";

    public void setRacingHighScore(int score)
    {
        Debug.Log("Called Racing High Score");
        if (score > racingGameHighScore)
        {
            Debug.Log("Changed Racing High Score");
            racingGameHighScore = score;
        }
    }

    public void setJumpingHighScore(int score)
    {
        if (score > jumpingGameHighScore)
            jumpingGameHighScore = score;
    }

    public void setColourHighScore(int score)
    {
        if (score > colourGameHighScore)
            colourGameHighScore = score;
    }
}
