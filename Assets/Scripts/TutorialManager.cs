using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tutorial Manager - shows in-game instructions for first-time players
/// </summary>
public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [Header("Tutorial UI")]
    public GameObject tutorialPanel;
    public Text tutorialText;
    public Image handIcon;

    [Header("Tutorial Settings")]
    public bool showTutorialOnStart = true;
    public float handAnimationSpeed = 1f;

    private bool tutorialShown = false;
    private bool tutorialActive = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Check if tutorial was already shown
        tutorialShown = PlayerPrefs.GetInt("TutorialShown", 0) == 1;
    }

    void Start()
    {
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);

        if (!tutorialShown && showTutorialOnStart)
        {
            StartCoroutine(ShowTutorialAfterDelay(0.5f));
        }
    }

    void Update()
    {
        if (tutorialActive && handIcon != null)
        {
            // Animate hand icon up and down
            float yPos = Mathf.Sin(Time.time * handAnimationSpeed) * 20f;
            handIcon.transform.localPosition = new Vector3(0, yPos, 0);
        }
    }

    IEnumerator ShowTutorialAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowTutorial();
    }

    public void ShowTutorial()
    {
        if (tutorialPanel == null)
            return;

        tutorialActive = true;
        tutorialPanel.SetActive(true);

        // Set tutorial text based on platform
        if (tutorialText != null)
        {
            if (Application.isMobilePlatform)
                tutorialText.text = "TAP TO FLY\n\nTap anywhere on the screen to make the bird fly!\nAvoid the pipes and try to get the highest score!";
            else
                tutorialText.text = "CLICK OR PRESS SPACE TO FLY\n\nClick with mouse or press Space to make the bird fly!\nAvoid the pipes and try to get the highest score!";
        }

        // Mark tutorial as shown
        tutorialShown = true;
        PlayerPrefs.SetInt("TutorialShown", 1);
        PlayerPrefs.Save();
    }

    public void HideTutorial()
    {
        tutorialActive = false;
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);

        // Start the game automatically after closing tutorial
        if (Game_Manager.instance != null)
            Game_Manager.instance.StartGame();
    }

    public void ResetTutorial()
    {
        tutorialShown = false;
        PlayerPrefs.SetInt("TutorialShown", 0);
        PlayerPrefs.Save();
    }

    // Called when player taps during tutorial
    public void OnTutorialTap()
    {
        HideTutorial();
    }
}
