using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float forwardSpeed;
    public float brakeForce;
    public float maxSpeed;
    public float rotationSpeed;
    public float slowDownTime;
    public SpriteRenderer thrustSprite;
    public GameInput gameInput;

    private float speed = 0;
    private float thrustTimer = 0;

    // Update is called once per frame
    void Update ()
    {
        //Rotation Control
        float zRotation = gameInput.GetRotation();

        zRotation = -zRotation;

        transform.Rotate(0, 0, zRotation * rotationSpeed * Time.deltaTime);

        //Forward movement control
        if (gameInput.GetJumpPressed() > 0)
        {
            speed += forwardSpeed;
            thrustTimer = .5f;
            
        }

        //speed -= slowDownTime * Time.deltaTime;

        speed = Mathf.Clamp(speed -= slowDownTime * Time.deltaTime, 0, maxSpeed);

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
}
