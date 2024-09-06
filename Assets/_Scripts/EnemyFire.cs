using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float bulletTimer;
    [SerializeField] private string objectTag;
    [SerializeField] private Transform bulletFirePoint;

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
                bullet.transform.position = bulletFirePoint.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);

                countDown = bulletTimer;
            }
        }

        countDown -= Time.deltaTime;
    }
}
