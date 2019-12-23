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
        private float missileCooldown = 0.5f;

        [SerializeField]
        private GameObject ScoreManager;
        [SerializeField]
        private GameObject bulletBlue;
        [SerializeField]
        private GameObject missile;

        private GameObject _player;
        private GameObject shootingPosition;

        private float missileTimer = 0;
        private float shootingTimer = 0;
        private float wait = 0;
        private float preWait = 0;


        ScoreManager scoreScript;

        private Vector2 touchInitialPosition;
        private Vector2 touchPosition;

        private bool _shoot = true;

        private int bullet = 0;

        PhotonView photon;

        // Start is called before the first frame update
        void Start()
        {
            shootingPosition = GameObject.Find("Shooting Position");
            _player = GameObject.Find("Player");
            scoreScript = ScoreManager.GetComponent<ScoreManager>();
            photon = PhotonView.Get(this);
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
            selectMissile();
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
            shootingTimer += Time.deltaTime;
            if (shootingTimer > cooldown && wait < 0 && preWait < 0)
            {
                photon.RPC("shootBlue", RpcTarget.AllViaServer, null);
                shootingTimer = 0;
                wait = 0;
                preWait = 0;
            }
        }

        public static bool IsDoubleTap()
        {
            bool result = false;
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
        }

        public void selectMissile()
        {
            missileTimer += Time.deltaTime;
            wait -= Time.deltaTime;
            preWait -= Time.deltaTime;

            if (preWait < 0 && _shoot)
            {
                photon.RPC("shootMissile", RpcTarget.AllViaServer, null);
                wait = 0.1f;
                _shoot = false;
            }

            if (PhotonNetwork.IsMasterClient)
            {
                if (IsDoubleTap() && missileTimer > missileCooldown)
                {
                    preWait = 0.1f;
                    _shoot = true;
                    missileTimer = 0;
                }
            }
        }

        [PunRPC]
        public void shootMissile()
        {
            Instantiate(missile, shootingPosition.transform.position, Quaternion.identity);
        }

        [PunRPC]
        public void shootBlue()
        {
            Instantiate(bulletBlue, shootingPosition.transform.position, Quaternion.identity);
        }
    }
}