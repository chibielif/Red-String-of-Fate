using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer SFXAudioMixer;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("MusicVolume", volume);
    } 
    
    public void SetSFXVolume(float volume)
    {
        SFXAudioMixer.SetFloat("SFXVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
