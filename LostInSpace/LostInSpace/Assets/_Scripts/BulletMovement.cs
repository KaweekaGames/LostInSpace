﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public float deathTimer;

    private float countDown;
    private PlayerMovement playerMov;
    private float newSpeed;

    void Awake()
    {
        countDown = deathTimer;
    }

    void Start()
    {
        SetSpeed();
    }

    void OnEnable()
    {
        SetSpeed();
    }


    // Update is called once per frame
    void Update()
    {
        newSpeed += Time.deltaTime;

        transform.Translate(0, newSpeed * Time.deltaTime, 0);

        countDown -= Time.deltaTime;

        if (countDown < 0)
        {
            countDown = deathTimer;
            gameObject.SetActive(false);
        }
    }

    void SetSpeed()
    {
        newSpeed = speed;
    }
}
