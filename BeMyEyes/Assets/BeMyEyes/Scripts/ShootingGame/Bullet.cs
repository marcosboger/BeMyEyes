using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.ShootingGame
{
    public class Bullet : MonoBehaviour
    {
        private int type = 1;
        public float speed = 5.0f;

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            if(transform.position.y > 5.5f)
                Destroy(gameObject);
            
        }
    }
}
