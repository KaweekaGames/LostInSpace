using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemyMovement : MonoBehaviour
{
    public float rotSpeed;
    public float speed;
    public bool hasObstacle;
    public int amountDebris;
    public GameObject debris1;
    public GameObject debris2;
    public GameObject debris3;
    public GameObject exploder;
    public List<string> rockTags;
    public float attackDistance;

    private GameObject player;
    private Vector2 playerPosition;
    private Transform obstacleTrans;
    private Vector2 obstaclePosition;
    private DamageManager damageMan;
    private float distanceFromPlayer;
    private bool playerInRange = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageMan = GetComponent<DamageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRangeCheck();

        //If present, move away from obstacle
        if (obstacleTrans != null)
        {
            obstaclePosition = obstacleTrans.position;
            Vector2 direc = new Vector2(obstaclePosition.x - transform.position.x, obstaclePosition.y - transform.position.y);
            direc.Normalize();

            float zAngle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 90;

            Quaternion desRotation = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desRotation, rotSpeed * Time.deltaTime);
        }

        //Find player and rotate toward it if no obtacles are in the way
        if (playerInRange && !obstacleTrans)
        {
            playerPosition = player.transform.position;
            Vector2 direc = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            direc.Normalize();

            float zAngle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg + 270;

            Quaternion desRotation = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desRotation, rotSpeed * Time.deltaTime);
        }

        transform.Translate(0, speed * Time.deltaTime, 0);

        //Keep track if avoiding obstacle
        if (obstacleTrans) hasObstacle = true;
        else hasObstacle = false;

        if (damageMan.health < 1)
        {
            DestroyMe();
        }

    }

    public void AddObstacle(GameObject newObstacle)
    {
        if (!obstacleTrans)
        {
            obstacleTrans = newObstacle.transform;
        }
    }

    public void RemoveObstacle()
    {
        if (obstacleTrans)
        {
            obstacleTrans = null;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageManager collisionDamageMan = collision.gameObject.GetComponent<DamageManager>();

        if (collisionDamageMan != null && collision.gameObject.tag != "Enemy")
        {

            if (rockTags.Contains(collision.gameObject.tag))
            {
                RockMovement rockMove = collision.gameObject.GetComponent<RockMovement>();
                rockMove.DestroyMe();
            }

            DestroyMe();
        }
    }

    private void PlayerRangeCheck()
    {
        if (player != null)
        {
            distanceFromPlayer = Mathf.Abs(player.transform.position.magnitude - transform.position.magnitude);

            if (distanceFromPlayer < attackDistance)
            {
                playerInRange = true;
            }
            else playerInRange = false;
        }      
    }
}
