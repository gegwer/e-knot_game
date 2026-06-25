using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio Manager for centralized sound control
/// Handles background music and sound effects
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip flapSound;
    public AudioClip scoreSound;
    public AudioClip hitSound;
    public AudioClip dieSound;

    private bool isMusicEnabled = true;
    private bool isSFXEnabled = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadAudioSettings();
    }

    void Start()
    {
        if (isMusicEnabled && backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayFlap()
    {
        if (isSFXEnabled && flapSound != null && sfxSource != null)
            sfxSource.PlayOneShot(flapSound);
    }

    public void PlayScore()
    {
        if (isSFXEnabled && scoreSound != null && sfxSource != null)
            sfxSource.PlayOneShot(scoreSound);
    }

    public void PlayHit()
    {
        if (isSFXEnabled && hitSound != null && sfxSource != null)
            sfxSource.PlayOneShot(hitSound);
    }

    public void PlayDie()
    {
        if (isSFXEnabled && dieSound != null && sfxSource != null)
            sfxSource.PlayOneShot(dieSound);
    }

    public void ToggleMusic()
    {
        isMusicEnabled = !isMusicEnabled;
        
        if (musicSource != null)
        {
            if (isMusicEnabled)
                musicSource.Play();
            else
                musicSource.Pause();
        }

        SaveAudioSettings();
    }

    public void ToggleSFX()
    {
        isSFXEnabled = !isSFXEnabled;
        SaveAudioSettings();
    }

    public void SetMusicEnabled(bool enabled)
    {
        isMusicEnabled = enabled;
        
        if (musicSource != null)
        {
            if (isMusicEnabled)
                musicSource.Play();
            else
                musicSource.Pause();
        }

        SaveAudioSettings();
    }

    public void SetSFXEnabled(bool enabled)
    {
        isSFXEnabled = enabled;
        SaveAudioSettings();
    }

    public bool IsMusicEnabled()
    {
        return isMusicEnabled;
    }

    public bool IsSFXEnabled()
    {
        return isSFXEnabled;
    }

    private void LoadAudioSettings()
    {
        isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        isSFXEnabled = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;
    }

    private void SaveAudioSettings()
    {
        PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0);
        PlayerPrefs.SetInt("SFXEnabled", isSFXEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }
}
