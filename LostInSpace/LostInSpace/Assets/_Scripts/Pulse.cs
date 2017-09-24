using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float flashTime;
    public float minTransparency;

    private SpriteRenderer spriteRen;
    private float timer;
    private bool dim;

	// Use this for initialization
	void Start ()
    {
        spriteRen = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer <= 0)
        {
            dim = false;
        }

        if (timer > flashTime)
        {
            dim = true;
        }

        if (!dim)
        {
            timer += Time.deltaTime;
            spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, (1 - minTransparency) * timer / flashTime + minTransparency);
        }
        else
        {
            timer -= Time.deltaTime;
            spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, (1 - minTransparency) * timer / flashTime + minTransparency);
        }
	}
}
