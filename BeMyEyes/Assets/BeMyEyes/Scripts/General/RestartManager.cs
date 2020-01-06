using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class RestartManager : MonoBehaviour
{
    private static GameObject _restartButton;
    private static GameObject _backToMenuButton;
    public static GameObject _gameOver;

    void Start()
    {
        _restartButton = GameObject.Find("Restart");
        _backToMenuButton = GameObject.Find("Back To Menu");
        _gameOver = GameObject.Find("Game Over");
        _gameOver.SetActive(false);
        _restartButton.SetActive(false);
        _backToMenuButton.SetActive(false);
    }

    public static void gameOver()
    {
        _restartButton.SetActive(true);
        _backToMenuButton.SetActive(true);
    }

    public void onClickRestart()
    {
        PhotonNetwork.LoadLevel(6);
    }

    public void onClickBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
