using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enhanced UI styling for modern look
/// Add this to your Canvas objects to auto-style them
/// </summary>
public class ModernUIStyle : MonoBehaviour
{
    [Header("Color Scheme")]
    public Color primaryColor = new Color(0.2f, 0.7f, 1f, 1f); // Blue
    public Color secondaryColor = new Color(1f, 0.8f, 0.2f, 1f); // Gold
    public Color backgroundColor = new Color(0.1f, 0.1f, 0.15f, 0.95f); // Dark
    public Color textColor = Color.white;
    
    [Header("Button Settings")]
    public bool styleButtons = true;
    public bool addShadows = true;
    public float buttonScale = 1.1f;
    
    void Start()
    {
        if (styleButtons)
            StyleAllButtons();
        
        if (addShadows)
            AddShadowsToText();
    }

    void StyleAllButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>(true);
        
        foreach (Button button in buttons)
        {
            // Add hover effect
            AddButtonHoverEffect(button);
            
            // Style button colors
            ColorBlock colors = button.colors;
            colors.normalColor = primaryColor;
            colors.highlightedColor = secondaryColor;
            colors.pressedColor = new Color(secondaryColor.r * 0.8f, secondaryColor.g * 0.8f, secondaryColor.b * 0.8f, 1f);
            colors.selectedColor = primaryColor;
            button.colors = colors;
            
            // Add outline
            Outline outline = button.gameObject.GetComponent<Outline>();
            if (outline == null)
            {
                outline = button.gameObject.AddComponent<Outline>();
                outline.effectColor = new Color(0, 0, 0, 0.5f);
                outline.effectDistance = new Vector2(2, -2);
            }
        }
    }

    void AddButtonHoverEffect(Button button)
    {
        // Add scale animation on hover
        ButtonScaleEffect scaleEffect = button.gameObject.GetComponent<ButtonScaleEffect>();
        if (scaleEffect == null)
        {
            scaleEffect = button.gameObject.AddComponent<ButtonScaleEffect>();
            scaleEffect.targetScale = buttonScale;
        }
    }

    void AddShadowsToText()
    {
        Text[] texts = GetComponentsInChildren<Text>(true);
        
        foreach (Text text in texts)
        {
            Shadow shadow = text.gameObject.GetComponent<Shadow>();
            if (shadow == null)
            {
                shadow = text.gameObject.AddComponent<Shadow>();
                shadow.effectColor = new Color(0, 0, 0, 0.5f);
                shadow.effectDistance = new Vector2(2, -2);
            }
            
            // Make text bold and easier to read
            text.fontStyle = FontStyle.Bold;
            
            // Add outline for better readability
            Outline outline = text.gameObject.GetComponent<Outline>();
            if (outline == null)
            {
                outline = text.gameObject.AddComponent<Outline>();
                outline.effectColor = new Color(0, 0, 0, 0.8f);
                outline.effectDistance = new Vector2(1, -1);
            }
        }
    }

    /// <summary>
    /// Style a specific panel
    /// </summary>
    public void StylePanel(GameObject panel)
    {
        Image panelImage = panel.GetComponent<Image>();
        if (panelImage != null)
        {
            panelImage.color = backgroundColor;
        }
        
        // Add shadow/glow effect
        Shadow shadow = panel.GetComponent<Shadow>();
        if (shadow == null)
        {
            shadow = panel.AddComponent<Shadow>();
            shadow.effectColor = new Color(0, 0, 0, 0.8f);
            shadow.effectDistance = new Vector2(5, -5);
        }
    }
}

/// <summary>
/// Button scale effect on hover
/// </summary>
public class ButtonScaleEffect : MonoBehaviour
{
    public float targetScale = 1.1f;
    public float animationSpeed = 10f;
    
    private Vector3 originalScale;
    private bool isHovering = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        Vector3 target = isHovering ? originalScale * targetScale : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * animationSpeed);
    }

    public void OnPointerEnter()
    {
        isHovering = true;
    }

    public void OnPointerExit()
    {
        isHovering = false;
    }
}
