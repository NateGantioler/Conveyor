using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    // how many seconds need to pass before spawning another package
    public float spawnInterval;

    // timer that gets decreased as time passes. It gets reset to the interval everytime it reaches 0
    private float spawnTimer;

    // package gameobject to spawn
    public GameObject packagePrefab;

    public Transform spawnPosition;

    public void Start()
    {
        spawnTimer = spawnInterval;
    }
    
    public void Update()
    {
        if(spawnTimer <= 0)
        {
            // timer gets reset
            spawnTimer = spawnInterval;
            // package gets spawned
            SpawnPackage();
            return;
        }
        if(spawnTimer > 0)
        {
            // timer gets decreased in time
            spawnTimer -= Time.deltaTime;
        }
        Debug.Log($"TIMER:{Mathf.FloorToInt(spawnTimer)}");
    }

    private void SpawnPackage()
    {
        Instantiate(packagePrefab, spawnPosition.position, Quaternion.identity);
    }

}
