using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Private Methods


        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.Log("PhotonNetwork : Loading Level : RacingGame");
            PhotonNetwork.LoadLevel("RacingGame");
        }


        #endregion

        #region Photon Callbacks


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }



        #endregion

        #region Private Fields

        private bool _ownership = false;
        private GameObject[] obstacles;

        #endregion

        #region Private Serialized Fields

        [SerializeField]
        private PhotonView _player;

        [SerializeField]
        private GameObject input;

        [SerializeField]
        private GameObject spawnManager;

        #endregion

        #region MonoBehaviour Callbacks
        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach(GameObject o in obstacles)
                {
                    o.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if(SceneManager.GetActiveScene().name == "RacingGame" && _ownership == false)
            {
                _ownership = true;
                if (PhotonNetwork.IsMasterClient && PhotonNetwork.IsConnected)
                {
                    _player.RequestOwnership();
                    Debug.Log("Control Taken!");
                }
                else if(PhotonNetwork.IsConnected)
                {
                    input.SetActive(false);
                    spawnManager.SetActive(true);
                }
            }
        }
        #endregion

        #region Public Methods


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void BackToMenu()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(0);
        }


        #endregion
    }
}