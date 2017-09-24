using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRadar : MonoBehaviour
{
    public float range;
    public LayerMask mask;

    private EnemyMovement enemyMovement;
    private bool madeCall;

	// Use this for initialization
	void Start ()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Use Ray to determine if an object is in the way
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.up, range, mask);

        if (hit2D)
        {
            Debug.DrawLine(transform.position, hit2D.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * range, Color.green);
        }

        if(!madeCall && hit2D && !enemyMovement.hasObstacle)
        {
            madeCall = true;
            enemyMovement.AddObstacle(hit2D.collider.gameObject);
        }

        if(madeCall && !hit2D)
        {
            madeCall = false;
            enemyMovement.RemoveObstacle();
        }
    }
}
