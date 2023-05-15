using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
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

    public List<Sprite> soundButtonsSprites = new List<Sprite>();

    public bool sfxOff = false;
    public bool musicOff = false;
    public bool onGame;

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
        if (!sfxOff)
        {
            Sound clipToPlay = Array.Find(sfxSounds, x => x.clipName == name);
            sfxSource.PlayOneShot(clipToPlay.clip);
        }
    }

    public IEnumerator DestroyObject(GameObject objToDestroy, float timer)
    {
        yield return new WaitForSeconds(timer);

        Destroy(objToDestroy);
    }

    public void ToggleSFX(Button soundButton)
    {
        PlaySFX("Click");

        if (sfxOff) soundButton.image.sprite = soundButtonsSprites[3];
        else soundButton.image.sprite = soundButtonsSprites[2];

        sfxOff = !sfxOff;
    }
}
