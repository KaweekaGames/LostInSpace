using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float forwardSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public float slowDownTime;
	public RockSpawner rockSpawner;

    private float speed = 0;

	// Update is called once per frame
	void Update ()
    {
        //Rotation control
        float zRotation = Input.GetAxisRaw("Horizontal");

        zRotation = -zRotation;

        transform.Rotate(0, 0, zRotation * rotationSpeed * Time.deltaTime);

        //Forward movement control
        if (Input.GetButtonDown("Forward"))
        {
            speed += forwardSpeed;
            
        }

        speed -= slowDownTime * Time.deltaTime;

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        transform.Translate(0, speed * Time.deltaTime, 0);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == 
	}
}
