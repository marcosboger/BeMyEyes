using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    private GameObject _menuBackground;
    private GameObject _mainMenu;
    private GameObject _roomMenu;
    private GameObject _insideRoom;
    private GameObject _player2;
    private GameObject _start;
    private GameObject _loadingScreen;
    private Button _startButton;

    string gameVersion = "1";

    private void Awake()
    {

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "eu";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _menuBackground = GameObject.Find("Menu Background");
        _mainMenu = GameObject.Find("Main Menu");
        _roomMenu = GameObject.Find("Room Menu");
        _insideRoom = GameObject.Find("Inside Room");
        _player2 = GameObject.Find("Player2");
        _start = GameObject.Find("Start");
        _loadingScreen = GameObject.Find("Loading Screen");
        _startButton = GameObject.Find("Start").GetComponent<Button>();
        _loadingScreen.SetActive(true);
        _menuBackground.SetActive(false);
        _mainMenu.SetActive(false);
        _roomMenu.SetActive(false);
        _insideRoom.SetActive(false);
        _player2.SetActive(false);
    }

    public void handleClickPlay()
    {
        _mainMenu.SetActive(false);
        _roomMenu.SetActive(true);
    }

    public void handleClickCreateRoom()
    {
        _roomMenu.SetActive(false);
        _insideRoom.SetActive(true);
        PhotonNetwork.CreateRoom("Test");
    }

    public void handleClickJoinRoom()
    {
        _roomMenu.SetActive(false);
        PhotonNetwork.JoinRoom("Test");
    }

    public void handleClickStart()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("RacingGame");
        }
    }

    public void handleClickExit()
    {
        Application.Quit();
    }

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            _insideRoom.SetActive(true);
            _player2.SetActive(true);
            _start.SetActive(false);
        }
        Debug.Log("Joined Test Room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join Room Failed");
        _roomMenu.SetActive(true);
        _insideRoom.SetActive(false);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Test Room");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player entered the room!");
        _player2.SetActive(true);
        _startButton.interactable = true;
    }

    public override void OnConnectedToMaster()
    {
        _menuBackground.SetActive(true);
        _loadingScreen.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
