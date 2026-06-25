using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Background parallax effect for better visual appeal
/// </summary>
public class ParallaxBackground : MonoBehaviour
{
    [Header("Parallax Settings")]
    public float parallaxSpeed = 0.5f;
    public bool autoScroll = true;
    
    private Material backgroundMaterial;
    private float offset = 0f;

    void Start()
    {
        // Get material from sprite renderer or image
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            backgroundMaterial = spriteRenderer.material;
        }
        else
        {
            Image image = GetComponent<Image>();
            if (image != null)
                backgroundMaterial = image.material;
        }
    }

    void Update()
    {
        if (autoScroll && backgroundMaterial != null)
        {
            offset += Time.deltaTime * parallaxSpeed * 0.1f;
            backgroundMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
