using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelayDestroy : MonoBehaviour
{
    public float timeDelay;

	void Update ()
    {
        timeDelay -= Time.deltaTime;

        if(timeDelay < 0)
        {
            Destroy(this);
        }
	}
}
