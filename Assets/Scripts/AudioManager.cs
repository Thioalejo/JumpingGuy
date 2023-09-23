using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource musicPlayer, soundPlayer;
    public AudioClip[] availableSoundClips;
    Dictionary<string, AudioClip> loadedAudioClips;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        musicPlayer.Play();
        loadedAudioClips = new Dictionary<string, AudioClip>();

        foreach (AudioClip itemAudio in availableSoundClips)
        {
            loadedAudioClips.Add(itemAudio.name, itemAudio);
        }
        soundPlayer.Play();
    }

    public void PlaySound(string name)
    {
        soundPlayer.clip = loadedAudioClips[name];
        soundPlayer.Play();
    }

    public void StopMusic()
    {
       musicPlayer.Stop();
    }
}
