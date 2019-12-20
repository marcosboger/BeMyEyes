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
    private GameObject _gameSelection;
    private GameObject _createRoom;
    private GameObject _joinRoom;
    private GameObject _player2;
    private GameObject _start;
    private GameObject _wait;

    private Button _startButton;
    private Button _leftArrow;
    private Button _rightArrow;
    private Button _playGameSelection;

    private Text _roomNameText;
    private Text _player1Name;
    private Text _player2Name;
    private Text _gameName;
    private Text _highScore;

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
        _insideRoom = GameObject.Find("Inside Room Menu");
        _gameSelection = GameObject.Find("Game Selection Menu");

        //Menu Childs  
        _createRoom = GameObject.Find("Create Room Name");
        _joinRoom = GameObject.Find("Join Room Name");
        _player2 = GameObject.Find("Player2");
        _start = GameObject.Find("Start");
        _wait = GameObject.Find("Wait");

        //Buttons, Inputs and Texts
        _startButton = GameObject.Find("Start").GetComponent<Button>();
        _roomName = GameObject.Find("Room Name").GetComponent<InputField>();
        _nickName = GameObject.Find("Name").GetComponent<InputField>();
        _roomNameText = GameObject.Find("Room Name Text").GetComponent<Text>();
        _player1Name = GameObject.Find("Player1 Name").GetComponent<Text>();
        _player2Name = GameObject.Find("Player2 Name").GetComponent<Text>();
        _gameName = GameObject.Find("Game Name").GetComponent<Text>();
        _gameName.text = "Racing Game";
        _leftArrow = GameObject.Find("Left Arrow").GetComponent<Button>();
        _rightArrow = GameObject.Find("Right Arrow").GetComponent<Button>();
        _playGameSelection = GameObject.Find("Play Game Selection").GetComponent<Button>();
        _highScore = GameObject.Find("High Score").GetComponent<Text>();


        //Deactivate everything unless the starting Screen
        _chooseNameMenu.SetActive(true);
        _menuBackground.SetActive(true);
        _loadingScreen.SetActive(false);
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _nameRoomMenu.SetActive(false);
        _roomMenu.SetActive(false);
        _insideRoom.SetActive(false);
        _gameSelection.SetActive(false);
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
            _wait.SetActive(false);
            _chooseNameMenu.SetActive(false);
            _menuBackground.SetActive(true);
            _gameSelection.SetActive(true);
            _roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            _player1Name.text = PhotonNetwork.PlayerList[0].NickName;
            _player2Name.text = PhotonNetwork.PlayerList[1].NickName;
            _startButton.interactable = true;
            if (!PhotonNetwork.IsMasterClient)
            {
                _wait.SetActive(true);
                _start.SetActive(false);
                _leftArrow.interactable = false;
                _rightArrow.interactable = false;
                _playGameSelection.interactable = false;
            }
            _gameName.text = GeneralManager.Instance.gamePlayed;
            if (GeneralManager.Instance.gamePlayed == "Racing Game")
                _highScore.text = GeneralManager.Instance.racingGameHighScore.ToString();
            if (GeneralManager.Instance.gamePlayed == "Jumping Game")
                _highScore.text = GeneralManager.Instance.jumpingGameHighScore.ToString();
            if (GeneralManager.Instance.gamePlayed == "Colour Game")
                _highScore.text = GeneralManager.Instance.colourGameHighScore.ToString();
            if (GeneralManager.Instance.gamePlayed == "Shooting Game")
                _highScore.text = GeneralManager.Instance.shootingGameHighScore.ToString();
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

    //Options Menu

    public void handleClickBackOptionsMenu()
    {
        AudioManager.Instance.playSelectionClip();
        _optionsMenu.SetActive(false);
        _mainMenu.SetActive(true);
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

    public void handleClickBackRoomMenu()
    {
        AudioManager.Instance.playSelectionClip();
        _roomMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    //Name Room Menu
    public void handleClickCreateRoomName()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.CreateRoom(_roomName.text.ToLower());
        _nameRoomMenu.SetActive(false);
        _createRoom.SetActive(false);
    }
    public void handleClickJoinRoomName()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.JoinRoom(_roomName.text.ToLower());
        _nameRoomMenu.SetActive(false);
        _joinRoom.SetActive(false);
    }

    public void handleClickBackNameRoomMenu()
    {
        AudioManager.Instance.playSelectionClip();
        _createRoom.SetActive(false);
        _joinRoom.SetActive(false);
        _nameRoomMenu.SetActive(false);
        _roomMenu.SetActive(true);
    }

    //Inside Room Menu
    public void handleClickStart()
    {
        AudioManager.Instance.playSelectionClip();
        _insideRoom.SetActive(false);
        _gameSelection.SetActive(true);
        _highScore.text = GeneralManager.Instance.racingGameHighScore.ToString();
        _wait.SetActive(false);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("gameSelect", RpcTarget.Others, null);
    }

    public void handleClickBackInsideRoomMenu()
    {
        PhotonNetwork.LeaveRoom();
        _insideRoom.SetActive(false);
        _player2.SetActive(false);
        _player2Name.text = "";
    }


    //Game Selection Menu
    public void handleClickRightArrow()
    {
        if (_gameName.text == "Racing Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Jumping Game");
        }
        else if(_gameName.text == "Jumping Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Colour Game");
        }
        else if(_gameName.text == "Colour Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Shooting Game");
        }
        else if(_gameName.text == "Shooting Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Racing Game");
        }
    }

    public void handleClickLeftArrow()
    {
        if (_gameName.text == "Racing Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Shooting Game");
        }
        else if (_gameName.text == "Jumping Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Racing Game");
        }
        else if (_gameName.text == "Colour Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Jumping Game");
        }
        else if (_gameName.text == "Shooting Game")
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("setGame", RpcTarget.All, "Colour Game");
        }
    }

    public void handleClickPlayGameSelection()
    {
        if(GeneralManager.Instance.gamePlayed == "Racing Game")
        {
            PhotonNetwork.LoadLevel("RacingGame");
        }
        else if (GeneralManager.Instance.gamePlayed == "Jumping Game")
        {
            PhotonNetwork.LoadLevel("JumpingGame");
        }
        else if (GeneralManager.Instance.gamePlayed == "Colour Game")
        {
            PhotonNetwork.LoadLevel("ColorGame");
        }
        else if(GeneralManager.Instance.gamePlayed == "Shooting Game")
        {
            PhotonNetwork.LoadLevel("ShootingGame");
        }
    }

    public void handleClickBackGameSelectionMenu()
    {
        _gameSelection.SetActive(false);
        _insideRoom.SetActive(true);
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
        _joinRoom.SetActive(true);
        _insideRoom.SetActive(false);
    }

    public override void OnCreatedRoom()
    {
        _insideRoom.SetActive(true);
        _start.SetActive(true);
        _player1Name.text = PhotonNetwork.NickName;
        _roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        AudioManager.Instance.playErrorClip();
        _nameRoomMenu.SetActive(true);
        _createRoom.SetActive(true);
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

    public override void OnDisconnected(DisconnectCause cause)
    {
        _chooseNameMenu.SetActive(true);
        _chooseNameMenu.SetActive(true);
        _menuBackground.SetActive(true);
        _loadingScreen.SetActive(false);
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _nameRoomMenu.SetActive(false);
        _roomMenu.SetActive(false);
        _insideRoom.SetActive(false);
        _gameSelection.SetActive(false);
        _createRoom.SetActive(false);
        _joinRoom.SetActive(false);
        _player2.SetActive(false);
    }

    [PunRPC]
    public void setGame(string gameName)
    {
        _gameName.text = gameName;
        GeneralManager.Instance.gamePlayed = gameName;
        if(gameName == "Racing Game")
            _highScore.text = GeneralManager.Instance.racingGameHighScore.ToString();
        if(gameName == "Jumping Game")
            _highScore.text = GeneralManager.Instance.jumpingGameHighScore.ToString();
        if(gameName == "Colour Game")
            _highScore.text = GeneralManager.Instance.colourGameHighScore.ToString();
        if (gameName == "Shooting Game")
            _highScore.text = GeneralManager.Instance.shootingGameHighScore.ToString();
    }

    [PunRPC]
    public void gameSelect()
    {
        _insideRoom.SetActive(false);
        _wait.SetActive(true);
        _gameSelection.SetActive(true);
        _leftArrow.interactable = false;
        _rightArrow.interactable = false;
        _playGameSelection.interactable = false;
    }
}
