using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class GameManager : MonoBehaviour
    {
        private GameObject[] purple, red, yellow;
        [SerializeField]
        private GameObject buttons;
        [SerializeField]
        private GameObject spawnManager;
        private bool _gameOver = false;
        public void Start()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                buttons.SetActive(false);
            }
        }
        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                purple = GameObject.FindGameObjectsWithTag("Purple");
                red = GameObject.FindGameObjectsWithTag("Red");
                yellow = GameObject.FindGameObjectsWithTag("Yellow");
                foreach (GameObject p in purple)
                {
                    if (!_gameOver && p.GetComponent<Enemy>() != null)
                        p.GetComponent<SpriteRenderer>().enabled = false;
                }
                foreach (GameObject r in red)
                {
                    if(!_gameOver && r.GetComponent<Enemy>() != null)
                        r.GetComponent<SpriteRenderer>().enabled = false;
                }
                foreach (GameObject y in yellow)
                {
                    if(!_gameOver && y.GetComponent<Enemy>() != null)
                        y.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }

        public void gameOver()
        {
            PhotonView photon;
            photon = PhotonView.Get(this);
            photon.RPC("GameOver", RpcTarget.AllViaServer, null);
        }

        [PunRPC]
        public void GameOver()
        {
            RestartManager._gameOver.SetActive(true);
            _gameOver = true;
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().enabled = false;
            GameObject.Find("Button Manager").GetComponent<ButtonManager>().enabled = false;
            if(PhotonNetwork.IsMasterClient)
                RestartManager.gameOver();
            GameObject.Find("Score Manager").GetComponent<ScoreManager>().gameOver();
            purple = GameObject.FindGameObjectsWithTag("Purple");
            red = GameObject.FindGameObjectsWithTag("Red");
            yellow = GameObject.FindGameObjectsWithTag("Yellow");
            foreach (GameObject p in purple)
            {
                p.GetComponent<Enemy>().enabled = false;
                p.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (GameObject r in red)
            {
                r.GetComponent<Enemy>().enabled = false;
                r.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (GameObject y in yellow)
            {
                y.GetComponent<Enemy>().enabled = false;
                y.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

    }
}


