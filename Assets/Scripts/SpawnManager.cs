﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float powerupSpawnRange = 34;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(powerupPrefab, GeneratePowerupSpawnPosition(), powerupPrefab.transform.rotation);
    }
    public void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GeneratePowerupSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private Vector3 GeneratePowerupSpawnPosition()
    {
        float spawnPosX = Random.Range(-powerupSpawnRange, powerupSpawnRange);
        float spawnPosZ = 15;
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }    
}
