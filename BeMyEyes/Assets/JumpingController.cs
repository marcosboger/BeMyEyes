using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class JumpingController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody2D rb;
    private float jumpForce = 600f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Control by touching
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("touch");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
    }
}
