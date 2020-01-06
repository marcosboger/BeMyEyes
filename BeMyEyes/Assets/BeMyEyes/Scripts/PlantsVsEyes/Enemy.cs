using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class Enemy : MonoBehaviour
    {
        private float _speed = 2.0f;
        private float timer = 0f;

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            
            transform.position = new Vector3(transform.position.x, transform.position.y - _speed * Time.deltaTime, transform.position.z);
            
            if (transform.position.y < -2.4f && !PhotonNetwork.IsMasterClient)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver();
            }

            if(timer > 140)
            {
                _speed = 2.2f;
            }

            if (timer > 170)
            {
                _speed = 2.5f;
            }

            if (timer > 200)
            {
                _speed = 2.7f;
            }

            if (timer > 250)
            {
                _speed = 3.0f;
            }
        }
    }
}
