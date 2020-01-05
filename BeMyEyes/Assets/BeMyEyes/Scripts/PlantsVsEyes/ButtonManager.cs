using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject purpleExample, redExample, yellowExample;

        [SerializeField]
        private GameObject purpleBullet, redBullet, yellowBullet;

        private Touch touch;

        private Vector2 initialPosition;

        private PhotonView photon;

        private void Start()
        {
            photon = PhotonView.Get(this);
        }

        void Update()
        {
            if(Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    initialPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    if (insidePurple(initialPosition))
                    {
                        Instantiate(purpleExample, initialPosition, Quaternion.identity);
                    }
                    else if (insideRed(initialPosition))
                    {
                        Instantiate(redExample, initialPosition, Quaternion.identity);
                    }
                    else if (insideYellow(initialPosition))
                    {
                        Instantiate(yellowExample, initialPosition, Quaternion.identity);
                    }
                }
            }
        }

        private bool insidePurple(Vector2 touchPosition)
        {
            if (touchPosition.x <= -0.8 && touchPosition.x >= -2.2f && touchPosition.y <= -3.3f && touchPosition.y >= -4.7f)
                return true;
            else
                return false;
        }

        private bool insideRed(Vector2 touchPosition)
        {
            if (touchPosition.x <= 0.7 && touchPosition.x >= -0.7 && touchPosition.y <= -3.3f && touchPosition.y >= -4.7f)
                return true;
            else
                return false;
        }

        private bool insideYellow(Vector2 touchPosition)
        {
            if (touchPosition.x <= 2.2 && touchPosition.x >= 0.8 && touchPosition.y <= -3.3f && touchPosition.y >= -4.7f)
                return true;
            else
                return false;
        }

        public void spawnPurpleBullet(Vector2 touchPosition)
        {
            if (touchPosition.x >= 0.1f && touchPosition.x <= 1.15f && touchPosition.y >= -3.5f)
                photon.RPC("spawnPurple", RpcTarget.AllViaServer, 0);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                photon.RPC("spawnPurple", RpcTarget.AllViaServer, 1);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                photon.RPC("spawnPurple", RpcTarget.AllViaServer, 2);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                photon.RPC("spawnPurple", RpcTarget.AllViaServer, 3);
        }

        [PunRPC]
        public void spawnPurple(int position)
        {
            if(position == 0)
                Instantiate(purpleBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if(position == 1)
                Instantiate(purpleBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (position == 2)
                Instantiate(purpleBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (position == 3)
                Instantiate(purpleBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }

        public void spawnRedBullet(Vector2 touchPosition)
        {
            if (touchPosition.x >= 0.1f && touchPosition.x <= 1.15f && touchPosition.y >= -3.5f)
                photon.RPC("spawnRed", RpcTarget.AllViaServer, 0);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                photon.RPC("spawnRed", RpcTarget.AllViaServer, 1);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                photon.RPC("spawnRed", RpcTarget.AllViaServer, 2);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                photon.RPC("spawnRed", RpcTarget.AllViaServer, 3);
        }

        [PunRPC]
        public void spawnRed(int position)
        {
            if (position == 0)
                Instantiate(redBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if (position == 1)
                Instantiate(redBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (position == 2)
                Instantiate(redBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (position == 3)
                Instantiate(redBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }

        public void spawnYellowBullet(Vector2 touchPosition)
        {
            if (touchPosition.x >= 0.1f && touchPosition.x <= 1.15f && touchPosition.y >= -3.5f)
                photon.RPC("spawnYellow", RpcTarget.AllViaServer, 0);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                photon.RPC("spawnYellow", RpcTarget.AllViaServer, 1);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                photon.RPC("spawnYellow", RpcTarget.AllViaServer, 2);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                photon.RPC("spawnYellow", RpcTarget.AllViaServer, 3);
        }

        [PunRPC]
        public void spawnYellow(int position)
        {
            if (position == 0)
                Instantiate(yellowBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if (position == 1)
                Instantiate(yellowBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (position == 2)
                Instantiate(yellowBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (position == 3)
                Instantiate(yellowBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }
    }
}
