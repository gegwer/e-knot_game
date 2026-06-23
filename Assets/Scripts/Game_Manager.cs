using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public int currentScore;

    public int BestScore { get; private set; }

    public GameObject InGameCanvas;
    public GameObject StartScreenCanvas;
    public GameObject DeadCanvas;
    public GameObject SettingsCanvas;

    public GameObject flappyBird;

    //propertys that cannot be changed by other classes
    public static bool IsPaused{ get; private set; }

    private Image pauseButtonImage;
    private Sprite pauseButtonSprite;
    private Sprite playButtonSprite;

    private bool isGameStarted = false;
    public bool IsGameStarted
    {
        get { return isGameStarted; }
        set
        {
            GenerateScenario.isGameStarted = value;
            FlappyBirdController.isGameStarted = value;
            isGameStarted = value;
        }
    }

    void Awake()
    {
        IsPaused = false;
        instance = this;

        BestScore = PlayerPrefs.GetInt("BestScore");
        CacheUiReferences();
        UpdatePauseButtonIcon();
    }

    public void Home()
    {
        IsGameStarted = false;
        if (GenerateScenario.instance != null)
            GenerateScenario.instance.CleanAllBackground();
        IsPaused = false;
        
        if (flappyBird != null)
        {
            FlappyBirdController controller = flappyBird.GetComponent<FlappyBirdController>();
            if (controller != null)
                controller.ResetBird();
        }

        if (DeadCanvas != null)
            DeadCanvas.SetActive(false);
        if (InGameCanvas != null)
            InGameCanvas.SetActive(false);
        if (SettingsCanvas != null)
            SettingsCanvas.SetActive(false);
        if (StartScreenCanvas != null)
            StartScreenCanvas.SetActive(true);

        if (flappyBird != null && flappyBird.transform.parent != null)
            flappyBird.transform.parent.position = new Vector3(0, -0.22f, -10);
        
        UpdatePauseButtonIcon();
    }


    public void StartGame()
    {
        currentScore = 0;
        IsPaused = false;
        
        if (flappyBird != null)
        {
            FlappyBirdController controller = flappyBird.GetComponent<FlappyBirdController>();
            if (controller != null)
                controller.Pause(false);
        }

        if (InGameCanvas != null)
        {
            Text scoreText = InGameCanvas.transform.Find("ScoreTextWhite")?.GetComponent<Text>();
            if (scoreText != null)
                scoreText.text = currentScore.ToString();
        }

        if (StartScreenCanvas != null)
            StartScreenCanvas.SetActive(false);
        if (SettingsCanvas != null)
            SettingsCanvas.SetActive(false);
        if (DeadCanvas != null)
            DeadCanvas.SetActive(false);
        if (InGameCanvas != null)
            InGameCanvas.SetActive(true);

        IsGameStarted = true;
        UpdatePauseButtonIcon();
    }

    public void AddScorePoint()
    {
        currentScore++;
        if (InGameCanvas != null)
        {
            Text scoreText = InGameCanvas.transform.Find("ScoreTextWhite")?.GetComponent<Text>();
            if (scoreText != null)
                scoreText.text = currentScore.ToString();
        }
    }

    public void Pause()
    {
        if (flappyBird == null)
            return;

        FlappyBirdController controller = flappyBird.GetComponent<FlappyBirdController>();
        if (controller == null)
            return;

        if (IsPaused)
        {
            IsPaused = false;
            controller.Pause(false);
        }
        else
        {
            IsPaused = true;
            controller.Pause(true);
            
            // Safe vibration call
            try
            {
                Handheld.Vibrate();
            }
            catch (System.Exception)
            {
                // Vibration not supported on this platform
            }
        }

        UpdatePauseButtonIcon();
    }

    public void TurnOnSettingMenu()
    {
        if (StartScreenCanvas != null)
            StartScreenCanvas.SetActive(false);

        if (SettingsCanvas == null)
            SettingsCanvas = FindSettingsCanvas();

        if (SettingsCanvas != null)
            SettingsCanvas.SetActive(true);

        Pause();
    }

    public void Die()
    {
        if (InGameCanvas != null)
            InGameCanvas.SetActive(false);
        if (DeadCanvas != null)
            DeadCanvas.SetActive(true);

        if (currentScore > BestScore)
            PlayerPrefs.SetInt("BestScore", currentScore);

        BestScore = PlayerPrefs.GetInt("BestScore");
        
        if (DeadCanvas != null)
        {
            DeadCanvas_Manager deadManager = DeadCanvas.GetComponent<DeadCanvas_Manager>();
            if (deadManager != null)
                deadManager.SetScoreValues(currentScore, BestScore);
        }

        currentScore = 0;
        UpdatePauseButtonIcon();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void CacheUiReferences()
    {
        if (InGameCanvas != null)
        {
            Transform pauseButton = InGameCanvas.transform.Find("PauseButton");
            if (pauseButton != null)
                pauseButtonImage = pauseButton.GetComponent<Image>();

            if (pauseButtonImage != null)
                pauseButtonSprite = pauseButtonImage.sprite;
        }

        if (StartScreenCanvas != null)
        {
            Transform playButton = StartScreenCanvas.transform.Find("PlayButton");
            if (playButton != null)
            {
                Image playButtonImage = playButton.GetComponent<Image>();
                if (playButtonImage != null)
                    playButtonSprite = playButtonImage.sprite;
            }
        }
    }

    private void UpdatePauseButtonIcon()
    {
        if (pauseButtonImage == null)
            CacheUiReferences();

        if (pauseButtonImage == null)
            return;

        Sprite targetSprite = IsPaused ? playButtonSprite : pauseButtonSprite;
        if (targetSprite != null)
            pauseButtonImage.sprite = targetSprite;
    }

    private GameObject FindSettingsCanvas()
    {
        Settings_Manager[] settingsManagers = Resources.FindObjectsOfTypeAll<Settings_Manager>();
        for (int i = 0; i < settingsManagers.Length; i++)
        {
            if (settingsManagers[i] != null && settingsManagers[i].gameObject.scene.IsValid())
                return settingsManagers[i].gameObject;
        }

        return null;
    }
}
