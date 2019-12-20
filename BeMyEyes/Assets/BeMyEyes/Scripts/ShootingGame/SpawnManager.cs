using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.ShootingGame
{
    public class SpawnManager : MonoBehaviour
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
                    if (allTimer <= 30f)
                    {
                        _random = Random.Range(0, 5);
                        _randomEnemy = Random.Range(0, 1);
                    }
                    else if (allTimer > 30f && allTimer < 60f)
                    {
                        _random = Random.Range(0, 5);
                        _randomEnemy = Random.Range(0, 2);
                    }
                    else if (allTimer > 60f && allTimer < 90f)
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
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn0", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 1)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn1", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 2)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn2", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 3)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn3", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 4)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn4", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 5)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn5", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 6)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn6", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 7)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn7", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    if (_random == 8)
                    {
                        PhotonView photon;
                        photon = PhotonView.Get(this);
                        photon.RPC("spawn8", RpcTarget.AllViaServer, _randomEnemy);
                    }
                    timer = 0;
                }
            }
        }

        [PunRPC]
        public void spawn0(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
            }
            else if (enemy == 1)
            {
                Instantiate(pinkEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
            }
            else if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
            }
        }
        [PunRPC]
        public void spawn1(int enemy)
        {
            if (enemy == 0)
                Instantiate(blueEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
            else if (enemy == 1)
                Instantiate(pinkEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
            else if (enemy == 2)
                Instantiate(greenEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
        }
        [PunRPC]
        public void spawn2(int enemy)
        {
            if (enemy == 0)
                Instantiate(blueEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            else if (enemy == 1)
                Instantiate(pinkEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            else if (enemy == 2)
                Instantiate(greenEnemy, new Vector3(0, 5, 0), Quaternion.identity);
        }
        [PunRPC]
        public void spawn3(int enemy)
        {
            if (enemy == 0)
                Instantiate(blueEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            else if (enemy == 1)
                Instantiate(pinkEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            else if (enemy == 2)
                Instantiate(greenEnemy, new Vector3(1, 5, 0), Quaternion.identity);
        }
        [PunRPC]
        public void spawn4(int enemy)
        {
            if (enemy == 0)
                Instantiate(blueEnemy, new Vector3(2, 5, 0), Quaternion.identity);
            else if (enemy == 1)
                Instantiate(pinkEnemy, new Vector3(2, 5, 0), Quaternion.identity);
            else if (enemy == 2)
                Instantiate(greenEnemy, new Vector3(2, 5, 0), Quaternion.identity);
        }
        [PunRPC]
        public void spawn5(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(2, 5, 0), Quaternion.identity);
            }
            if (enemy == 1)
            {

                Instantiate(pinkEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(2, 5, 0), Quaternion.identity);
            }
            if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(2, 5, 0), Quaternion.identity);
            }

        }
        [PunRPC]
        public void spawn6(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
            if (enemy == 1)
            {

                Instantiate(pinkEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
            if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(0, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
        }
        [PunRPC]
        public void spawn7(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
            if (enemy == 1)
            {

                Instantiate(pinkEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
            if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(1, 5, 0), Quaternion.identity);
            }
        }

        [PunRPC]
        public void spawn8(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
            if (enemy == 1)
            {
                Instantiate(pinkEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
            if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(-2, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(-1, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
        }

        [PunRPC]
        public void spawn9(int enemy)
        {
            if (enemy == 0)
            {
                Instantiate(blueEnemy, new Vector3(+2, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(+1, 5, 0), Quaternion.identity);
                Instantiate(blueEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
            if (enemy == 1)
            {
                Instantiate(pinkEnemy, new Vector3(+2, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(+1, 5, 0), Quaternion.identity);
                Instantiate(pinkEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
            if (enemy == 2)
            {
                Instantiate(greenEnemy, new Vector3(+2, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(+1, 5, 0), Quaternion.identity);
                Instantiate(greenEnemy, new Vector3(0, 5, 0), Quaternion.identity);
            }
        }
    }
}

