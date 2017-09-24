using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public string tag;
    public List<GameObject> guns;

    private float timer;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            foreach (GameObject obj in guns)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(tag);
                bullet.transform.position = obj.transform.position;
                bullet.transform.rotation = obj.transform.rotation;
                bullet.SetActive(true); 
            }
        }
	}
}
