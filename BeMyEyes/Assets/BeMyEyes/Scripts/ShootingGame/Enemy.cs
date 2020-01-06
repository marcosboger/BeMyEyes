using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.ShootingGame
{
    public class Enemy : MonoBehaviour
    {
        private float _speed = 2.0f;
        private int type = 0;
        private float waitTime = 1.5f;
        private float timer = 0;
        [SerializeField]
        private int hp = 3;
        private Color _color;
        private PhotonView photon;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            photon = PhotonView.Get(this);
            photon.ViewID = gameManager.setViewID();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < -4.5f)
            {
                gameManager.gameOver();
                if (PhotonNetwork.IsMasterClient)
                    RestartManager.gameOver();
            }
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                transform.position = transform.position + new Vector3(0, -1, 0);
                timer = 0;
            }

            if(gameManager.totalTimer > 90f && gameManager.totalTimer < 120f)
            {
                waitTime = 1.2f;
            }

            if (gameManager.totalTimer > 120f && gameManager.totalTimer < 150f)
            {
                waitTime = 1f;
            }

            if (gameManager.totalTimer > 150f && gameManager.totalTimer < 200f)
            {
                waitTime = 0.8f;
            }

            if (gameManager.totalTimer > 200f)
            {
                waitTime = 0.5f;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Pink")
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == gameObject.tag && !PhotonNetwork.IsMasterClient)
            {
                StartCoroutine(flash());
                photon.RPC("takeDamage", RpcTarget.AllViaServer, null);
            }
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Collision!");
                if(PhotonNetwork.IsMasterClient)
                    RestartManager.gameOver();
                GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver();
            }
        }

        [PunRPC]
        public void takeDamage()
        {
            hp--;
            if (hp == 0)
                Destroy(gameObject);
        }

        IEnumerator flash()
        {
            _color = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<SpriteRenderer>().color = _color;
        }
    }
}
