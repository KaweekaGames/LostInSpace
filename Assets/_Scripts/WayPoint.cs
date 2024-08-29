using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector2[] waypoints;
    private List<Vector2> startingWaypoints = new List<Vector2>();

    private void Awake()
    {
        for (int i = 0; i < waypoints.Length; i++) 
        {  
            startingWaypoints.Add(waypoints[i]);
        }
    }

    public Vector2 GetNextWaypiont()
    {
        int randomWaypoint = Random.Range(0, waypoints.Length);
        Vector2 nextWaypoint = waypoints[randomWaypoint];
     
        return nextWaypoint;
    }

    public Vector2 GetStartingWaypoint()
    {
        int randomWaypoint = Random.Range(0, startingWaypoints.Count);
        Vector2 startingWaypoint = startingWaypoints[randomWaypoint];
        startingWaypoints.RemoveAt(randomWaypoint);

        return startingWaypoint;
    }
}
