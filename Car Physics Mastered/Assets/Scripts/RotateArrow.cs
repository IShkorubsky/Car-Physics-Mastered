using UnityEngine;

public class RotateArrow : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(WaypointManager.Instance.waypoints[WaypointManager.Instance.currentWaypoint]);
    }
}