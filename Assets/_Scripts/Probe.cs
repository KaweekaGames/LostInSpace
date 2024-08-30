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

    private PlayerMovement player;
    
    // Start is called before the first frame update
    void Start()
    {
      player = FindObjectOfType<PlayerMovement>();
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
    }
}