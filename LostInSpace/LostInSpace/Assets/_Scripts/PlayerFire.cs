using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public string objectTag;
    public List<GameObject> guns;

    //private float timer;
    //private int damageLevel = 2;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (GameObject obj in guns)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(objectTag);
                bullet.transform.position = obj.transform.position;
                bullet.transform.rotation = obj.transform.rotation;
                bullet.SetActive(true); 
            }
        }
	}

    public void DisableGun(int gun)
    {
        guns[gun].SetActive(false);
    }
}
