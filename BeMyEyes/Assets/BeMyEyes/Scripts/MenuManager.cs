using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    private GameObject _mainMenuButtons;
    private GameObject _roomMenuButtons;
    private GameObject _insideRoomButtons;

    string gameVersion = "1";

    private void Awake()
    {

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuButtons = GameObject.Find("Main Menu Buttons");
        _roomMenuButtons = GameObject.Find("Room Menu Buttons");
        _insideRoomButtons = GameObject.Find("Inside Room Buttons");
        _mainMenuButtons.SetActive(false);
        _roomMenuButtons.SetActive(false);
        _insideRoomButtons.SetActive(false);
        //Connecting Text SetActive(true);
    }

    public void handleClickPlay()
    {
        _mainMenuButtons.SetActive(false);
        _roomMenuButtons.SetActive(true);
    }

    public void handleClickCreateRoom()
    {
        _roomMenuButtons.SetActive(false);
        _insideRoomButtons.SetActive(true);
        PhotonNetwork.CreateRoom("Test");
    }

    public void handleClickJoinRoom()
    {
        _roomMenuButtons.SetActive(false);
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
        Debug.Log("Joined Test Room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join Room Failed");
        _roomMenuButtons.SetActive(true);
        _insideRoomButtons.SetActive(false);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Test Room");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player entered the room!");
    }

    public override void OnConnectedToMaster()
    {
        //Connecting Text SetActive(false);
        _mainMenuButtons.SetActive(true);
    }
}
