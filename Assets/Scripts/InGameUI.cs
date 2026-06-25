using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In-game UI controller with Home button
/// Add this to InGameCanvas
/// </summary>
public class InGameUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Text scoreText;
    public Button pauseButton;
    public Button homeButton;
    
    [Header("Home Button Settings")]
    public bool showHomeButton = true;
    
    void Start()
    {
        // Find score text if not assigned
        if (scoreText == null)
            scoreText = transform.Find("ScoreTextWhite")?.GetComponent<Text>();
        
        // Setup home button
        if (homeButton != null)
        {
            homeButton.gameObject.SetActive(showHomeButton);
            homeButton.onClick.AddListener(OnHomeButtonClick);
        }
        
        UpdateScore(0);
    }
    
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
    
    void OnHomeButtonClick()
    {
        // Confirm before going home
        if (Game_Manager.instance != null)
        {
            // Pause game
            if (!Game_Manager.IsPaused)
                Game_Manager.instance.Pause();
            
            // Show confirmation or go directly
            Game_Manager.instance.Home();
        }
    }
}
