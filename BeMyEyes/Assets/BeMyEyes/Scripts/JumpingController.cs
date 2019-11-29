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
        if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && _grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }



        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
