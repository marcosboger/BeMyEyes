using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private SpriteRenderer sprite;
    public bool spriteRender = true;
    public float spawnTime = 0.5f;
    private float _x;
    private void Start()
    {
        sprite = obstacle.GetComponent<SpriteRenderer>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (spriteRender == false)
        {
            sprite.enabled = false;
        }
        _x = Random.Range(-3.6f, 3.6f);
        Instantiate(obstacle, new Vector3 (_x, 6.5f, 0), Quaternion.identity);
    }
}
