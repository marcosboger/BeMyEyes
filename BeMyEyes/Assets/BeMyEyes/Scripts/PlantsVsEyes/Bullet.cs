using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class Bullet : MonoBehaviour
    {
        private float _speed = 2.0f;

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _speed * Time.deltaTime, transform.position.z);
            if (transform.position.y > 5.5f)
            {
                Destroy(gameObject);
                //GameManager.GameOver();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (gameObject.CompareTag(collision.gameObject.tag))
            {
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
