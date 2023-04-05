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

    public Sound[] sfxSounds;
    public AudioSource sfxSource;

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
}
