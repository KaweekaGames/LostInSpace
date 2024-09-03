using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float shieldStrengthMax;
    public SpriteRenderer spriteRend;
    public CircleCollider2D circleColl;
    public bool shieldEnabled = true;
    public float shieldRecoverSpeed;
    public Slider shieldSlider;
    public float shieldDownTime =5f;
    public float shieldDamageRedutionRate;
    public Animator animator;

    private float timer = 0;
    private bool flashing = false;
    private float shieldStrength;

    // Use this for initialization
    void Awake ()
    {
        //spriteRend.enabled = false;
        shieldStrength = shieldStrengthMax;
	}

    void Start()
    {
        shieldSlider.maxValue = shieldStrengthMax;
        animator.SetBool("ShowShield", false);
    }
    // Update is called once per frame
    void Update ()
    {
        PowerShield();

        if (timer > 0) 
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            animator.SetBool("ShowShield", false);
        }

        if (!shieldEnabled || shieldStrength < 0)
        {
            circleColl.enabled = false;
        }
        else { circleColl.enabled = true; }

        shieldSlider.value = shieldStrength;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("shield log");
    }

    public void DrainShield(int hit)
    {
        shieldStrength -= hit;
        Debug.Log("shield strength " + shieldStrength);
        animator.SetBool("ShowShield", true);

        if (shieldStrength > 0)
        {
            timer = .5f;
        }

        else
        {
            timer = .7f;
            shieldStrength -= shieldDownTime;
        } 
    }

    public void PowerShield()
    {
        if (shieldStrength < shieldStrengthMax && shieldEnabled)
        {
            shieldStrength += Time.deltaTime * shieldRecoverSpeed; 
        }
    }

    public float GetShieldStrength()
    {
        return shieldStrength;
    }

    public void EnableDamageState()
    {
        shieldStrengthMax = shieldStrengthMax * shieldDamageRedutionRate;
        shieldRecoverSpeed = shieldRecoverSpeed * shieldDamageRedutionRate;
    }
}
