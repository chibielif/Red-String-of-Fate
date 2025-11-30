using UnityEngine;
using System;

public class AudioPlayer : MonoBehaviour
{
    public Sound[] sounds;
    private void Awake()
    {
        ManageSingleton();
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = sound.audioMixerGroup;
        }
    }

    private void Start()
    {
        Play("Music");
    }

    private void ManageSingleton()
    {
        int instanceCount = FindObjectsByType<AudioPlayer>(FindObjectsSortMode.None).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 1f;
        s.source.Play();
    }
    
}
