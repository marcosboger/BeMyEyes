using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSpawnManager : MonoBehaviour
{
    public GameObject JumpingObstacle;
    private float spawnTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(JumpingObstacle, new Vector3(1f, -0.58f, 0), Quaternion.identity);
    }
}
