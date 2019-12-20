using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private GameObject spawnManager;
    private GameObject restartButton;
    private ScoreManager scoreManager;
    private GameObject[] green, blue, pink;

    private PhotonView playerPhoton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPhoton = player.GetComponent<PhotonView>();
        spawnManager = GameObject.Find("Spawn Manager");
        restartButton = GameObject.Find("Restart");
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

        restartButton.SetActive(false);

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
        if (PhotonNetwork.IsMasterClient)
        {
            blue = GameObject.FindGameObjectsWithTag("Blue");
            green = GameObject.FindGameObjectsWithTag("Green");
            pink = GameObject.FindGameObjectsWithTag("Pink");
            foreach (GameObject b in blue)
            {
                if(b.GetComponent<Enemy>() != null) 
                   b.GetComponent<SpriteRenderer>().enabled = false;
            }
            foreach (GameObject g in green)
            {
                if (g.GetComponent<Enemy>() != null) 
                   g.GetComponent<SpriteRenderer>().enabled = false;
            }
            foreach (GameObject p in pink)
            {
                if (p.GetComponent<Enemy>() != null) 
                   p.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void gameOver()
    {
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
        player.SetActive(false);
        spawnManager.SetActive(false);
        if(PhotonNetwork.IsMasterClient)
            restartButton.SetActive(true);
        scoreManager.gameOver();
    }
}
