using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Probe : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private float sensorRange;
    [SerializeField] private float tripTime;
    [SerializeField] private int amountDebris;
    [SerializeField] private GameObject debris1;
    [SerializeField] private GameObject debris2;
    [SerializeField] private GameObject debris3;
    [SerializeField] private GameObject exploder;

    private PlayerMovement player;
    private DamageManager damageMan;

    // Start is called before the first frame update
    void Start()
    {
      player = FindObjectOfType<PlayerMovement>();
      damageMan = gameObject.GetComponent<DamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);

        if (player != null) 
        {
            if (Mathf.Abs(player.transform.position.magnitude - transform.position.magnitude) < sensorRange) 
            {
                animator.speed += (2 * Time.deltaTime);
                Debug.Log("player is in range");
            }
        }

        if (animator.speed > tripTime) 
        {
            animator.SetTrigger("PlayerFound");
        }

        if (damageMan.health <= 0) 
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        for (int i = 0; i < amountDebris; i++)
        {
            if (i == 0)
            {
                GameObject debris = Instantiate(debris1);
                debris.transform.position = transform.position; ;
            }

            if (i > 0 && i < 4)
            {
                GameObject debris = Instantiate(debris2);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }

            else
            {
                GameObject debris = Instantiate(debris3);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }
        }

        GameObject explode = Instantiate(exploder, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Debug.Log("boom");
    }
}