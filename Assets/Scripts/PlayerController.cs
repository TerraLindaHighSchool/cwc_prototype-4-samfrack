using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerrb;
    private GameObject focalPoint;
    public float speed = 5.0f;
    
    // Instantiates Rigidbody 
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Moves player forward based off vertical input buttons
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerrb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        new   
    }
}
