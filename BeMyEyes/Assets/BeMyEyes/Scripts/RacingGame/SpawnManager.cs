using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace Com.BeMyEyes.RacingGame
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject obstacle;
        private float _x;
        private float timer = 0;
        private float waitTime = 1.75f;
        private bool _gameOver = false;
        private float multiplier = 1f;
        private void Start()
        {
        }

        void Update()
        {
            if (_gameOver)
            {
                return;
            }
            else
            {
                timer += multiplier * Time.deltaTime;
                if (timer >= waitTime)
                {
                    if (multiplier <= 1.26)
                        multiplier += 0.02f;
                    _x = Random.Range(0, 8);
                    if (_x == 0)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 1)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 2)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 3)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 4)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 5)
                    {
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
                        PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
                        waitTime = 1.75f;
                    }
                    else if (_x == 6)
                    {
                        PhotonNetwork.Instantiate("ObstacleRacing1", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 4.0f * multiplier;
                    }
                    else if (_x == 7)
                    {
                        PhotonNetwork.Instantiate("ObstacleRacing2", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 4.0f * multiplier;
                    }
                    timer = 0;
                }
            }
        }

        public void gameOver()
        {
            _gameOver = true;
        }
    }
}
