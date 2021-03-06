﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float rotSpeed;
    public float speed;
    public bool hasObstacle;
    public int amountDebris;
    public GameObject debris1;
    public GameObject debris2;
    public GameObject debris3;
    public GameObject exploder;

    private GameObject player;
    private Vector2 playerPosition;
    private Transform obstacleTrans;
    private Vector2 obstaclePosition;
    private DamageManager damageMan;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageMan = GetComponent<DamageManager>();
	}

    // Update is called once per frame
    void Update()
    {

        //If present, move away from obstacle
        if (obstacleTrans != null)
        {
            obstaclePosition = obstacleTrans.position;
            Vector2 direc = new Vector2(obstaclePosition.x - transform.position.x, obstaclePosition.y - transform.position.y);
            direc.Normalize();

            float zAngle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 90;

            Quaternion desRotation = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desRotation, rotSpeed * Time.deltaTime);
        }
        
        //Find player and rotate toward it if no obtacles are in the way
        if (player != null && !obstacleTrans)
        {
            playerPosition = player.transform.position;
            Vector2 direc = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            direc.Normalize();

            float zAngle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 270;

            Quaternion desRotation = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desRotation, rotSpeed * Time.deltaTime);
        }

        transform.Translate(0, speed * Time.deltaTime, 0);

        //Keep track if avoiding obstacle
        if (obstacleTrans) hasObstacle = true;
        else hasObstacle = false;

        if(damageMan.health < 1)
        {
            DestroyMe();
        }

    }

    public void AddObstacle(GameObject newObstacle)
    {
        if (!obstacleTrans)
        {
            obstacleTrans = newObstacle.transform;
        }
    }

    public void RemoveObstacle()
    {
        if (obstacleTrans)
        {
            obstacleTrans = null;
        }
    }

    public void DestroyMe()
    {
        for (int i = 0; i < amountDebris; i++)
        {
            if (i == 0)
            {
                GameObject debris = Instantiate(exploder);
                debris.transform.position = transform.position; ;
            }

            if (i > 0 && i < amountDebris/4)
            {
                GameObject debris = Instantiate(debris2);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }

            if (i > amountDebris/4 && i < amountDebris / 2)
            {
                GameObject debris = Instantiate(debris2);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }

            else
            {
                GameObject debris = Instantiate(debris3);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }
        }

        gameObject.SetActive(false);
    }
}
