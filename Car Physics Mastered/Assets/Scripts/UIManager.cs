using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI victoryScreenText;
    public static UIManager Instance { get; private set; }

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

    private void Start()
    {
        Time.timeScale = 0;
        Timer.Instance.currentTime = 20;
        Timer.Instance.stopTimer = false;
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        inGamePanel.SetActive(false);
        startGamePanel.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startGamePanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
    
    public void Victory()
    {
        Timer.Instance.stopTimer = true;
        victoryScreenText.text = $"You managed to complete the track!\nTime left :{Timer.Instance.currentTime:F1}s";
        inGamePanel.SetActive(false);
        victoryPanel.SetActive(true);
    }

    public void GameOver()
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
