using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacles;
    public float maxX;
    public float minX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    public float spawnTime;
    private float[] laneYs = { -3f, -1.5f, 0f };
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }
    public void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        // float randomY = Random.Range(minY, maxY);
        float randomY = laneYs[Random.Range(0, 3)];
        Instantiate(obstacles, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
