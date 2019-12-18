using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private GameObject spawnManager;
    private GameObject restartButton;
    private ScoreManager scoreManager;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager");
        restartButton = GameObject.Find("Restart");
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

        restartButton.SetActive(false);
    }

    public void gameOver()
    {
        player.SetActive(false);
        spawnManager.SetActive(false);
        restartButton.SetActive(true);
        scoreManager.dead = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            e.GetComponent<Enemy>().enabled = false;
        }
    }

    public void handleRestart()
    {
        SceneManager.LoadScene(0);
    }
}
