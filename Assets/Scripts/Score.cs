using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player;
    public int score;
    public SpawnDefender spawnDefender;
    public bool hasScored;
    private float playerHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        hasScored = false;
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.gameObject.CompareTag("Goal"))
        {

            score++;
            Destroy(gameObject);
            spawnDefender.spawn(score);
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
            player.transform.position = new Vector3(0, playerHeight, 36);
            Debug.Log(score);
        }
    }
}
