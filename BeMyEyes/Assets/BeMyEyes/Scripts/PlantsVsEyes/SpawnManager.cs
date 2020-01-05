using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject purpleEnemy, redEnemy, yellowEnemy;
        private GameObject enemy;
        float timer = 0f;
        float waitTime = 1f;
        float totalTimer = 0f;
        int _randomEnemy, _randomType;
        PhotonView photon;

        public void Start()
        {
            photon = PhotonView.Get(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                return;
            }
            totalTimer += Time.deltaTime;
            timer += Time.deltaTime;
            if(totalTimer <= 10f)
            {
                _randomEnemy = 0;
                _randomType = Random.Range(0, 4);
            }
            else if(totalTimer > 10f && totalTimer <= 20f)
            {
                _randomEnemy = Random.Range(0, 2);
                _randomType = Random.Range(0, 4);
            }
            else 
            {
                _randomEnemy = Random.Range(0, 3);
                _randomType = Random.Range(0, 4);
            }

            if(totalTimer >= 40)
            {
                waitTime = 0.8f;
            }

            if (totalTimer >= 50)
            {
                waitTime = 0.7f;
            }

            if (totalTimer >= 60)
            {
                waitTime = 0.6f;
            }

            if (totalTimer >= 70)
            {
                waitTime = 0.5f;
            }


            if (timer >= waitTime)
            {
                photon.RPC("Spawn", RpcTarget.AllViaServer, _randomEnemy, _randomType);
                timer = 0f;
            }
        }

        [PunRPC]
        public void Spawn(int randomEnemy, int randomType)
        {
            if (randomEnemy == 0)
            {
                enemy = purpleEnemy;
            }
            else if (randomEnemy == 1)
            {
                enemy = redEnemy;
            }
            else if (randomEnemy == 2)
            {
                enemy = yellowEnemy;
            }

            if (randomType == 0)
            {
                Instantiate(enemy, new Vector3(0.625f, 5.6f, -1), Quaternion.identity);
            }
            else if (randomType == 1)
            {
                Instantiate(enemy, new Vector3(1.875f, 5.6f, -1), Quaternion.identity);
            }
            else if (randomType == 2)
            {
                Instantiate(enemy, new Vector3(-0.625f, 5.6f, -1), Quaternion.identity);
            }
            else if (randomType == 3)
            {
                Instantiate(enemy, new Vector3(-1.875f, 5.6f, -1), Quaternion.identity);
            }
        }
    }
}
