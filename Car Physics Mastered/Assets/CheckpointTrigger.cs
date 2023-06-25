using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (WaypointManager.Instance.currentWaypoint !=35)
            {
                WaypointManager.Instance.NextWaypoint();
            }
        }
    }
}