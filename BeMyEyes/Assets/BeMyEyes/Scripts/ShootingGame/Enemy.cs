﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2.0f;
    private float waitTime = 1.5f;
    private float timer = 0;
    private int hp = 3;
    private Color _color;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -4.5f)
            GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver();
        if (hp == 0)
            Destroy(gameObject);
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            transform.position = transform.position + new Vector3(0, -1, 0);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Pink")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == gameObject.tag)
        {
            hp--;
            StartCoroutine(flash());
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision!");
            GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver();
        }
    }

    IEnumerator flash()
    {
        _color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = _color;
    }
}