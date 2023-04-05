using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{
    public string clipName;
    public AudioClip clip;
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int selectedShip = 0;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound clipToPlay = Array.Find(musicSounds, x => x.clipName == name);

        if (clipToPlay == null)
        {
            Debug.Log("Not found");
        }
        else
        {
            musicSource.clip = clipToPlay.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound clipToPlay = Array.Find(sfxSounds, x => x.clipName == name);

        if (clipToPlay == null)
        {
            Debug.Log("Not found");
        }
        else
        {
            sfxSource.PlayOneShot(clipToPlay.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
}
