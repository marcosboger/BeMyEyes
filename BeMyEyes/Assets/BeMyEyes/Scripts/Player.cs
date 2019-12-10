using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Player : MonoBehaviour
{
    private Touch touch;
    public GameObject ScoreManager;
    ScoreManager scoreScript;
    private Vector2 _touchPosition;
    public Joystick joystick;
    private GameObject _player;
    private Vector2 _playerPosition;
    private bool _xMatch, _yMatch;
    private float _horizontalMove;
    public float speed = 5.0f;
    public GameObject gameOver;
    public GameObject restart;
    private GameObject[] obstacles;
    private bool _gameOver = false;

    private void Start()
    {
        _player = GameObject.Find("Player");
        scoreScript = ScoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PhotonView>().IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        _playerPosition = _player.transform.position;
        //Control by touching
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            _xMatch = (_touchPosition.x <= _playerPosition.x + 0.45f && _touchPosition.x >= _playerPosition.x - 0.45f);
            _yMatch = (_touchPosition.y <= _playerPosition.y + 0.5f && _touchPosition.y >= _playerPosition.y - 0.95f);
            if (_xMatch && _yMatch)
            {
                if (_touchPosition.x > 4.41)
                {
                    _touchPosition.x = 4.41f;
                }
                else if (_touchPosition.x < 1.59)
                {
                    _touchPosition.x = 1.59f;
                }
                transform.position = new Vector3(_touchPosition.x, transform.position.y, transform.position.z);
            }
        }

        //Control by joystick
        //_horizontalMove = SimpleInput.GetAxis("Horizontal") * speed;
        //if (transform.position.x <= 1.41 && transform.position.x >= -1.41) 
        //{
            //transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        //}
        //else if(transform.position.x > 1.41 && _horizontalMove < 0)
        //{
            //transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        //}
        //else if(transform.position.x < -1.41 && _horizontalMove > 0)
        //{
            //transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && PhotonNetwork.IsMasterClient)
        {
            PhotonView photonView = PhotonView.Get(this);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            photonView.RPC("GameOver", RpcTarget.All, collision.gameObject.transform.position);
        }
    }

    [PunRPC]
    void GameOver(Vector3 position)
    {
        if (!_gameOver)
        {
            scoreScript.gameOver();
            _gameOver = true;
            gameObject.GetComponent<Player>().enabled = false;
            GameObject.Find("Highway").GetComponent<Highway>().enabled = false;
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            if (!PhotonNetwork.IsMasterClient)
            {
                GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().gameOver();
            }
            foreach (GameObject o in obstacles)
            {
                o.transform.position = position;
                o.GetComponent<Obstacle>().enabled = false;
            }
            gameOver.SetActive(true);
            if (PhotonNetwork.IsMasterClient)
            {
                restart.SetActive(true);
            }
        }
    }
}
