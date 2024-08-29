using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int hitPoints = 40;
    public List<string> rockTags;
    public Shield shield;
    public GameObject exploder;
    public PlayerFire playerFire;
    public PlayerMovement playerMovement;

    private int health;
    private int damage;
    private RockMovement rockMove;
    private EnemyMovement enemyMove;

    void Awake()
    {
        health = hitPoints;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageManager damageMan = collision.gameObject.GetComponent<DamageManager>();
        
        if (damageMan != null)
        {
            damage = damageMan.hitPoints;

            if (shield.shieldEnabled)
            {
                if (shield.GetShieldStrength() > damage)
                {
                    shield.DrainShield(damageMan.hitPoints);
                }
                else 
                {
                    damage -= (int)shield.GetShieldStrength();
                    shield.DrainShield((int)shield.GetShieldStrength() + 1);
                    TakeDamage(damage);
                }
            }
            else TakeDamage(damage);

            if (rockTags.Contains(collision.gameObject.tag))
            {
                rockMove = collision.gameObject.GetComponent<RockMovement>();
                rockMove.DestroyMe();
            }

            if (collision.tag == "Enemy")
            {
                enemyMove = collision.gameObject.GetComponent<EnemyMovement>();
                enemyMove.DestroyMe();
            }

            if(collision.tag == "EnemyBullet")
            {
                collision.gameObject.SetActive(false);
            }
        }

    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= .85 * hitPoints)
        {
            print("damage shields");
            shield.EnableDamageState();
        }
        else if (health <= .7 * hitPoints)
        {
            print("damage guns");
            playerFire.EnableDamageState();
        }
        else if (health <= .55 * hitPoints)
        {
            print("damage drive");
            playerMovement.EnableDamageState();
        }
        else if (health <= .4 * hitPoints)
        {
            print("disable shields");
            shield.enabled = false;
        }
        else if (health <= .25 * hitPoints)
        {
            print("disable wing gun 1");
            playerFire.DisableGun(1);
        }
        else if (health <= .1 * hitPoints)
        {
            print("disable wing gun 2");
            playerFire.DisableGun(1);
        }
        
        if (health <= 0)
        {
            DestroyMe();
        }
    }

    void DestroyMe()
    {
        GameObject explode = Instantiate(exploder, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
