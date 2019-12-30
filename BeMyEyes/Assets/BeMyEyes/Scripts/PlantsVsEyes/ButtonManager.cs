using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Instantiate(purpleBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                Instantiate(purpleBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                Instantiate(purpleBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                Instantiate(purpleBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }

        public void spawnRedBullet(Vector2 touchPosition)
        {
            if (touchPosition.x >= 0.1f && touchPosition.x <= 1.15f && touchPosition.y >= -3.5f)
                Instantiate(redBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                Instantiate(redBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                Instantiate(redBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                Instantiate(redBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }

        public void spawnYellowBullet(Vector2 touchPosition)
        {
            if (touchPosition.x >= 0.1f && touchPosition.x <= 1.15f && touchPosition.y >= -3.5f)
                Instantiate(yellowBullet, new Vector2(0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -1.15f && touchPosition.x <= -0.1f && touchPosition.y >= -3.5f)
                Instantiate(yellowBullet, new Vector2(-0.625f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= 1.35 && touchPosition.x <= 2.4f && touchPosition.y >= -3.5f)
                Instantiate(yellowBullet, new Vector2(1.875f, -2.3f), Quaternion.identity);
            if (touchPosition.x >= -2.4f && touchPosition.x <= -1.35f && touchPosition.y >= -3.5f)
                Instantiate(yellowBullet, new Vector2(-1.875f, -2.3f), Quaternion.identity);
        }
    }
}
