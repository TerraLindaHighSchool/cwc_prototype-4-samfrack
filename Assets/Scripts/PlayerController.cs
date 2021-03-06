using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ballrb;
    private float horizontalInput;
    private float forwardInput;
    private float turnSpeed = 45.0f;
    public float speed = 45.0f;
    private float powerUpStrength = 15.0f;
    public UITimer timer;
    public GameManager gameManager;
    
    
    // Instantiates Rigidbody 
    void Start()
    {
        ballrb = GetComponent<Rigidbody>();
    }

    // Moves player forward based off vertical input buttons
    void Update()
    {
        if (timer.gameOver == false && gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            //Move the vehicle forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    
    // Adds force if player collides with soccerball
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soccer Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            ballRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
