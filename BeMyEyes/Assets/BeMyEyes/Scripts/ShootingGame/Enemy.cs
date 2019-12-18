using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2.0f;
    private float waitTime = 1.5f;
    private float timer = 0;
    private int hp = 3;

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
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
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
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
