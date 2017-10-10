using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public List<string> rockTags;
    public Shield shield;

    private RockMovement rockMove;
    private EnemyMovement enemyMove;

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

    }
}
