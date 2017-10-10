using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollector : MonoBehaviour {

	public List<string> tags;

	private RockMovement rockMove;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (tags.Contains (collision.gameObject.tag)) 
		{
			rockMove = collision.gameObject.GetComponent<RockMovement>();
            rockMove.DestroyMe();
		}
	}
}
