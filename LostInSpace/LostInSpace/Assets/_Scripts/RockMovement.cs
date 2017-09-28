using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float rotSpeed;
    public float fallingSpeed;
    public bool clockwise;
    public Vector2 destination;
	public int hitPoints;

	// Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, fallingSpeed * Time.deltaTime);

        if (clockwise)
        {
            transform.Rotate(0, 0, 1 * rotSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -1 * rotSpeed * Time.deltaTime);
        }
    }
}
