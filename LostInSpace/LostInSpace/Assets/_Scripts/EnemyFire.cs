using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float range;
    public LayerMask mask;
    public float bulletTimer;
    public string objectTag;

    private float countDown;

	// Update is called once per frame
	void Update ()
    {
        //Use Ray to determine if player is in range to fire
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.up, range, mask);

        if (hit2D)
        {
            Debug.DrawLine(transform.position, hit2D.point, Color.red);
            if (countDown <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(objectTag);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);

                countDown = bulletTimer;
            }
        }

        countDown -= Time.deltaTime;
    }
}
