using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private int amountDebris;
    [SerializeField] private GameObject debris1;
    [SerializeField] private GameObject debris2;
    [SerializeField] private GameObject debris3;
    [SerializeField] private GameObject exploder;

    private GameObject player;
    private Vector2 playerPosition;
    private DamageManager damageMan;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        damageMan = GetComponent<DamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find player and rotate toward it
        if (player != null)
        {
            playerPosition = player.transform.position;
            Vector2 direc = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            direc.Normalize();

            float zAngle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 270;

            Quaternion desRotation = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desRotation, rotSpeed * Time.deltaTime);
        }

        //Detroy if health is <= 0
        if (damageMan.health < 1)
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
                GameObject debris = Instantiate(exploder);
                debris.transform.position = transform.position; ;
            }

            if (i > 0 && i < amountDebris / 4)
            {
                GameObject debris = Instantiate(debris2);
                debris.transform.position = transform.position;
                debris.transform.Rotate(0, 0, Random.Range(0, 360));
            }

            if (i > amountDebris / 4 && i < amountDebris / 2)
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
    }
}
