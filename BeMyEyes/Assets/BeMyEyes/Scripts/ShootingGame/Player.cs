using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
        private GameObject bulletBlue;
        [SerializeField]
        private GameObject bulletPink;
        [SerializeField]
        private GameObject bulletGreen;

        private GameObject _player;
        private GameObject shootingPosition;
        

        ScoreManager scoreScript;

        private Vector2 touchInitialPosition;
        private Vector2 touchPosition;

        private bool _shoot = true;

        private int bullet = 0;

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
            if (gameObject.GetComponent<PhotonView>().IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            Move();
            Shoot();
            changeBullet();
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
            PhotonView photon;
            photon = PhotonView.Get(this);
            if (bullet == 0)
                photon.RPC("shootBlue", RpcTarget.AllViaServer, null);
            if (bullet == 1)
                photon.RPC("shootPink", RpcTarget.AllViaServer, null);
            if (bullet == 2)
                photon.RPC("shootGreen", RpcTarget.AllViaServer, null);
            _shoot = true;
        }

        public void changeBullet()
        {
            bool _change = IsDoubleTap();
            if (_change && bullet == 0)
                bullet = 1;
            else if (_change && bullet == 1)
                bullet = 0;
            else if (_change && bullet == 2)
                bullet = 0;
        }

        public static bool IsDoubleTap()
        {
            Touch press;
            bool _xMatch;
            bool _yMatch;
            Vector2 _touchPosition;
            Vector2 _playerPosition;
            

            /*bool result = false;
            float MaxTimeWait = 1;
            float VariancePosition = 1;

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                float DeltaTime = Input.GetTouch(0).deltaTime;
                float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

                if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                    result = true;
            }
            return result;
            */
            
            _playerPosition = GameObject.Find("Player").transform.position;
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                press = Input.GetTouch(0);
                _touchPosition = Camera.main.ScreenToWorldPoint(press.position);
                _xMatch = (_touchPosition.x <= _playerPosition.x + 0.35f && _touchPosition.x >= _playerPosition.x - 0.35f);
                _yMatch = (_touchPosition.y <= _playerPosition.y + 0.45f && _touchPosition.y >= _playerPosition.y - 0.45f);
                if (_xMatch && _yMatch)
                {
                    return true;
                }
            }
            return false;
        }

        [PunRPC]
        public void shootBlue()
        {
            Instantiate(bulletBlue, shootingPosition.transform.position, Quaternion.identity);
        }

        [PunRPC]
        public void shootPink()
        {
            Instantiate(bulletPink, shootingPosition.transform.position, Quaternion.identity);
        }

        [PunRPC]
        public void shootGreen()
        {
            Instantiate(bulletGreen, shootingPosition.transform.position, Quaternion.identity);
        }
    }
}