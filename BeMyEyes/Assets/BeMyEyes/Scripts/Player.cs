using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Player : MonoBehaviour
{
    private Touch touch;
    private Vector2 _touchPosition;
    public Joystick joystick;
    private float _horizontalMove;
    public float speed = 5.0f;
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PhotonView>().IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        //Control by touching
        //if(Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //    _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    transform.position = new Vector3(_touchPosition.x, transform.position.y, transform.position.z);
        //}

        //Control by joystick
        _horizontalMove = SimpleInput.GetAxis("Horizontal") * speed;
        if (transform.position.x <= 4.6 && transform.position.x >= -4.6) 
        {
            transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 4.6 && _horizontalMove < 0)
        {
            transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -4.6 && _horizontalMove > 0)
        {
            transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //Destroy(gameObject);
        }
    }
}
