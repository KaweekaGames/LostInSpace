using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector2 worldSize;
    [SerializeField] private float verticalSpacing;
    [SerializeField] private float horizontalSpacing;
    
    private List<Vector2> startingWaypoints = new List<Vector2>();
    private List<Vector2> waypoints = new List<Vector2>();
    private float verticalPos;
    private float horizontalPos;

    private void Awake()
    {
        verticalPos = (worldSize.y * 2) / verticalSpacing;
        horizontalPos = (worldSize.x * 2) / horizontalSpacing;
       
        for (float i = worldSize.x; i >= -worldSize.x; i = i - horizontalPos)
        {
            for (float j = worldSize.y; j >= -worldSize.y; j = j - verticalPos)
            {
                Vector2 newWaypoint = new Vector2(i, j);
                if (newWaypoint.magnitude >1)
                {
                    startingWaypoints.Add(newWaypoint);
                }
            }
        }

        foreach (Vector2 point in startingWaypoints)
        {
            waypoints.Add(point);
        }
    }

    public Vector2 GetNextWaypiont()
    {
        int randomWaypoint = Random.Range(0, waypoints.Count);
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
