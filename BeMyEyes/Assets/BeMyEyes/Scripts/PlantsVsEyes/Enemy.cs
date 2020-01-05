using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class Enemy : MonoBehaviour
    {
        private float _speed = 2.0f;

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _speed * Time.deltaTime, transform.position.z);
            if (transform.position.y < -2.4f && !PhotonNetwork.IsMasterClient)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().gameOver();
            }
        }
    }
}
