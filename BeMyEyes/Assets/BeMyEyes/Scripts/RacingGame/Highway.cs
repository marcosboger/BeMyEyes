using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.RacingGame
{
    public class Highway : MonoBehaviour
    {
        public float speed = 5.0f;

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
    }
}
