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
    public bool hasPowerup;
    public bool hasNotTouchedSoccerball;
    private float powerUpStrength = 15.0f;
    public GameObject powerupIndicator;
    
    // Instantiates Rigidbody 
    void Start()
    {
        ballrb = GetComponent<Rigidbody>();
    }

    // Moves player forward based off vertical input buttons
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    //Gives player powerup of player touches powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
            hasNotTouchedSoccerball = true;
        }
    }
    
    // Adds force if player collides with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soccer Ball") && hasPowerup && hasNotTouchedSoccerball)
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collide with" + collision.gameObject.name + " with powerup set to " + hasPowerup);
            ballRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            hasNotTouchedSoccerball = false; 
        }
    }

    // Turns has powerup to false after 7 seconds and deactivates powerupIndicator
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(4);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
