﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace Com.BeMyEyes.JumpingGame
{
    public class GameManager : MonoBehaviour
    {
        private bool _ownership = false;
        private GameObject[] obstacles;
        private GameObject[] platforms;
        private PhotonView _player;
        private GameObject spawnManager;

        private void Awake()
        {
            _player = GameObject.Find("Player").GetComponent<PhotonView>();
            spawnManager = GameObject.Find("JumpingSpawnManager");
            if (SceneManager.GetActiveScene().name == "JumpingGame" && _ownership == false)
            {
                if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
                {
                    _player.RequestOwnership();
                    Debug.Log("Control Taken!");
                    //spawnManager.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                platforms = GameObject.FindGameObjectsWithTag("Platform");
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject o in obstacles)
                {
                    if (o.transform.position.x <= -1.5 || o.GetComponent<Platform>().see)
                    {
                        o.GetComponent<Platform>().see = true;
                        o.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (!o.GetComponent<Platform>().see)
                    {
                        o.GetComponent<SpriteRenderer>().enabled = false;
                    }

                }
                foreach (GameObject p in platforms)
                {
                    if (p.transform.position.x <= -1.5 || p.GetComponent<Platform>().see)
                    {
                        p.GetComponent<Platform>().see = true;
                        p.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (!p.GetComponent<Platform>().see)
                    {
                        p.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
