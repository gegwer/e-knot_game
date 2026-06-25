using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enhanced Start Screen with animations
/// </summary>
public class EnhancedStartScreen : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject logo;
    public Button playButton;
    public Button settingsButton;
    public Text tapToStartText;
    
    [Header("Animation")]
    public float logoFloatSpeed = 1f;
    public float logoFloatAmount = 20f;
    public float tapTextBlinkSpeed = 2f;
    
    private Vector3 logoOriginalPos;
    private Color tapTextOriginalColor;

    void Start()
    {
        if (logo != null)
            logoOriginalPos = logo.transform.localPosition;
        
        if (tapToStartText != null)
            tapTextOriginalColor = tapToStartText.color;
        
        StartCoroutine(AnimateScreen());
    }

    void Update()
    {
        // Float logo animation
        if (logo != null)
        {
            float yOffset = Mathf.Sin(Time.time * logoFloatSpeed) * logoFloatAmount;
            logo.transform.localPosition = logoOriginalPos + new Vector3(0, yOffset, 0);
        }
        
        // Blink "tap to start" text
        if (tapToStartText != null)
        {
            float alpha = (Mathf.Sin(Time.time * tapTextBlinkSpeed) + 1f) / 2f;
            Color newColor = tapTextOriginalColor;
            newColor.a = Mathf.Lerp(0.3f, 1f, alpha);
            tapToStartText.color = newColor;
        }
    }

    IEnumerator AnimateScreen()
    {
        // Hide elements initially
        if (logo != null)
            logo.transform.localScale = Vector3.zero;
        if (playButton != null)
            playButton.transform.localScale = Vector3.zero;
        if (settingsButton != null)
            settingsButton.transform.localScale = Vector3.zero;
        if (tapToStartText != null)
            tapToStartText.gameObject.SetActive(false);

        // Animate logo pop-in
        yield return new WaitForSeconds(0.2f);
        if (logo != null)
            yield return StartCoroutine(ScaleIn(logo, 0.5f));

        // Animate play button
        yield return new WaitForSeconds(0.1f);
        if (playButton != null)
            yield return StartCoroutine(ScaleIn(playButton.gameObject, 0.3f));

        // Animate settings button
        yield return new WaitForSeconds(0.1f);
        if (settingsButton != null)
            yield return StartCoroutine(ScaleIn(settingsButton.gameObject, 0.3f));

        // Show tap to start text
        yield return new WaitForSeconds(0.2f);
        if (tapToStartText != null)
            tapToStartText.gameObject.SetActive(true);
    }

    IEnumerator ScaleIn(GameObject obj, float duration)
    {
        Vector3 targetScale = obj.transform.localScale;
        obj.transform.localScale = Vector3.zero;
        
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            // Bounce effect
            float scale = Mathf.Sin(t * Mathf.PI * 0.5f);
            if (t > 0.6f)
            {
                float bounce = 1f + Mathf.Sin((t - 0.6f) * Mathf.PI * 5f) * 0.1f * (1f - t);
                scale = bounce;
            }
            
            obj.transform.localScale = targetScale * scale;
            yield return null;
        }
        
        obj.transform.localScale = targetScale;
    }
}
