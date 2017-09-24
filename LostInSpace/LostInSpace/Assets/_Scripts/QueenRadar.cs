using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenRadar : MonoBehaviour
{
    public SpawnChild spawner;
    public float radarDistance;

    private Transform playerTrans;

	// Use this for initialization
	void Start ()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 distance = new Vector2(transform.position.x - playerTrans.position.x, transform.position.y - playerTrans.position.y);

        if (radarDistance >= distance.magnitude)
        {
            spawner.canSpawn = true;
        }
        else spawner.canSpawn = false;
        
	}
}
