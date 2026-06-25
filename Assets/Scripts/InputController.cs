using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Universal input controller for both PC and Mobile
/// Handles mouse clicks, touch input, and keyboard
/// </summary>
public class InputController : MonoBehaviour
{
    public static InputController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Check if tap/click input detected this frame
    /// Works for both mouse and touch
    /// </summary>
    public bool GetTapInput()
    {
        // Mouse input
        if (Input.GetMouseButtonDown(0))
            return true;

        // Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                return true;
        }

        // Keyboard space as alternative
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;
    }

    /// <summary>
    /// Check if input is currently held down
    /// </summary>
    public bool GetTapHeld()
    {
        if (Input.GetMouseButton(0))
            return true;

        if (Input.touchCount > 0)
            return true;

        if (Input.GetKey(KeyCode.Space))
            return true;

        return false;
    }

    /// <summary>
    /// Get touch/mouse position in screen space
    /// </summary>
    public Vector2 GetInputPosition()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).position;

        return Input.mousePosition;
    }

    /// <summary>
    /// Check if device is mobile
    /// </summary>
    public bool IsMobile()
    {
        return Application.isMobilePlatform;
    }
}
