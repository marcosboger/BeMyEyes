using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject restart;
        public void GameOver()
        {
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().enabled = false;
            GameObject.Find("Button Manager").GetComponent<ButtonManager>().enabled = false;
            restart.SetActive(true);
        }

        public void onClickRestart()
        {
            SceneManager.LoadScene(0);
        }
    }
}


