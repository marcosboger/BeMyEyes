using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MenuManagerPrototype : MonoBehaviourPunCallbacks
{
    private GameObject _loadingScreen;
    private GameObject _background;
    private GameObject _createJoinRoom;
    private GameObject _playerGameSelection;
    private GameObject _cindyBeMyEyes;
    private GameObject _player2;
    private GameObject _racingGame;
    private GameObject _jumpingGame;
    private GameObject _colourGame;
    private GameObject _gameSelector;
    private GameObject _highScore;

    private Text _highScoreValue;
    private Button _startButton;

    private string _gameSelected;

    private string gameVersion = "1";
    // Start is called before the first frame update
    void Start()
    {
        _loadingScreen = GameObject.Find("Loading Screen");
        _background = GameObject.Find("BackGround");
        _createJoinRoom = GameObject.Find("Create/Join Room");
        _playerGameSelection = GameObject.Find("Player and Game Selection");
        _cindyBeMyEyes = GameObject.Find("cindybemyeyes");
        _player2 = GameObject.Find("Player2");
        _racingGame = GameObject.Find("RacingGame");
        _jumpingGame = GameObject.Find("JumpingGame");
        _colourGame = GameObject.Find("ColourGame");
        _gameSelector = GameObject.Find("Game Selector");
        _highScore = GameObject.Find("HighScore");


        _highScoreValue = GameObject.Find("HighScore Value").GetComponent<Text>();
        _startButton = GameObject.Find("Start").GetComponent<Button>();
        

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "eu";
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        _loadingScreen.SetActive(true);
        _background.SetActive(false);
        _createJoinRoom.SetActive(false);
        _playerGameSelection.SetActive(false);
        _player2.SetActive(false);
        _cindyBeMyEyes.SetActive(false);
        _racingGame.SetActive(false);
        _jumpingGame.SetActive(false);
        _colourGame.SetActive(false);
        _highScore.SetActive(false);
        _startButton.interactable = false;


        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                _loadingScreen.SetActive(false);
                _background.SetActive(true);
                _playerGameSelection.SetActive(true);
                _gameSelector.SetActive(true);
                _gameSelected = GeneralManager.Instance.gamePlayed;
                if (_gameSelected == "RacingGame")
                    _racingGame.SetActive(true);
                if (_gameSelected == "JumpingGame")
                    _jumpingGame.SetActive(true);
                if (_gameSelected == "ColourGame")
                    _colourGame.SetActive(true);
                _highScore.SetActive(true);
                if (_gameSelected == "RacingGame")
                    _highScoreValue.text = GeneralManager.Instance.racingGameHighScore.ToString();
                if (_gameSelected == "JumpingGame")
                    _highScoreValue.text = GeneralManager.Instance.jumpingGameHighScore.ToString();
                if (_gameSelected == "ColourGame")
                    _highScoreValue.text = GeneralManager.Instance.colourGameHighScore.ToString();
                if (PhotonNetwork.PlayerList.Length == 2)
                {
                    _player2.SetActive(true);
                    _cindyBeMyEyes.SetActive(true);
                    _startButton.interactable = true;
                }
            }
            else 
            {
                _loadingScreen.SetActive(false);
                _background.SetActive(true);
                _playerGameSelection.SetActive(true);
                _gameSelector.SetActive(false);
                if (PhotonNetwork.PlayerList.Length == 2)
                {
                    _player2.SetActive(true);
                    _cindyBeMyEyes.SetActive(true);
                    _startButton.interactable = true;
                }
            }
        }
    }

    public void handleClickCreateRoom()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.CreateRoom("Test");
        _createJoinRoom.SetActive(false);
        _playerGameSelection.SetActive(true);
        _gameSelector.SetActive(true);
        _racingGame.SetActive(true);
        _gameSelected = "RacingGame";
        _highScore.SetActive(true);
        _highScoreValue.text = GeneralManager.Instance.racingGameHighScore.ToString();
    }

    public void handleClickJoinRoom()
    {
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.JoinRoom("Test");
        _createJoinRoom.SetActive(false);
    }

    public void handleClickBackButton()
    {
        Debug.Log("Back Clicked!");
        AudioManager.Instance.playSelectionClip();
        PhotonNetwork.LeaveRoom();
        _playerGameSelection.SetActive(false);
        _gameSelector.SetActive(false);
        _createJoinRoom.SetActive(true);
    }

    public void handleClickLeftArrow()
    {
        AudioManager.Instance.playSelectionClip();
        if (_gameSelected == "RacingGame")
        {
            _racingGame.SetActive(false);
            _colourGame.SetActive(true);
            _gameSelected = "ColourGame";
            GeneralManager.Instance.gamePlayed = "ColourGame";
            _highScoreValue.text = GeneralManager.Instance.colourGameHighScore.ToString();
        }
        else if (_gameSelected == "JumpingGame")
        {
            _jumpingGame.SetActive(false);
            _racingGame.SetActive(true);
            _gameSelected = "RacingGame";
            GeneralManager.Instance.gamePlayed = "RacingGame";
            _highScoreValue.text = GeneralManager.Instance.racingGameHighScore.ToString();
        }
        else if (_gameSelected == "ColourGame")
        {
            _colourGame.SetActive(false);
            _jumpingGame.SetActive(true);
            _gameSelected = "JumpingGame";
            GeneralManager.Instance.gamePlayed = "JumpingGame";
            _highScoreValue.text = GeneralManager.Instance.jumpingGameHighScore.ToString();
        }
    }

    public void handleClickRightArrow()
    {
        AudioManager.Instance.playSelectionClip();
        if (_gameSelected == "RacingGame")
        {
            _racingGame.SetActive(false);
            _jumpingGame.SetActive(true);
            _gameSelected = "JumpingGame";
            GeneralManager.Instance.gamePlayed = "JumpingGame";
            _highScoreValue.text = GeneralManager.Instance.jumpingGameHighScore.ToString();
        }
        else if (_gameSelected == "JumpingGame")
        {
            _jumpingGame.SetActive(false);
            _colourGame.SetActive(true);
            _gameSelected = "ColourGame";
            GeneralManager.Instance.gamePlayed = "ColourGame";
            _highScoreValue.text = GeneralManager.Instance.colourGameHighScore.ToString();
        }
        else if (_gameSelected == "ColourGame")
        {
            _colourGame.SetActive(false);
            _racingGame.SetActive(true);
            _gameSelected = "RacingGame";
            GeneralManager.Instance.gamePlayed = "RacingGame";
            _highScoreValue.text = GeneralManager.Instance.racingGameHighScore.ToString();
        }
    }

    public void handleClickStart()
    {
        AudioManager.Instance.playSelectionClip();
        if (_gameSelected == "RacingGame")
        {
            PhotonNetwork.LoadLevel("RacingGame");
        }
        else if (_gameSelected == "JumpingGame")
        {
            PhotonNetwork.LoadLevel("JumpingGame");
        }
        else if (_gameSelected == "ColourGame")
        {
            PhotonNetwork.LoadLevel("ColorGame");
        }
    }

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            _createJoinRoom.SetActive(false);
            _playerGameSelection.SetActive(true);
            _gameSelector.SetActive(false);
            _player2.SetActive(true);
            _cindyBeMyEyes.SetActive(true);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        AudioManager.Instance.playErrorClip();
        _createJoinRoom.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _player2.SetActive(true);
            _cindyBeMyEyes.SetActive(true);
            _startButton.interactable = true;
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _player2.SetActive(false);
            _cindyBeMyEyes.SetActive(false);
            _startButton.interactable = false;
        }
    }

    public override void OnConnectedToMaster()
    {
        _loadingScreen.SetActive(false);
        _background.SetActive(true);
        _createJoinRoom.SetActive(true);
    }
}
