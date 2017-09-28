using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public int totalNumberOfRocks;
    public float spaceAwayMin;
	public float spaceAwayMax;
    public int rockQ;

    private Transform playerTrans;
	private string tag;
	private float posOrNegX;
	private float posOrNegY;
	private float spaceAwayX;
	private float tempSpaceAwayX;
	private float spaceAwayY;
	private float tempSpaceAwayY;
	private int alternate;

	// Use this for initialization
	void Start ()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
		rockQ = 0;
		alternate = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (rockQ < totalNumberOfRocks) 
		{
			SpawnRock ();
			rockQ++;
		}
			
	}

	public void CountRocks()
	{
		rockQ--;
	}

    void SpawnRock()
    {
		if (alternate == 1) {
			posOrNegX = Mathf.Pow (-1, Random.Range (1, 3));
			tempSpaceAwayX = Random.Range (spaceAwayMin, spaceAwayMax);
			spaceAwayX = playerTrans.position.x + tempSpaceAwayX * posOrNegX;
			spaceAwayY = Random.Range (playerTrans.position.y - spaceAwayMax, playerTrans.position.y + spaceAwayMax);
		} else 
		{
			spaceAwayX = Random.Range (playerTrans.position.x - spaceAwayMax, playerTrans.position.x + spaceAwayMax);
			posOrNegY = Mathf.Pow (-1, Random.Range (1, 3));
			tempSpaceAwayY = Random.Range (spaceAwayMin, spaceAwayMax);
			spaceAwayY = playerTrans.position.y + tempSpaceAwayY * posOrNegY;
		}

		int number = Random.Range(0, 26);

		if (number == 0) 
		{
			tag = "MediumRock1";
		} 
		else if (number == 1) 
		{
			tag = "MediumRock2";
		}	
		else if (number == 2) 
		{
			tag = "MediumRock3";
		}
		else if (number == 3) 
		{
			tag = "MediumRock4";
		}
		else if (number == 4) 
		{
			tag = "MediumRock5";
		}
		else if (number > 4 && number < 9) 
		{
			tag = "LargeRock1";
		}
		else if (number > 8 && number < 13) 
		{
			tag = "LargeRock2";
		}
		else if (number > 12 && number < 18) 
		{
			tag = "LargeRock3";
		}
		else if (number > 17 && number < 23) 
		{
			tag = "LargeRock4";
		}
		else if (number > 22) 
		{
			tag = "LargeRock5";
		}

		GameObject obj = ObjectPooler.SharedInstance.GetPooledObject(tag);
		if(obj != null)
		{
			RockMovement rockMov = obj.GetComponent<RockMovement> ();

			obj.transform.position = new Vector2 (spaceAwayX, spaceAwayY);
			rockMov.destination = new Vector2 (spaceAwayX, spaceAwayY - 1000);
			obj.SetActive (true);

			alternate = alternate * -1;
		}
    }
}
