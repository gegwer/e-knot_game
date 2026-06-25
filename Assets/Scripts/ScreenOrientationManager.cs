using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages screen orientation for mobile devices
/// Ensures proper orientation for Flappy Bird style game
/// </summary>
public class ScreenOrientationManager : MonoBehaviour
{
    [SerializeField] private bool allowLandscape = false;
    [SerializeField] private bool allowPortrait = true;

    void Start()
    {
        SetupOrientation();
    }

    void SetupOrientation()
    {
        // For mobile devices
        if (Application.isMobilePlatform)
        {
            if (allowPortrait && !allowLandscape)
            {
                Screen.orientation = ScreenOrientation.Portrait;
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
            }
            else if (allowLandscape && !allowPortrait)
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
            }
            else
            {
                Screen.orientation = ScreenOrientation.AutoRotation;
                Screen.autorotateToPortrait = allowPortrait;
                Screen.autorotateToPortraitUpsideDown = allowPortrait;
                Screen.autorotateToLandscapeLeft = allowLandscape;
                Screen.autorotateToLandscapeRight = allowLandscape;
            }
        }
    }

    public void SetPortraitMode()
    {
        allowPortrait = true;
        allowLandscape = false;
        SetupOrientation();
    }

    public void SetLandscapeMode()
    {
        allowPortrait = false;
        allowLandscape = true;
        SetupOrientation();
    }
}
