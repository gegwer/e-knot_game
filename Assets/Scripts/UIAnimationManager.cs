using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enhanced UI Manager with animations and transitions
/// </summary>
public class UIAnimationManager : MonoBehaviour
{
    public static UIAnimationManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Animate a UI element with scale bounce effect
    /// </summary>
    public void BounceScale(GameObject obj, float duration = 0.3f)
    {
        if (obj != null)
            StartCoroutine(BounceScaleCoroutine(obj, duration));
    }

    IEnumerator BounceScaleCoroutine(GameObject obj, float duration)
    {
        Vector3 originalScale = obj.transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / duration;
            
            // Bounce curve
            float scale = 1f + Mathf.Sin(progress * Mathf.PI) * 0.2f;
            obj.transform.localScale = originalScale * scale;

            yield return null;
        }

        obj.transform.localScale = originalScale;
    }

    /// <summary>
    /// Fade in a canvas group
    /// </summary>
    public void FadeIn(CanvasGroup canvasGroup, float duration = 0.5f)
    {
        if (canvasGroup != null)
            StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, 1f, duration));
    }

    /// <summary>
    /// Fade out a canvas group
    /// </summary>
    public void FadeOut(CanvasGroup canvasGroup, float duration = 0.5f)
    {
        if (canvasGroup != null)
            StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, 0f, duration));
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        canvasGroup.alpha = startAlpha;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }

    /// <summary>
    /// Slide in UI element from side
    /// </summary>
    public void SlideIn(RectTransform rectTransform, Vector2 fromPosition, float duration = 0.5f)
    {
        if (rectTransform != null)
            StartCoroutine(SlideCoroutine(rectTransform, fromPosition, rectTransform.anchoredPosition, duration));
    }

    IEnumerator SlideCoroutine(RectTransform rectTransform, Vector2 from, Vector2 to, float duration)
    {
        float elapsed = 0f;
        rectTransform.anchoredPosition = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            // Smooth ease out
            t = 1f - Mathf.Pow(1f - t, 3f);
            
            rectTransform.anchoredPosition = Vector2.Lerp(from, to, t);
            yield return null;
        }

        rectTransform.anchoredPosition = to;
    }

    /// <summary>
    /// Pulse animation for important UI elements
    /// </summary>
    public void PulseEffect(GameObject obj, float minScale = 0.9f, float maxScale = 1.1f, float speed = 2f)
    {
        StartCoroutine(PulseCoroutine(obj, minScale, maxScale, speed));
    }

    IEnumerator PulseCoroutine(GameObject obj, float minScale, float maxScale, float speed)
    {
        Vector3 originalScale = obj.transform.localScale;

        while (obj != null && obj.activeInHierarchy)
        {
            float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * speed) + 1f) / 2f);
            obj.transform.localScale = originalScale * scale;
            yield return null;
        }

        if (obj != null)
            obj.transform.localScale = originalScale;
    }

    /// <summary>
    /// Number count-up animation
    /// </summary>
    public void AnimateNumber(Text textComponent, int from, int to, float duration = 1f)
    {
        if (textComponent != null)
            StartCoroutine(AnimateNumberCoroutine(textComponent, from, to, duration));
    }

    IEnumerator AnimateNumberCoroutine(Text textComponent, int from, int to, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            int currentValue = (int)Mathf.Lerp(from, to, elapsed / duration);
            textComponent.text = currentValue.ToString();
            yield return null;
        }

        textComponent.text = to.ToString();
    }
}
