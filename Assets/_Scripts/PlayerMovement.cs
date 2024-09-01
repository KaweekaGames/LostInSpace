using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float forwardSpeed;
    public float reverseSpeed;
    public float brakeForce;
    public float maxForwardSpeed;
    public float maxReverseSpeed;
    public float damageStateReductionRate = .5f;
    public float rotationSpeed;
    public float slowDownTime;
    public SpriteRenderer thrustSprite;
    public GameInput gameInput;
    public WayPoint waypoint;

    private float speed = 0;
    private float thrustTimer = 0;
    private Vector2 startingPositon;

    private void Start()
    {
        //startingPositon = waypoint.GetStartingWaypoint();
        //transform.position = startingPositon;
    }

    // Update is called once per frame
    void Update ()
    {
        //Rotation Control
        float zRotation = gameInput.GetRotation();

        zRotation = -zRotation;

        transform.Rotate(0, 0, zRotation * rotationSpeed * Time.deltaTime);

        //Forward movement control
        if (gameInput.GetMovement() > 0)
        {
            speed += forwardSpeed;
            thrustTimer = .5f;
            speed = Mathf.Clamp(speed, maxReverseSpeed, maxForwardSpeed);
        }
        else if (gameInput.GetMovement() < 0)
        {
            if (speed > maxReverseSpeed)
            {
                speed -= reverseSpeed;
                speed = Mathf.Clamp(speed, maxReverseSpeed, maxForwardSpeed);
            }
        }
        else if (speed > 0)
        {
            speed -= slowDownTime * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxForwardSpeed);
        }
        else if (speed < 0) 
        {
            speed += slowDownTime * Time.deltaTime;
            speed = Mathf.Clamp(speed, maxReverseSpeed, 0);
        }

        //speed = Mathf.Clamp(speed -= slowDownTime * Time.deltaTime, maxReverseSpeed, masForwardSpeed);

        transform.Translate(0, speed * Time.deltaTime, 0);

        if (thrustTimer > 0)
        {
            thrustSprite.enabled = true;
            thrustTimer -= Time.deltaTime;
        }
        else thrustSprite.enabled = false;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void EnableDamageState()
    {
        maxForwardSpeed = maxForwardSpeed * damageStateReductionRate;
    }
}
