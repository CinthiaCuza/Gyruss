using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour 
{
    public int score;
    public TMP_Text textScore;
    public List<Sprite> soundButtonsSprites = new List<Sprite>();

    public Button musicButton;
    public Button soundButton;

    private void Start()
    {
        if (!GameController.instance.musicSource.mute)
        {
            GameController.instance.PlayMusic("Theme");
        }

        if (GameController.instance.noSFX)
        {
            GameController.instance.sfxSource.mute = true;
        }

        if (GameController.instance.musicSource.mute)
        {
            musicButton.image.sprite = soundButtonsSprites[0];
        }
        else
        {
            musicButton.image.sprite = soundButtonsSprites[1];
        }

        if (GameController.instance.sfxSource.mute)
        {
            soundButton.image.sprite = soundButtonsSprites[2];
        }
        else
        {
            soundButton.image.sprite = soundButtonsSprites[3];
        }
    }

    public void Score(float radiusEnemy)
    {
        if (radiusEnemy < 1)
        {
            score += 3;
        }

        if (radiusEnemy < 2 && radiusEnemy >= 1)
        {
            score += 2;
        }

        if (radiusEnemy >= 2)
        {
            score += 1;
        }

        GameController.instance.PlaySFX("Score");
        textScore.text = "SCORE: " + score;
    }

    public void ToggleMusic()
    {
        GameController.instance.PlaySFX("Click");

        if (GameController.instance.musicSource.mute)
        {
            musicButton.image.sprite = soundButtonsSprites[1];
        }
        else
        {
            musicButton.image.sprite = soundButtonsSprites[0];
        }

        GameController.instance.musicSource.mute = !GameController.instance.musicSource.mute;
    }

    public void ToggleSFX()
    {
        GameController.instance.PlaySFX("Click");

        if (GameController.instance.sfxSource.mute)
        {
            GameController.instance.noSFX = false;
            soundButton.image.sprite = soundButtonsSprites[3];  
        }
        else
        {
            GameController.instance.noSFX = true;
            soundButton.image.sprite = soundButtonsSprites[2];
        }

        GameController.instance.sfxSource.mute = !GameController.instance.sfxSource.mute;
    }

    public void RestartGame()
    {
        GameController.instance.PlaySFX("Click");
        SceneManager.LoadScene("StartMenu");
    }
}
