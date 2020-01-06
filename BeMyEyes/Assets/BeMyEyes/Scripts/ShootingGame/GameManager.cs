using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


namespace Com.BeMyEyes.ShootingGame
{
    public class GameManager : MonoBehaviour
    {
        private GameObject player;
        private GameObject spawnManager;
        private ScoreManager scoreManager;
        private GameObject[] blue, pink;

        public float totalTimer = 0f;

        private int viewID = 1000;

        private bool _gameOver;

        private PhotonView playerPhoton;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            playerPhoton = player.GetComponent<PhotonView>();
            spawnManager = GameObject.Find("Spawn Manager");
            scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

            if (SceneManager.GetActiveScene().name == "ShootingGame")
            {
                if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
                {
                    playerPhoton.RequestOwnership();
                }
            }
        }

        private void Update()
        {
            totalTimer += Time.deltaTime;
            if (PhotonNetwork.IsMasterClient)
            {
                blue = GameObject.FindGameObjectsWithTag("Blue");
                pink = GameObject.FindGameObjectsWithTag("Pink");
                foreach (GameObject b in blue)
                {
                    if (b.GetComponent<Enemy>() != null && !_gameOver)
                        b.GetComponent<SpriteRenderer>().enabled = false;
                }
                foreach (GameObject p in pink)
                {
                    if (p.GetComponent<Enemy>() != null && !_gameOver)
                        p.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }

        public void gameOver()
        {
            _gameOver = true;
            PhotonView photon;
            photon = PhotonView.Get(this);
            photon.RPC("GameOver", RpcTarget.AllViaServer, null);
        }

        public void handleRestart()
        {
            SceneManager.LoadScene(0);
        }

        [PunRPC]
        public void GameOver()
        {
            player.GetComponent<Player>().enabled = false;
            spawnManager.SetActive(false);
            scoreManager.gameOver();
            blue = GameObject.FindGameObjectsWithTag("Blue");
            pink = GameObject.FindGameObjectsWithTag("Pink");
            foreach (GameObject b in blue)
            {
                b.GetComponent<SpriteRenderer>().enabled = true;
                b.GetComponent<Enemy>().enabled = false;
            }
            foreach (GameObject p in pink)
            {
                p.GetComponent<SpriteRenderer>().enabled = true;
                p.GetComponent<Enemy>().enabled = false;
            }
        }

        public int setViewID()
        {
            viewID--;
            return viewID;
        }
    }
}
