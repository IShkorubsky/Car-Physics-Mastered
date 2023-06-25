using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    
    public float currentTime;
    public bool stopTimer;
    
    [SerializeField] private bool countDown;
    
    public static Timer Instance { get; private set; }
    
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
        if (!stopTimer)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("F1");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    public void AddTime()
    {
        currentTime += 2.5f;
    }
}
