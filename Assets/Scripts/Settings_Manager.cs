using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_Manager : MonoBehaviour
{
    public GameObject startScreenCanvas;

    public void TurnOnSettingMenu()
    {
        if (Game_Manager.instance != null)
        {
            Game_Manager.instance.TurnOnSettingMenu();
            return;
        }

        if (startScreenCanvas != null)
            startScreenCanvas.SetActive(false);

        gameObject.SetActive(true);
    }

    public void SoundOn()
    {
        AudioListener.volume = 1;
        
        // Update AudioManager settings
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicEnabled(true);
            AudioManager.instance.SetSFXEnabled(true);
        }
    }

    public void SoundOff()
    {
        AudioListener.volume = 0;
        
        // Update AudioManager settings
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicEnabled(false);
            AudioManager.instance.SetSFXEnabled(false);
        }
    }

    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.ToggleSFX();
    }
}
