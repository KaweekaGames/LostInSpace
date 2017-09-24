using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public float transitionSpeed;

    private GameObject player;
    private Transform playerTrans;
    private float newX;
    private float newY;
    private Vector3 newPos;

    /// Use this for initialization
    void Awake()
    {

        Camera camera = gameObject.GetComponent<Camera>();

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            Vector3 playerPos = playerTrans.position;
            float Zangle = playerTrans.eulerAngles.z;
            Vector3 oldPos = transform.position;

            if (Zangle >= 0 && Zangle < 90f)
            {
                newX = -(offsetX * Zangle / 90f);
                newY = (offsetY - (offsetY * Zangle / 90f));
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 90f && Zangle < 180f)
            {
                newX = -(offsetX - (offsetX * (Zangle - 90f) / 90f));
                newY = -(offsetY * (Zangle - 90f) / 90f);
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 180f && Zangle < 270f)
            {
                newX = (offsetX * (Zangle - 180f) / 90f);
                newY = -(offsetY - (offsetY * (Zangle - 180f) / 90f));
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 270f && Zangle < 360f)
            {
                newX = (offsetX - (offsetX * (Zangle - 270f) / 90f));
                newY = (offsetY * (Zangle - 270f) / 90f);
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            transform.position = newPos;
        }
    }
}
