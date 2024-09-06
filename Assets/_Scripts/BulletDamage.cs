using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int power;

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageManager damageScript = collision.GetComponent<DamageManager>();

        if (damageScript != null)
        {
            damageScript.Damage(power);
            gameObject.SetActive(false);
        }
        else if (collision.tag != "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
