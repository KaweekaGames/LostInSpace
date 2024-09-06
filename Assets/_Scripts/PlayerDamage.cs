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
            damageMan.Damage(hitPoints);

            if (shield.shieldEnabled && shield.GetShieldStrength() > 0)
            {
                if (shield.GetShieldStrength() > damage)
                {
                    shield.DrainShield(damage);
                }
                else 
                {
                    damage -= (int)shield.GetShieldStrength();
                    shield.DrainShield((int)shield.GetShieldStrength() + 1);
                    TakeDamage(damage);
                }
            }
            else TakeDamage(damage);

            if (collision.tag == "EnemyBullet")
            {
                collision.gameObject.SetActive(false);
            }

            //if (rockTags.Contains(collision.gameObject.tag))
            //{
            //    rockMove = collision.gameObject.GetComponent<RockMovement>();
            //    //rockMove.DestroyMe();
            //}

            //if (collision.tag == "Enemy")
            //{
            //    enemyMove = collision.gameObject.GetComponent<EnemyMovement>();
            //    enemyMove.DestroyMe();
            //}


        }

    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= .85 * hitPoints && health >.7 * hitPoints && !shield.shieldDamaged)
        {
            print("damage shields");
            shield.EnableDamageState();
        }
        else if (health <= .7 * hitPoints && health > .55 * hitPoints && !playerFire.gunsDamaged)
        {
            print("damage guns");
            playerFire.EnableDamageState();
        }
        else if (health <= .55 * hitPoints && health > .4 * hitPoints && !playerMovement.driveDamaged)
        {
            print("damage drive");
            playerMovement.EnableDamageState();
        }
        else if (health <= .4 * hitPoints && health > .25 * hitPoints && shield.enabled == true)
        {
            print("disable shields");
            shield.enabled = false;
        }
        else if (health <= .25 * hitPoints && health > .1 * hitPoints && playerFire.guns.Count > 2)
        {
            print("disable wing gun 1");
            playerFire.DisableGun();
        }
        else if (health <= .1 * hitPoints && health > 0 && playerFire.guns.Count > 1)
        {
            print("disable wing gun 2");
            playerFire.DisableGun();
        }

        Debug.Log(health);
        
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
