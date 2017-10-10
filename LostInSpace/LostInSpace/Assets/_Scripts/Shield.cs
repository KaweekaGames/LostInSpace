using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldStrengthMax;
    public SpriteRenderer spriteRend;
    public CircleCollider2D circleColl;
    public bool shieldEnabled;

    private float timer = 0;
    private bool flashing;
    private int shieldStrength;

    // Use this for initialization
    void Awake ()
    {
        spriteRend.enabled = false;
        shieldStrength = shieldStrengthMax;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0 && flashing == false)
        {
            timer -= Time.deltaTime;
            spriteRend.enabled = true;
        }

        if(timer <= 0 && flashing == false)
        {
            spriteRend.enabled = false;
        }

        if(flashing == true)
        {
            timer -= Time.deltaTime;

            if (timer > .4f)
            {
                spriteRend.enabled = true;
            }

            if(timer <=.4f && timer > .3f)
            {
                spriteRend.enabled = false;
            }

            if (timer <= .3f && timer > .2f)
            {
                spriteRend.enabled = true;
            }

            if (timer <= .2f && timer > .1f)
            {
                spriteRend.enabled = false;
            }

            if (timer <= .1f && timer > 0)
            {
                spriteRend.enabled = true;
            }

            if (timer <= 0)
            {
                spriteRend.enabled = false;
                flashing = false;
            }
        }

        if (!shieldEnabled)
        {
            circleColl.enabled = false;
        }
	}

    public void DrainShield(int hit)
    {
        if (shieldStrength > 0)
        {
            shieldStrength -= hit;

            if (shieldStrength > 0)
            {
                timer = .5f;
            }

            else
            {
                timer = .7f;
                flashing = true;
                shieldEnabled = false;
                shieldStrength = 0;
            } 
        }
    }

    public void PowerShield()
    {
        if (shieldStrength < shieldStrengthMax)
        {
            shieldStrength += 1; 
        }
    }
}
