using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeSong(AudioClip newSong, float volume)
    {
        if (audioSource.clip == null || audioSource.clip.name != newSong.name)
        {
            audioSource.Stop();
            audioSource.clip = newSong;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
