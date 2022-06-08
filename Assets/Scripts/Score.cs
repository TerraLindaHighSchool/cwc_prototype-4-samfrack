using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public GameObject ballPrefab;
    public GameObject powerUpPrefab;
    public int score;
    public bool hasScored;
    private float playerHeight = -0.75f;
    public TextMeshProUGUI scoreText;
    private float ballSpawnRange = 20;
    public SpawnManager spawnManager;
    //public int waveNumber = 1;
    //public int enemyCount;
    //public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        hasScored = false;
        score = 0;
        //SpawnEnemyWave(waveNumber); 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.gameObject.CompareTag("Goal"))
        {
            hasScored = true;
            scoreRoutine();
        }
    }

    void scoreRoutine()
    {
        score++;
        Destroy(gameObject);
        Destroy(powerUpPrefab);
        spawnManager.SpawnPowerup();
        Instantiate(ballPrefab, BallSpawnPosition(), ballPrefab.transform.rotation);
        player.transform.position = new Vector3(0, playerHeight, 36);
        Debug.Log(score);
        UpdateScore();
        
    }

    private Vector3 BallSpawnPosition()
    {
        float spawnPosX = Random.Range(-ballSpawnRange, ballSpawnRange);
        float spawnPosZ = -23;
        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);
        return randomPos;
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }
}
