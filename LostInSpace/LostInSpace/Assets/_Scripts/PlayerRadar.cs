using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRadar : MonoBehaviour
{
    public Button button;

    private Transform jumpTrans;
    private float newPos;
    private float oldPos;

	// Use this for initialization
	void Start ()
    {
        jumpTrans = GameObject.FindGameObjectWithTag("Jump").transform;
        oldPos = Mathf.Sqrt(Mathf.Pow((jumpTrans.position.x - transform.position.x),2) + Mathf.Pow((jumpTrans.position.y - transform.position.y), 2));
    }
	
	// Update is called once per frame
	void Update ()
    {
        newPos = Mathf.Sqrt(Mathf.Pow((jumpTrans.position.x - transform.position.x), 2) + Mathf.Pow((jumpTrans.position.y - transform.position.y), 2));

        if (newPos < oldPos)
        {
            button.image.color = Color.green;
        }
        else button.image.color = Color.red;


        oldPos = newPos;
	}
}
