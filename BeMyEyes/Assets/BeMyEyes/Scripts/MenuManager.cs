using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    const string playerNamePrefKey = "PlayerName";

    private GameObject _loadingScreen;
    private GameObject _chooseNameMenu;
    private GameObject _menuBackground;
    private GameObject _mainMenu;
    private GameObject _optionsMenu;
    private GameObject _nameRoomMenu;
    private GameObject _roomMenu;
    private GameObject _insideRoom;
    private GameObject _createRoom;
    private GameObject _joinRoom;
    private GameObject _player2;
    private GameObject _start;

    private Button _startButton;

    private Text _roomNameText;
    private Text _player1Name;
    private Text _player2Name;

    private InputField _roomName;
    private InputField _nickName;

    string gameVersion = "1";

    // Start is called before the first frame update
    void Start()
    {
        //Finding important objects

        //Menu Parents
        _loadingScreen = GameObject.Find("Loading Screen");
        _chooseNameMenu = GameObject.Find("Choose Name Menu");
        _menuBackground = GameObject.Find("Menu Background");
        _mainMenu = GameObject.Find("Main Menu");
        _optionsMenu = GameObject.Find("Options Menu");
        _nameRoomMenu = GameObject.Find("Name Room Menu");
        _roomMenu = GameObject.Find("Room Menu");
        _insideRoom = GameObject.Find("Inside Room");

        //Menu Childs  
        _createRoom = GameObject.Find("Create Room Name");
        _joinRoom = GameObject.Find("Join Room Name");
        _player2 = GameObject.Find("Player2");
        _start = GameObject.Find("Start");

        //Buttons, Inputs and Texts
        _startButton = GameObject.Find("Start").GetComponent<Button>();
        _roomName = GameObject.Find("Room Name").GetComponent<InputField>();
        _nickName = GameObject.Find("Name").GetComponent<InputField>();
        _roomNameText = GameObject.Find("Room Name Text").GetComponent<Text>();
        _player1Name = GameObject.Find("Player1 Name").GetComponent<Text>();
        _player2Name = GameObject.Find("Player2 Name").GetComponent<Text>();
       

        //Deactivate everything unless the starting Screen
        _chooseNameMenu.SetActive(true);
        _menuBackground.SetActive(true);
        _loadingScreen.SetActive(false);
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _nameRoomMenu.SetActive(false);
        _roomMenu.SetActive(false);
        _insideRoom.SetActive(false);
        _createRoom.SetActive(false);
        _joinRoom.SetActive(false);
        _player2.SetActive(false);

        //Setting the player's nickname to his last nickname as suggestion
        if (PlayerPrefs.HasKey(playerNamePrefKey))
        {
            _nickName.text = PlayerPrefs.GetString(playerNamePrefKey);
        }

        if (PhotonNetwork.InRoom)
        {
            _chooseNameMenu.SetActive(false);
            _menuBackground.SetActive(true);
            _insideRoom.SetActive(true);
            _player2.SetActive(true);
            _roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            _player1Name.text = PhotonNetwork.PlayerList[0].NickName;
            _player2Name.text = PhotonNetwork.PlayerList[1].NickName;
            _startButton.interactable = true;
            if (!PhotonNetwork.IsMasterClient)
            {
                _start.SetActive(false);
            }
        }
    }

    //Choose Name Menu
    public void handleClickGo()
    {
        AudioManager.Instance.playSelectionClip();
        string nick = _nickName.text.ToLower(); 
        PhotonNetwork.NickName = nick;
        PhotonNetwork.AuthValues = new AuthenticationValues(nick);
        PlayerPrefs.SetString(playerNamePrefKey, nick);
        _chooseNameMenu.SetActive(false);
        _menuBackground.SetActive(false);
        _loadingScreen.SetActive(true);

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "eu";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //Main Menu
    public void handleClickPlay()
    {
        AudioManager.Instance.playSelectionClip();
        _mainMenu.SetActive(false);
        _roomMenu.SetActive(true);
    }
    public void handleClickHowToPlay()
    {
        AudioManager.Instance.playSelectionClip();
    }

    public void handleClickOptions()
    {
        AudioManager.Instance.playSelectionClip();
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void handleClickExit()
    {
        AudioManager.Instance.playSelectionClip();
        Application.Quit();
    }

    //Room Menu
    public void handleClickCreateRoom()
    {
        AudioManager.Instance.playSelectionClip();
        _roomMenu.SetActive(false);
        _nameRoomMenu.SetActive(true);
        _createRoom.SetActive(true);
    }

    public void handleClickJoinRoom()
    {
        AudioManager.Instance.playSelectionClip();
        _roomMenu.SetActive(false);
        _nameRoomMenu.SetActive(true);
        _joinRoom.SetActive(true);
    }

    //Name Room Menu
    public void handleClickCreateRoomName()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.CreateRoom(_roomName.text.ToLower());
        _nameRoomMenu.SetActive(false);
    }
    public void handleClickJoinRoomName()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.JoinRoom(_roomName.text.ToLower());
        _nameRoomMenu.SetActive(false);
    }

    //Inside Room Menu
    public void handleClickStart()
    {
        AudioManager.Instance.playSelectionClip();
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("RacingGame");
        }
    }

    //Pun Callbacks

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            _insideRoom.SetActive(true);
            _player2.SetActive(true);
            _roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            _player1Name.text = PhotonNetwork.PlayerList[0].NickName;
            _player2Name.text = PhotonNetwork.PlayerList[1].NickName;
            _start.SetActive(false);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        AudioManager.Instance.playErrorClip();
        _nameRoomMenu.SetActive(true);
        _insideRoom.SetActive(false);
    }

    public override void OnCreatedRoom()
    {
        _insideRoom.SetActive(true);
        _player1Name.text = PhotonNetwork.NickName;
        _roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        AudioManager.Instance.playErrorClip();
        _nameRoomMenu.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        _player2.SetActive(true);
        _player2Name.text = PhotonNetwork.PlayerList[1].NickName;
        _startButton.interactable = true;
    }

    public override void OnConnectedToMaster()
    {
        _loadingScreen.SetActive(false);
        _menuBackground.SetActive(true);
        _mainMenu.SetActive(true);
    }
}
