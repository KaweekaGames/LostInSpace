using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour {

    public string objectTag;
    public List<GameObject> guns;
    public float heatCapacity;
    public Slider heatSlider;

    private float heatBuildUp = 0;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1") && heatBuildUp < heatCapacity)
        {
            
            foreach (GameObject obj in guns)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(objectTag);
                bullet.transform.position = obj.transform.position;
                bullet.transform.rotation = obj.transform.rotation;
                bullet.SetActive(true);

                heatBuildUp += .25f;
            }
        }

        if (heatBuildUp >0)
        {
            heatBuildUp -= Time.deltaTime; 
        }

        heatSlider.value = Mathf.Lerp(heatSlider.value, Mathf.Clamp(heatBuildUp / heatCapacity, 0, 1), .07f);

	}

    public void DisableGun(int gun)
    {
        guns[gun].SetActive(false);
    }
}
