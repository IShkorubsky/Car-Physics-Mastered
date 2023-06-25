using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance { get; private set; }

    public List<Transform> waypoints;
    public int currentWaypoint;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Update()
    {
        if (currentWaypoint == 35)
        {
            Debug.Log("Victory");
        }
    }

    public void NextWaypoint()
    {
        waypoints[currentWaypoint].gameObject.SetActive(false);
        currentWaypoint++;
        waypoints[currentWaypoint].gameObject.SetActive(true);
    }
}
