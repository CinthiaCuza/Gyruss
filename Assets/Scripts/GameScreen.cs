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
    public Button restartButton;

    private AudioSource music;

    private void Start()
    {
        GameController.instance.sfxSource.mute = false;
        music = gameObject.GetComponent<AudioSource>();

        musicButton.onClick.AddListener(ToggleMusic);
        soundButton.onClick.AddListener(ToggleSFX);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void Score(float radiusEnemy)
    {
        if (radiusEnemy < 1)
        {
            score += 3;
        }
        else if (radiusEnemy < 2 && radiusEnemy >= 1)
        {
            score += 2;
        }
        else 
        {
            score += 1;
        }

        GameController.instance.PlaySFX("Score");
        textScore.text = "SCORE: " + score;
    }

    public void ToggleMusic()
    {
        GameController.instance.PlaySFX("Click");
        
        if(music.mute)
        {
            musicButton.image.sprite = soundButtonsSprites[1];
        }
        else
        {
            musicButton.image.sprite = soundButtonsSprites[0];
        }

        music.mute = !music.mute;
    }

    public void ToggleSFX()
    {
        GameController.instance.PlaySFX("Click");

        if (GameController.instance.sfxSource.mute)
        {
            soundButton.image.sprite = soundButtonsSprites[3];  
        }
        else
        {
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
