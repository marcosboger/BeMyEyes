using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.ShootingGame
{
    public class NotSpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy;

        private float _random;
        private float timer = 0;
        [SerializeField]
        private float waitTime = 1f;
        private bool _gameOver = false;
        private float multiplier = 1f;

        // Update is called once per frame
        void Update()
        {
            if (_gameOver || PhotonNetwork.IsMasterClient)
            {
                return;
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= waitTime)
                {
                    _random = Random.Range(0, 9);
                    //if (multiplier <= 1.5f)
                    //    multiplier += 0.02f;
                    if (_random == 0)
                    {
                        Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 1)
                    {
                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 2)
                    {
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                    }
                    if (_random == 3)
                    {
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 4)
                    {
                        Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 5)
                    {
                        Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 6)
                    {
                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 7)
                    {
                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 8)
                    {
                        Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
                    }
                    timer = 0;
                }
            }
        }
    }
}

