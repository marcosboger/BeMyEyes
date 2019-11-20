using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSpawnManager : MonoBehaviour
{
    public GameObject cubinho;
    private float spawnTime = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(cubinho, new Vector3(15.5f, -0.88f, 0), Quaternion.identity);
    }
}
