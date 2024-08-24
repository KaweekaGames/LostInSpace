using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float deathTimer;

    private float countDown;
    private SpriteRenderer spriteRen;

    void Awake()
    {
        speed = Random.Range(speed/4, speed);
        deathTimer = Random.Range(.3f, deathTimer);
        countDown = deathTimer;
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, spriteRen.color.a - (Time.deltaTime/(1+speed))); 

        countDown -= Time.deltaTime;

        if(countDown < 0)
        {
            countDown = deathTimer;
            gameObject.SetActive(false);
        }
	}
}
