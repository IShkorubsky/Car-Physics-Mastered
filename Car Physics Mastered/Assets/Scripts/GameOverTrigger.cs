using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("outOfBounds"))
        {
            Time.timeScale = 0;
            UIManager.Instance.GameOver();
        }
    }
}
