using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.BeMyEyes.PlantsVsEyes
{
    public class Example : MonoBehaviour
    {
        Vector2 touchPosition;
        ButtonManager buttonManager;

        private void Start()
        {
            buttonManager = GameObject.Find("Button Manager").GetComponent<ButtonManager>();
        }

        // Update is called once per frame
        void Update()
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (Input.touchCount == 1)
            {
                transform.position = new Vector3(touchPosition.x, touchPosition.y + 0.7f, transform.position.z);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (CompareTag("Purple"))
                    buttonManager.spawnPurpleBullet(touchPosition);
                if (CompareTag("Red"))
                    buttonManager.spawnRedBullet(touchPosition);
                if (CompareTag("Yellow"))
                    buttonManager.spawnYellowBullet(touchPosition);
                Destroy(this.gameObject);
            }
        }
    }
}
