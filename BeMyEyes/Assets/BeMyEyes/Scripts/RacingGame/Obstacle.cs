using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.RacingGame
{
    public class Obstacle : MonoBehaviour
    {
        public float speed = 6.0f;
        public bool see = false;

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            if (transform.position.y < -7)
            {
                Destroy(gameObject);
            }
        }
    }
}
