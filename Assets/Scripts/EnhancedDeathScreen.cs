using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enhanced Death Screen with animations and better visuals
/// </summary>
public class EnhancedDeathScreen : MonoBehaviour
{
    [Header("References")]
    public Text finalScoreText;
    public Text bestScoreText;
    public Text newRecordText;
    public GameObject panel;
    public Button retryButton;
    public Button homeButton;

    [Header("Animation Settings")]
    public float panelSlideTime = 0.5f;
    public float scoreCountTime = 1f;
    public AnimationCurve slideEase = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private int displayScore = 0;
    private int displayBestScore = 0;
    private bool isNewRecord = false;

    void OnEnable()
    {
        StartCoroutine(ShowDeathScreenAnimation());
    }

    public void SetScores(int currentScore, int bestScore)
    {
        displayScore = currentScore;
        displayBestScore = bestScore;
        isNewRecord = currentScore >= bestScore && currentScore > 0;
        
        if (newRecordText != null)
            newRecordText.gameObject.SetActive(isNewRecord);
    }

    IEnumerator ShowDeathScreenAnimation()
    {
        // Hide everything initially
        if (panel != null)
        {
            RectTransform rect = panel.GetComponent<RectTransform>();
            if (rect != null)
            {
                Vector2 startPos = new Vector2(0, 2000);
                Vector2 endPos = Vector2.zero;
                rect.anchoredPosition = startPos;

                // Slide in animation
                float elapsed = 0f;
                while (elapsed < panelSlideTime)
                {
                    elapsed += Time.unscaledDeltaTime;
                    float t = slideEase.Evaluate(elapsed / panelSlideTime);
                    rect.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
                    yield return null;
                }
                rect.anchoredPosition = endPos;
            }
        }

        // Animate score counting
        yield return new WaitForSecondsRealtime(0.2f);
        yield return StartCoroutine(AnimateScoreCounting());

        // Show new record with pulse
        if (isNewRecord && newRecordText != null)
        {
            newRecordText.gameObject.SetActive(true);
            StartCoroutine(PulseNewRecord());
        }

        // Animate buttons
        yield return new WaitForSecondsRealtime(0.1f);
        AnimateButton(retryButton);
        yield return new WaitForSecondsRealtime(0.1f);
        AnimateButton(homeButton);
    }

    IEnumerator AnimateScoreCounting()
    {
        float elapsed = 0f;
        int startScore = 0;

        while (elapsed < scoreCountTime)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / scoreCountTime;
            
            int currentDisplay = (int)Mathf.Lerp(startScore, displayScore, t);
            if (finalScoreText != null)
                finalScoreText.text = currentDisplay.ToString();

            int currentBestDisplay = (int)Mathf.Lerp(startScore, displayBestScore, t);
            if (bestScoreText != null)
                bestScoreText.text = currentBestDisplay.ToString();

            yield return null;
        }

        if (finalScoreText != null)
            finalScoreText.text = displayScore.ToString();
        
        if (bestScoreText != null)
            bestScoreText.text = displayBestScore.ToString();
    }

    IEnumerator PulseNewRecord()
    {
        if (newRecordText == null) yield break;

        Vector3 originalScale = newRecordText.transform.localScale;
        
        while (newRecordText.gameObject.activeInHierarchy)
        {
            float scale = 1f + Mathf.Sin(Time.unscaledTime * 3f) * 0.15f;
            newRecordText.transform.localScale = originalScale * scale;
            yield return null;
        }

        newRecordText.transform.localScale = originalScale;
    }

    void AnimateButton(Button button)
    {
        if (button == null) return;

        StartCoroutine(ButtonPopAnimation(button.gameObject));
    }

    IEnumerator ButtonPopAnimation(GameObject button)
    {
        Vector3 originalScale = button.transform.localScale;
        button.transform.localScale = Vector3.zero;

        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / duration;
            
            // Overshoot effect
            float scale = Mathf.Sin(t * Mathf.PI * 0.5f) * 1.2f;
            if (t > 0.7f)
                scale = Mathf.Lerp(1.2f, 1f, (t - 0.7f) / 0.3f);
            
            button.transform.localScale = originalScale * scale;
            yield return null;
        }

        button.transform.localScale = originalScale;
    }
}
