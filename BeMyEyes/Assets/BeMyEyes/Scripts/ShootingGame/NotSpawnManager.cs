using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.ShootingGame
{
    public class NotSpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject blueEnemy;
        [SerializeField]
        private GameObject greenEnemy;
        [SerializeField]
        private GameObject pinkEnemy;

        private GameObject enemy;

        private int _random;
        private int _randomEnemy;
        private float timer = 0;
        private float allTimer = 0;
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
                allTimer += Time.deltaTime;
                if (timer >= waitTime)
                {
                    if(allTimer <= 15f)
                    {
                        _random = Random.Range(0, 5);
                        _randomEnemy = Random.Range(0, 1);
                    }
                    else if(allTimer > 15.0f && allTimer < 30.0f)
                    {
                        _random = Random.Range(0, 5);
                         _randomEnemy = Random.Range(0, 2);
                    }
                    else if(allTimer > 30f && allTimer < 45f)
                    {
                        _random = Random.Range(0, 8);
                        _randomEnemy = Random.Range(0, 2);
                    }
                    else
                    {
                        _random = Random.Range(0, 9);
                        _randomEnemy = Random.Range(0, 2);
                    }
                    if (_random == 0)
                    {
                        if(_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if(_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if(_randomEnemy == 2)
                            enemy = greenEnemy;
                        
                        Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 1)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 2)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                    }
                    if (_random == 3)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 4)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 5)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
                    }
                    if (_random == 6)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 7)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

                        Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
                    }
                    if (_random == 8)
                    {
                        if (_randomEnemy == 0)
                            enemy = blueEnemy;
                        else if (_randomEnemy == 1)
                            enemy = pinkEnemy;
                        else if (_randomEnemy == 2)
                            enemy = greenEnemy;

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

