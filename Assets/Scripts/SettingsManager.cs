using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer sfxAudioMixer;
    
    public TMP_Dropdown resolutionDropdown;

    public Slider musicSlider;
    public Slider sfxSlider;

    Resolution[] resolutions;

    private void Start()
    {
        if (musicSlider != null && musicAudioMixer.GetFloat("MusicVolume", out float musicVolume))
        {
            musicSlider.value = musicVolume;
        }

        if (sfxSlider != null && sfxAudioMixer.GetFloat("SFXVolume", out float sfxVolume))
        {
            sfxSlider.value = sfxVolume;
        }

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            
            if (resolutions[i].width == Screen.width && 
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("MusicVolume", volume);
    }
    
    public void SetSfxVolume(float volume)
    {
        sfxAudioMixer.SetFloat("SFXVolume", volume);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
