using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float deathTimer;

    private float countDown;

    void Awake()
    {
        countDown = deathTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        countDown -= Time.deltaTime;

        if(countDown < 0)
        {
            countDown = deathTimer;
            gameObject.SetActive(false);
        }
	}
}
