﻿using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace Com.BeMyEyes.RacingGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        private bool _ownership = false;
        private GameObject[] obstacles;
        private PhotonView _player;
        private GameObject spawnManager;

        private void Awake()
        {
            _player = GameObject.Find("Player").GetComponent<PhotonView>();
            spawnManager = GameObject.Find("Spawn Manager");
            if (SceneManager.GetActiveScene().name == "RacingGame" && _ownership == false)
            {
                if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
                {
                    _player.RequestOwnership();
                    Debug.Log("Control Taken!");
                    spawnManager.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach(GameObject o in obstacles)
                {
                    if(o.transform.position.y < -3.0 || o.GetComponent<Obstacle>().see)
                    {
                        o.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        o.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
        
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }


        
    }
}