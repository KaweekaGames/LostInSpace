using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int hitPoints = 3;
    public List<string> rockTags;
    public Shield shield;
    public GameObject exploder;

    private int health;
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
            if (shield.shieldEnabled)
            {
                shield.DrainShield(damageMan.hitPoints);
            }
            else TakeDamage(damageMan.hitPoints);

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
        }

        if (collision.tag == "PowerUp")
        {
            shield.PowerShield();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if(health == 2)
        {
            print("loose first wing");
        }
        if (health == 1)
        {
            print("loose second wing");
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
