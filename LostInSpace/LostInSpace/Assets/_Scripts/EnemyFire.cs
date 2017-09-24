using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float range;
    public LayerMask mask;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        //Use Ray to determine if player is in range to fire
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.up, range, mask);

        if (hit2D)
        {
            Debug.DrawLine(transform.position, hit2D.point, Color.red);
        }
        else Debug.DrawLine(transform.position, transform.position + transform.up * range, Color.green);
    }
}
