﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text ScoreText;

    public bool dead = false;
    private float timer;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
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
}