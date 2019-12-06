using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGameManager : MonoBehaviour
{
    private List<float> timers = new List<float>();
    private List<float> blinkers = new List<float>();
    private List<bool> enableTimers = new List<bool>();
    public List<Button> buttons = new List<Button>();
    public List<float> blinkWait = new List<float>();
    private GameObject text;
    private GameObject buttonsUI;
    private float waitTime = 2f;
    private float waiting = 0f;
    private int _random;
    // Start is called before the first frame update
    void Start()
    {
        buttonsUI = GameObject.Find("Buttons");
        text = GameObject.Find("GameOverText");
        text.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            timers.Add(0f);
            blinkers.Add(0f);
            enableTimers.Add(false);
            blinkWait.Add(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        waiting += Time.deltaTime;
        if(waiting >= waitTime)
        {
            _random = Random.Range(0, 6);
            if (!enableTimers[_random])
            {
                enableTimers[_random] = true;
                if(waitTime > 0.8f)
                    waitTime -= 0.1f;
                waiting = 0;
                timers[_random] = 0;
                blinkers[_random] = 0;
                blinkWait[_random] = 0.6f;
            }
        }
        #region TimeManagers
        if (enableTimers[0])
        {
            manageTimer(0);
        }
        if (enableTimers[1])
        {
            manageTimer(1);
        }
        if (enableTimers[2])
        {
            manageTimer(2);
        }
        if (enableTimers[3])
        {
            manageTimer(3);
        }
        if (enableTimers[4])
        {
            manageTimer(4);
        }
        if (enableTimers[5])
        {
            manageTimer(5);
        }
        #endregion
    }

    private void manageTimer(int j)
    {
        timers[j] += Time.deltaTime;
        blinkers[j] += Time.deltaTime;
        if (blinkers[j] >= blinkWait[j])
        {
            if (buttons[j].GetComponent<Image>().color == Color.white)
            {
                buttons[j].GetComponent<Image>().color = Color.red;
            }
            else if (buttons[j].GetComponent<Image>().color == Color.red)
            {
                buttons[j].GetComponent<Image>().color = Color.white;
                if (blinkWait[j] > 0.2f)
                {
                    blinkWait[j] -= 0.05f;
                }
            }
            blinkers[j] = 0;
        }
        if(timers[j] > 10.0f)
        {
            gameOver();
        }

    }
    private void gameOver()
    {
        buttonsUI.SetActive(false);
        text.SetActive(true);
    }
    #region ButtonPresses
    public void buttonPress0()
    {
        if (enableTimers[0])
        {
            enableTimers[0] = false;
            buttons[0].GetComponent<Image>().color = Color.white;
        }
    }
    public void buttonPress1()
    {
        if (enableTimers[1])
        {
            enableTimers[1] = false;
            buttons[1].GetComponent<Image>().color = Color.white;
        }
    }
    public void buttonPress2()
    {
        if (enableTimers[2])
        {
            enableTimers[2] = false;
            buttons[2].GetComponent<Image>().color = Color.white;
        }
    }
    public void buttonPress3()
    {
        if (enableTimers[3])
        {
            enableTimers[3] = false;
            buttons[3].GetComponent<Image>().color = Color.white;
        }
    }
    public void buttonPress4()
    {
        if (enableTimers[4])
        {
            enableTimers[4] = false;
            buttons[4].GetComponent<Image>().color = Color.white;
        }
    }
    public void buttonPress5()
    {
        if (enableTimers[5])
        {
            enableTimers[5] = false;
            buttons[5].GetComponent<Image>().color = Color.white;
        }
    }

    #endregion

}
