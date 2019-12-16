using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.JumpingGame
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject obstacleJumping;
        public GameObject platform;
        public GameObject obstacleJumping1;
        public GameObject obstacleJumping2;
        public GameObject obstacleJumping3;
        public GameObject obstacleJumping4;

        private float _random;
        private float timer = 0;
        private float waitTime = -1;
        private bool _gameOver = false;
        private float multiplier = 1f;

        // Start is called before the first frame update
        void Start()
        {
            //InvokeRepeating("Spawn", 0, spawnTime);
        }

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
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
                        waitTime = 2;
                    }
                    if (_random == 1)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn2", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
                        waitTime = 2;
                    }
                    if (_random == 2)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn3", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(4.05f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(5.52f, -2.01f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(6.01f, -2.01f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(6.50f, -2.01f, 0), Quaternion.identity);

                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
                        waitTime = 3.4f;
                    }
                    if (_random == 3)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn4", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(4.05f, -2.75f, 0), Quaternion.identity);

                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
                        waitTime = 3f;
                    }
                    if (_random == 4)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn5", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(4.05f, -2.75f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(5.52f, -2.01f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(6.01f, -2.01f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(6.50f, -2.01f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(8.46f, -1.27f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(8.95f, -1.27f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(9.44f, -1.27f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(11.89f, -1.27f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(12.38f, -1.27f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("Platform", new Vector3(12.87f, -1.27f, 0), Quaternion.identity);

                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(7.48f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(7.97f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(8.46f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(8.95f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(9.44f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(9.93f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(10.42f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(10.91f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(11.40f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(11.89f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(12.38f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(12.87f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(13.36f, -3.48f, 0), Quaternion.identity);
                        //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(13.85f, -3.48f, 0), Quaternion.identity);
                        waitTime = 6.4f * multiplier;
                    }
                    if (_random == 5)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn6", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("ObstacleJumping3", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 2.5f * multiplier + 1.5f;
                    }
                    if (_random == 6)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn7", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("ObstacleJumping2", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 2.5f * multiplier + 1.5f;
                    }
                    if (_random == 7)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn8", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("ObstacleJumping1", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 3f;
                    }
                    if (_random == 8)
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("Spawn9", RpcTarget.AllViaServer, null);
                        //PhotonNetwork.Instantiate("ObstacleJumping4", new Vector3(0, 0, 0), Quaternion.identity);
                        waitTime = 2.5f * multiplier + 1.5f;
                    }
                    timer = 0;
                }
            }
        }

        public void gameOver()
        {
            _gameOver = true;
        }

        [PunRPC]
        public void Spawn1()
        {
            Instantiate(obstacleJumping, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn2()
        {
            Instantiate(obstacleJumping, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn3()
        {
            Instantiate(platform, new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(4.05f, -2.75f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(5.52f, -2.01f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(6.01f, -2.01f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(6.50f, -2.01f, 0), Quaternion.identity);

            Instantiate(obstacleJumping, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn4()
        {
            Instantiate(platform, new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(4.05f, -2.75f, 0), Quaternion.identity);


            Instantiate(obstacleJumping, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn5()
        {
            Instantiate(platform, new Vector3(3.07f, -2.75f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(3.56f, -2.75f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(4.05f, -2.75f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(5.52f, -2.01f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(6.01f, -2.01f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(6.50f, -2.01f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(8.46f, -1.27f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(8.95f, -1.27f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(9.44f, -1.27f, 0),  Quaternion.identity);
            Instantiate(platform, new Vector3(11.89f, -1.27f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(12.38f, -1.27f, 0), Quaternion.identity);
            Instantiate(platform, new Vector3(12.87f, -1.27f, 0), Quaternion.identity);

            Instantiate(obstacleJumping, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(7.48f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(7.97f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(8.46f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(8.95f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(9.44f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(9.93f, -3.48f, 0), Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(10.42f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(10.91f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(11.40f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(11.89f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(12.38f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(12.87f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(13.36f, -3.48f, 0),Quaternion.identity);
            Instantiate(obstacleJumping, new Vector3(13.85f, -3.48f, 0), Quaternion.identity);

            //PhotonNetwork.Instantiate("Platform", new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(4.05f, -2.75f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(5.52f, -2.01f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(6.01f, -2.01f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(6.50f, -2.01f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(8.46f, -1.27f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(8.95f, -1.27f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(9.44f, -1.27f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(11.89f, -1.27f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(12.38f, -1.27f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("Platform", new Vector3(12.87f, -1.27f, 0), Quaternion.identity);

            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(7.48f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(7.97f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(8.46f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(8.95f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(9.44f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(9.93f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(10.42f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(10.91f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(11.40f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(11.89f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(12.38f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(12.87f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(13.36f, -3.48f, 0), Quaternion.identity);
            //PhotonNetwork.Instantiate("ObstacleJumping", new Vector3(13.85f, -3.48f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn6()
        {
            Instantiate(obstacleJumping1, new Vector3(0f, 0f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn7()
        {
            Instantiate(obstacleJumping2, new Vector3(0f, 0f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn8()
        {
            Instantiate(obstacleJumping3, new Vector3(0f, 0f, 0), Quaternion.identity);
        }
        [PunRPC]
        public void Spawn9()
        {
            Instantiate(obstacleJumping4, new Vector3(0f, 0f, 0), Quaternion.identity);
        }
    }
}
