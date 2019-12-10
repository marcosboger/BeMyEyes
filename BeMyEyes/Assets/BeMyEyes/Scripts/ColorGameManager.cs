using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ColorGameManager : MonoBehaviour
{
    private List<float> timers = new List<float>();
    private List<float> blinkers = new List<float>();
    private List<bool> enableTimers = new List<bool>();
    public List<Color> colors = new List<Color>();
    private string[] colorNames = new string[7];
    private string[] myColors = new string[7];
    private string[] yourColors = new string[7];
    public List<Button> buttons = new List<Button>();
    public List<float> blinkWait = new List<float>();
    private List<int> usedcolors = new List<int>();
    private GameObject[] lights;
    private GameObject text;
    private GameObject buttonsUI;
    private float waitTime = 2f;
    private float waiting = 0f;
    private int _random;
    private bool podepa = false;
    private int random;
    public Text ScoreText;
    private int score = 0;

    Color orange = new Color(1, 0.738f, 0.4392f, 1);
    Color pink = new Color(1, 0.4386f, 0.9068f, 1);
    Color purple = new Color(0.492f, 0, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        buttonsUI = GameObject.Find("Buttons");
        text = GameObject.Find("GameOverText");
        text.SetActive(false);
        colorNames[0] = "blue";
        colorNames[1] = "green";
        colorNames[2] = "orange";
        colorNames[3] = "pink";
        colorNames[4] = "purple";
        colorNames[5] = "red";
        colorNames[6] = "yellow";
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(orange);
        colors.Add(pink);
        colors.Add(purple);
        colors.Add(Color.red);
        colors.Add(Color.yellow);
        for (int i = 0; i < 7; i++)
        {
            while (!podepa)
            {
                podepa = true;
                random = Random.Range(0, colors.Count);
                for (int z = 0; z < usedcolors.Count; z++)
                {
                    if (random == usedcolors[z])
                        podepa = false;
                }
                if (random == i)
                    podepa = false;
            }
            usedcolors.Add(random);
            podepa = false;
            timers.Add(0f);
            blinkers.Add(0f);
            enableTimers.Add(false);
            blinkWait.Add(0.5f);
            buttons[i].GetComponent<Image>().color = colors[random];
            myColors[i] = colorNames[random];
            if (!PhotonNetwork.IsMasterClient)
            {
                buttons[i].interactable = false;
            }
        }
        lights = GameObject.FindGameObjectsWithTag("Light");
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
            }
        }
        else
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("colorPass", RpcTarget.Others, myColors);
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            waiting += Time.deltaTime;
            if (waiting >= waitTime)
            {
                _random = Random.Range(0, 7);
                if (!enableTimers[_random])
                {
                    enableTimers[_random] = true;
                    if (waitTime > 0.8f)
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
            if (enableTimers[6])
            {
                manageTimer(6);
            }
            #endregion
        }
    }

    private void manageTimer(int j)
    {
        timers[j] += Time.deltaTime;
        blinkers[j] += Time.deltaTime;
        if (blinkers[j] >= blinkWait[j])
        {
            if (buttons[j].transform.Find("Light").GetComponent<Image>().color == Color.white)
            {
                buttons[j].transform.Find("Light").GetComponent<Image>().color = Color.red;
            }
            else if (buttons[j].transform.Find("Light").GetComponent<Image>().color == Color.red)
            {
                buttons[j].transform.Find("Light").GetComponent<Image>().color = Color.white;
                if (blinkWait[j] > 0.2f)
                {
                    blinkWait[j] -= 0.05f;
                }
            }
            blinkers[j] = 0;
        }
        if(timers[j] > 10.0f)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("gameOver", RpcTarget.All, null);
        }

    }
    [PunRPC]
    void gameOver()
    {
        buttonsUI.SetActive(false);
        text.SetActive(true);
    }
    #region ButtonPresses
    [PunRPC]
    public void buttonPress0()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for(int j = 0; j < 7; j++)
            {
                if (myColors[0] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else {
            if (enableTimers[0])
            {
                enableTimers[0] = false;
                buttons[0].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress1()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[1] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[1])
            {
                enableTimers[1] = false;
                buttons[1].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress2()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[2] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[2])
            {
                enableTimers[2] = false;
                buttons[2].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress3()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[3] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[3])
            {
                enableTimers[3] = false;
                buttons[3].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress4()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[4] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[4])
            {
                enableTimers[4] = false;
                buttons[4].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress5()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[5] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[5])
            {
                enableTimers[5] = false;
                buttons[5].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    public void buttonPress6()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int j = 0; j < 7; j++)
            {
                if (myColors[6] == yourColors[j])
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("buttonPress" + j, RpcTarget.Others, null);
                }
            }
        }
        else
        {
            if (enableTimers[6])
            {
                enableTimers[6] = false;
                buttons[6].transform.Find("Light").GetComponent<Image>().color = Color.white;
                score += 1;
                ScoreText.text = "Score: " + score;
            }
            else
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("gameOver", RpcTarget.All, null);
            }
        }
    }
    [PunRPC]
    void colorPass(string[] passedColors)
    {
        yourColors = passedColors;
    }

    #endregion

}
