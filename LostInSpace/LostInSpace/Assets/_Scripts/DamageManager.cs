using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int hitPoints;
    public int health;

    void Awake()
    {
        health = hitPoints;
    }

    void OnEnable()
    {
        health = hitPoints;
    }

    public void Damage(int force)
    {
        health -= force;
    }
}
