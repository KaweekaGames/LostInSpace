using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRockDamage : MonoBehaviour
{
    [SerializeField] private int power;

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageManager damageScript = collision.GetComponent<DamageManager>();

        if (damageScript != null)
        {
            damageScript.Damage(power);
        }
    }
}
