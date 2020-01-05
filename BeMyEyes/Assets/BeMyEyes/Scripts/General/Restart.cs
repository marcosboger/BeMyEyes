using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Start()
    {
        if (GeneralManager.Instance.gamePlayed == "Racing Game")
            SceneManager.LoadScene(1);
        if (GeneralManager.Instance.gamePlayed == "Jumping Game")
            SceneManager.LoadScene(2);
        if (GeneralManager.Instance.gamePlayed == "Colour Game")
            SceneManager.LoadScene(3);
        if (GeneralManager.Instance.gamePlayed == "Shooting Game")
            SceneManager.LoadScene(4);
        if (GeneralManager.Instance.gamePlayed == "Plants Vs Eyes")
            SceneManager.LoadScene(5);
    }
}
