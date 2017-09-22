using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject background;
    public int sizeY;
    public int sizeX;

    private Transform playerTrans;
    private List<GameObject> backgroundObjects = new List<GameObject>();
    private Vector2 startPosition;
    private SpriteRenderer spriteRenderer;
    private int regenerateFactor;

    // Use this for initialization
    void Start ()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        startPosition = new Vector2(transform.position.x - (sizeX / 2 * spriteRenderer.bounds.size.x), transform.position.y - (sizeY / 2 * spriteRenderer.bounds.size.y));
        regenerateFactor = sizeX - 3;

        for (int x = 0; x < sizeX; x++)
        {
            for(int y = 0; y < sizeY; y++)
            {
                Vector3 newPosition = new Vector3(startPosition.x + spriteRenderer.bounds.size.x * x, startPosition.y + spriteRenderer.bounds.size.y * y, 0);
                int z = Random.Range(0, 4);
                GameObject bgObject = Instantiate(background, newPosition, Quaternion.Euler(0, 0, (90 * z)));
                backgroundObjects.Add(bgObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		foreach(GameObject n in backgroundObjects)
        {
            if(n.transform.position.x > (playerTrans.position.x + spriteRenderer.bounds.size.x * regenerateFactor))
            {
                n.transform.position = new Vector2(n.transform.position.x - spriteRenderer.bounds.size.x * sizeX, n.transform.position.y);
            }

            if (n.transform.position.x < (playerTrans.position.x - spriteRenderer.bounds.size.x * regenerateFactor))
            {
                n.transform.position = new Vector2(n.transform.position.x + spriteRenderer.bounds.size.x * sizeX, n.transform.position.y);
            }

            if (n.transform.position.y > (playerTrans.position.y + spriteRenderer.bounds.size.y * regenerateFactor))
            {
                n.transform.position = new Vector2(n.transform.position.x, n.transform.position.y - spriteRenderer.bounds.size.y * sizeY);
            }

            if (n.transform.position.y < (playerTrans.position.y - spriteRenderer.bounds.size.y * regenerateFactor))
            {
                n.transform.position = new Vector2(n.transform.position.x, n.transform.position.y + spriteRenderer.bounds.size.y * sizeY);
            }
        }
	}
}
