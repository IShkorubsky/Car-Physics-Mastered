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
                Timer.Instance.AddTime();
            }
            else if (WaypointManager.Instance.currentWaypoint >= 35)
            {
                Time.timeScale = 0;
                UIManager.Instance.Victory();
            }
        }
    }
}