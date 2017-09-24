using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    public string tag;
    public float spawnTimer;
    public bool canSpawn;

    private float countDown;

    void Start()
    {
        countDown = spawnTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        if (canSpawn)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }

            if (countDown <= 0)
            {
                GameObject child = ObjectPooler.SharedInstance.GetPooledObject(tag);
                if (child != null)
                {
                    child.transform.position = transform.position;
                    child.transform.rotation = transform.rotation;
                    child.SetActive(true);
                }

                countDown = spawnTimer;
            } 
        }
	}
}
