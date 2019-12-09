using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class JumpingController : MonoBehaviour
{
    public GameObject JumpingSpawnManager;
    public GameObject ScoreManager;
    ScoreManager scoreScript;
    private Touch touch;
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private float _rotSpeed = 5f;
    private bool _rotation = false;
    [SerializeField]
    private bool _grounded = true;

    private GameObject restart;

    private GameObject[] obstacles;
    private bool _gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 10;
        PhotonNetwork.SerializationRate = 10;
        restart = GameObject.Find("Restart");
        rb = GetComponent<Rigidbody2D>();
        scoreScript = ScoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PhotonView>().IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (transform.position.x <= -1.72)
        {
            transform.position = new Vector3(-1.72f, transform.position.y, transform.position.z);
        }
        _grounded = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.1f);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (_grounded)
        {
            rb.rotation = 0;
            _rotation = false;
        }
        else
        {
            _rotation = true;
        }

        if (_rotation)
        {
            transform.Rotate(0, 0, -1 * _rotSpeed * Time.deltaTime);
        }
        //Control by touching
        if ( ( (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0) ) && _grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }



        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" && PhotonNetwork.IsMasterClient)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<platform>().see = true;
        }
        if (collision.gameObject.tag == "Obstacle" && PhotonNetwork.IsMasterClient)
        {
            gameObject.GetComponent<JumpingController>().enabled = false;
            JumpingSpawnManager.SetActive(false);
            scoreScript.dead = true;
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("GameOver", RpcTarget.All, collision.gameObject.transform.position);
        }
    }


    [PunRPC]
    void GameOver(Vector3 position)
    {
        if (!_gameOver)
        {
            _gameOver = true;
            gameObject.GetComponent<JumpingController>().enabled = false;
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            if (!PhotonNetwork.IsMasterClient)
            {
                GameObject.Find("JumpingSpawnManager").GetComponent<JumpingSpawnManager>().gameOver();
            }
            foreach (GameObject o in obstacles)
            {
                o.GetComponent<platform>().enabled = false;
            }
            if (PhotonNetwork.IsMasterClient)
            {
                restart.SetActive(true);
            }
        }
    }
}
