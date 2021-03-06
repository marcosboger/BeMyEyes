﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.BeMyEyes.JumpingGame
{
    public class Player : MonoBehaviour
    {
        public GameObject JumpingSpawnManager;
        public GameObject ScoreManager;
        ScoreManager scoreScript;
        private Touch touch;
        private Rigidbody2D rb;
        [SerializeField]
        private float jumpForce = 400f;
        [SerializeField]
        private float _rotSpeed = 5f;
        private bool _rotation = false;
        [SerializeField]
        private bool _grounded = true;

        private GameObject restart;

        private GameObject[] obstacles;
        private GameObject[] platforms;
        private bool _gameOver = false;
        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.SendRate = 10;
            PhotonNetwork.SerializationRate = 10;
            restart = GameObject.Find("Restart");
            rb = GetComponent<Rigidbody2D>();
            scoreScript = ScoreManager.GetComponent<ScoreManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x <= -1.72)
            {
                transform.position = new Vector3(-1.72f, transform.position.y, transform.position.z);
            }
            _grounded = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.1f);
            Debug.DrawRay(transform.position, Vector2.down, Color.green);
            if (_grounded)
            {
                rb.rotation = 0;
                _rotation = false;
            }
            else
            {
                _rotation = true;
            }

            if (_rotation)
            {
                transform.Rotate(0, 0, -1 * _rotSpeed * Time.deltaTime);
            }
            //Control by touching
            if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) && _grounded && (PhotonNetwork.IsMasterClient))
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("Jump", RpcTarget.AllViaServer, null);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platform" && PhotonNetwork.IsMasterClient)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                collision.gameObject.GetComponent<Platform>().see = true;
            }
            if (collision.gameObject.tag == "Obstacle" && PhotonNetwork.IsMasterClient)
            {
                gameObject.GetComponent<Player>().enabled = false;
                JumpingSpawnManager.SetActive(false);
                PhotonView photonView = PhotonView.Get(this);
                RestartManager.gameOver();
                photonView.RPC("GameOver", RpcTarget.All, gameObject.transform.position);
            }
        }

        [PunRPC]
        void Jump()
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }

        [PunRPC]
        void GameOver(Vector3 position)
        {
            if (!_gameOver)
            {
                RestartManager._gameOver.SetActive(true);
                scoreScript.gameOver();
                _gameOver = true;
                gameObject.GetComponent<Player>().enabled = false;
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                platforms = GameObject.FindGameObjectsWithTag("Platform");
                if (!PhotonNetwork.IsMasterClient)
                {
                    GameObject.Find("JumpingSpawnManager").GetComponent<SpawnManager>().gameOver();
                    gameObject.transform.position = position;
                }
                foreach (GameObject o in obstacles)
                {
                    o.GetComponent<Platform>().speed = 0;
                    o.GetComponent<Platform>().see = true;
                }
                foreach (GameObject p in platforms)
                {
                    p.GetComponent<Platform>().speed = 0;
                    p.GetComponent<Platform>().see = true;
                }
                if (PhotonNetwork.IsMasterClient)
                {
                    restart.SetActive(true);
                }
            }
        }
    }
}
