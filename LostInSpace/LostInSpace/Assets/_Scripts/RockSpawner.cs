using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public int totalNumberOfRocks;
    public float spaceAway;

    public int rockQ;
    private Transform playerTrans;

	// Use this for initialization
	void Start ()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SpawnRock()
    {
        int number = Random.Range(0, 26);

        if(number == 0)
        {
            GameObject obj = ObjectPooler.SharedInstance.GetPooledObject("MediumRock1");
            if(obj != null)
            {
                float xPos = Random.Range(playerTrans.position.x - spaceAway, playerTrans.position.x + spaceAway);
                obj.transform.position = new Vector2()
            }
        }
    }
}
