using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI currentCheckpointText;

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

        currentCheckpointText.text = $"Checkpoint {currentWaypoint.ToString()} | 35";
    }

    public void NextWaypoint()
    {
        waypoints[currentWaypoint].gameObject.SetActive(false);
        currentWaypoint++;
        waypoints[currentWaypoint].gameObject.SetActive(true);
    }
}
