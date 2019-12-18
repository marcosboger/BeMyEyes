using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.ShootingGame
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy;

        private float _random;
        private float timer = 0;
        private float waitTime = -1;
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
                timer += multiplier * Time.deltaTime;
                if (timer >= waitTime)
                {
                    _random = Random.Range(0, 9);
                    if (multiplier <= 1.5f)
                        multiplier += 0.02f;
                    if (_random == 0)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn1", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 1)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn2", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 2)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn3", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 3)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn4", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 4)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn5", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 5)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn6", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 6)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn7", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 7)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn8", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    if (_random == 8)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn9", RpcTarget.AllViaServer, null);
                        waitTime = 1;
                    }
                    timer = 0;
                }
            }
        }

        [PunRPC]
        public void Spawn1()
        {
            Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn2()
        {
            Instantiate(enemy, new Vector3(-1, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn3()
        {
            Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn4()
        {
            Instantiate(enemy, new Vector3(1, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn5()
        {
            Instantiate(enemy, new Vector3(2, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn6()
        {
            Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn7()
        {
            Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn8()
        {
            Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
        }

        [PunRPC]
        public void Spawn9()
        {
            Instantiate(enemy, new Vector3(-2, 5, 0), Quaternion.identity);
        }
    }
}

