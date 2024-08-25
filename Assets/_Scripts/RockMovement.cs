using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float rotSpeed;
    public float fallingSpeed;
    public bool clockwise;
    public Vector2 destination;
    public GameObject debris1;
    public GameObject debris2;
    public GameObject debris3;
    public int amountDebris;
    public float maxOffset;

    private RockSpawner rockSpawn;
    private DamageManager damageMan;

    void Start()
    {
        rockSpawn = FindObjectOfType<RockSpawner>();
        damageMan = gameObject.GetComponent<DamageManager>();
        rotSpeed = rotSpeed * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, fallingSpeed * Time.deltaTime);

        if (clockwise)
        {
            transform.Rotate(0, 0, 1 * rotSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -1 * rotSpeed * Time.deltaTime);
        }

        if(damageMan.health <= 0)
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        for(int i = 0; i < amountDebris; i++)
        {
            if(i == 0)
            {
                GameObject debris = Instantiate(debris1);
                debris.transform.position = transform.position; ;
            }

            if(i > 0 && i < 4)
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

        gameObject.SetActive(false);
        rockSpawn.rockQ--;
    }
}
