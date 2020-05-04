using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCode : MonoBehaviour
{

    private float nextSpawnTime;
    [SerializeField]
    private GameObject shamanPrefab;
    [SerializeField]
    private float spawnDelay = 10;
    
    void Update()
    {
        if(ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        //nextSpawnTime = Time.time + spawnDelay;
        Instantiate(shamanPrefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
