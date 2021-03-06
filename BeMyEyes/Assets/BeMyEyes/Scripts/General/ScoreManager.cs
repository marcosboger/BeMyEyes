﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;

    public bool dead = false;
    private float timer;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 0.2f && !dead)
        {

            score += 5;

            //We only need to update the text if the score changed.
            ScoreText.text = "Score: " + score;
            //Reset the timer to 0.
            timer = 0;

        }
    }

    public void gameOver()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("Score", RpcTarget.AllViaServer, score);
        }
        dead = true;
    }

    [PunRPC]
    public void Score(int scoreReceived)
    {
        if(scoreReceived > score)
        {
            score = scoreReceived;
            ScoreText.text = "Score: " + score;
        }

        if (GeneralManager.Instance.gamePlayed == "Racing Game")
            GeneralManager.Instance.setRacingHighScore(score);

        if (GeneralManager.Instance.gamePlayed == "Jumping Game")
            GeneralManager.Instance.setJumpingHighScore(score);

        if (GeneralManager.Instance.gamePlayed == "Shooting Game")
            GeneralManager.Instance.setShootingHighScore(score);

        if(GeneralManager.Instance.gamePlayed == "Plants Vs Eyes")
            GeneralManager.Instance.setPlantsHighScore(score);
    }
}
