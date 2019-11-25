using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysBehavior : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.position = new Vector3(13.125f, 27f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(0.01f, 0, 0);
        //transform.position = new Vector3(15f, 0, 0);
        //if(transform.position.x >= 30)
        //{
        //    transform.position = new Vector3(0, 0, 0);
        //}
    }
}
