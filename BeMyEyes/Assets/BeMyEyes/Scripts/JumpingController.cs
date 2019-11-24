using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class JumpingController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody2D rb;
    private float jumpForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Control by touching
        if((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && rb.velocity.y == 0)
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
