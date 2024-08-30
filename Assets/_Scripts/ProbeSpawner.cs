using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject probe;
    [SerializeField] private WayPoint waypoint;
    [SerializeField] private int probeNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < probeNumber; i++) 
        {
            SpawnProbe();
        }
    }

    private void SpawnProbe()
    {
        Vector2 startingPostion = waypoint.GetStartingWaypoint();
        GameObject newProbe = Instantiate(probe);
        newProbe.transform.position = startingPostion;
    }


}
