using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollector : MonoBehaviour {

	public List<string> tags;

	private RockSpawner rockSpawner;

	// Use this for initialization
	void Start () 
	{
		rockSpawner = GameObject.FindObjectOfType<RockSpawner> ();
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (tags.Contains (collision.gameObject.tag)) 
		{
			collision.gameObject.SetActive (false);
			rockSpawner.rockQ--;
		}
	}
}
