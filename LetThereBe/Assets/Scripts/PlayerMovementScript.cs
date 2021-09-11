using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementScript : MonoBehaviour
{

    public Rigidbody thisRb;
    public float thrustForce = 100f;
    public float turnForce = 10f;

    private Vector2 turnAxis;
    
    void FixedUpdate()
    {
        if (Input.GetKey("space") || Input.GetButton("Fire1"))
        {
            Thrust();
        }
        
        turnAxis.x = Input.GetAxis("Horizontal") * Time.deltaTime;  
        turnAxis.y = Input.GetAxis("Vertical") * Time.deltaTime;
        Turn(turnAxis);
        
    }

    void Thrust()
    {
        thisRb.AddForce(transform.forward * thrustForce * Time.deltaTime);
    }

    void Turn(Vector2 direction)
    {
        thisRb.AddTorque(transform.up * turnAxis.x * turnForce);
        thisRb.AddTorque(transform.right * turnAxis.y * turnForce);
    }


}
