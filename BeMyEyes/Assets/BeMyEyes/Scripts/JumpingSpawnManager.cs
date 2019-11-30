using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSpawnManager : MonoBehaviour
{
    public GameObject JumpingObstacle;
    public GameObject JumpingPlatform;
    private float spawnTime = 1.5f;
    private float _random;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        _random = Random.Range(0, 4);
        if(_random == 0)
        {
            Instantiate(JumpingObstacle, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
        }
        if (_random == 1)
        {
            Instantiate(JumpingObstacle, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
        }
        if (_random == 2)
        {
            Instantiate(JumpingPlatform, new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(4.05f, -2.75f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(5.52f, -2.01f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(6.01f, -2.01f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(6.50f, -2.01f, 0), Quaternion.identity);

            Instantiate(JumpingObstacle, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(5.52f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(6.01f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(6.50f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(6.99f, -3.48f, 0), Quaternion.identity);
        }
        if (_random == 3)
        {
            Instantiate(JumpingPlatform, new Vector3(3.07f, -2.75f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(3.56f, -2.75f, 0), Quaternion.identity);
            Instantiate(JumpingPlatform, new Vector3(4.05f, -2.75f, 0), Quaternion.identity);

            Instantiate(JumpingObstacle, new Vector3(3.07f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(3.56f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(4.05f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(4.54f, -3.48f, 0), Quaternion.identity);
            Instantiate(JumpingObstacle, new Vector3(5.03f, -3.48f, 0), Quaternion.identity);
        }
    }
}
