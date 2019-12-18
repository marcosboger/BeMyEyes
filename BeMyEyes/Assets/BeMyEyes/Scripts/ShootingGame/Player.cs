using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.ShootingGame
{
    public class Player : MonoBehaviour
    {
        private Touch touch;

        private float deltaX, deltaY, xPosition, yPosition;
        
        [SerializeField]
        private float cooldown = 0.2f;

        [SerializeField]
        private GameObject ScoreManager;
        [SerializeField]
        private GameObject bullet;

        private GameObject _player;
        private GameObject shootingPosition;
        

        ScoreManager scoreScript;

        private Vector2 touchInitialPosition;
        private Vector2 touchPosition;

        private bool _shoot = true;

        // Start is called before the first frame update
        void Start()
        {
            shootingPosition = GameObject.Find("Shooting Position");
            _player = GameObject.Find("Player");
            scoreScript = ScoreManager.GetComponent<ScoreManager>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Shoot();
        }

        public void Move()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touchInitialPosition = Camera.main.ScreenToWorldPoint(touch.position);
                }
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                deltaX = touchPosition.x - touchInitialPosition.x;
                deltaY = touchPosition.y - touchInitialPosition.y;

                xPosition = transform.position.x + deltaX;
                yPosition = transform.position.y + deltaY;

                if (xPosition > 2.20)
                    xPosition = 2.20f;
                if (xPosition < -2.20)
                    xPosition = -2.20f;
                if (yPosition > 4.50)
                    yPosition = 4.50f;
                if (yPosition < -4.50f)
                    yPosition = -4.50f;

                transform.position = new Vector3(xPosition, yPosition, transform.position.z);

                touchInitialPosition = touchPosition;
            }
        }

        public void Shoot()
        {
            if (_shoot)
            {
                _shoot = false;
                StartCoroutine(shooting());
            }
        }

        IEnumerator shooting()
        {
            yield return new WaitForSeconds(cooldown);
            Instantiate(bullet, shootingPosition.transform.position, Quaternion.identity);
            _shoot = true;
        }
    }
}