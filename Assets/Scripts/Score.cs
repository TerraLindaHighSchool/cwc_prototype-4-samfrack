using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player;
    public GameObject ballPrefab;
    public GameObject powerUpPrefab;
    public int score;
    public SpawnManager spawnManager;
    public bool hasScored;
    private float playerHeight = 0.5f;
    public GameObject enemyPrefab;
    private float defenderSpawnRange = 15;
    public int waveNumber = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        hasScored = false;
        score = 0;
        SpawnEnemyWave(waveNumber); 
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.gameObject.CompareTag("Goal"))
        {
            score++;
            Destroy(gameObject);
            foreach (GameObject enemyClone in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemyClone);
            }
            Destroy(powerUpPrefab);
            spawnManager.SpawnPowerup();
            Instantiate(ballPrefab, new Vector3(0, 0.5f, 0), ballPrefab.transform.rotation);
            player.transform.position = new Vector3(0, playerHeight, 36);
            Debug.Log(score);
        }
    }

    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var enemyClone = Instantiate(enemyPrefab, GenerateDefenderSpawnPosition(), enemyPrefab.transform.rotation);
            Debug.Log("Spawned");
        }
    }

    private Vector3 GenerateDefenderSpawnPosition()
    {
        float spawnPosX = Random.Range(-defenderSpawnRange, defenderSpawnRange);
        float spawnPosZ = -23;
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
