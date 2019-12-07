using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime = 0.5f;
    private float _x;
    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        _x = Random.Range(0,6);
        if(_x == 0)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
        }
        else if(_x == 1)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
        }
        else if(_x == 2)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
        }
        else if(_x == 3)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
            PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
        }
        else if(_x == 4)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(3, 5.7f, 0), Quaternion.identity);
            PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
        }
        else if(_x == 5)
        {
            PhotonNetwork.Instantiate("Obstacle", new Vector3(4.41f, 5.7f, 0), Quaternion.identity);
            PhotonNetwork.Instantiate("Obstacle", new Vector3(1.59f, 5.7f, 0), Quaternion.identity);
        }
        //PhotonNetwork.Instantiate("Obstacle", new Vector3(_x, 6.5f, 0), Quaternion.identity);
    }

    public void gameOver()
    {
        CancelInvoke();
    }
}
