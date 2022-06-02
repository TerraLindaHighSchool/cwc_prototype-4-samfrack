using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    public GameObject soccerBall;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (soccerBall.transform.position - transform.position).normalized;

        if (transform.position.y < -10)
        {
            Debug.Log(transform.position);
            Destroy(gameObject);
        }
    }
}
