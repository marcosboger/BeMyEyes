using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class JumpingController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private float _rotSpeed = 5f;
    private bool _rotation = false;
    [SerializeField]
    private bool _grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -1.72)
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
        if (collision.gameObject.tag == "Obstacle")
        {
            RestartManager.gameOver();
            gameObject.SetActive(false);
        }
    }
}
