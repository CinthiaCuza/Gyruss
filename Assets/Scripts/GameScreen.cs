using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour 
{
    private int score;
    public TMP_Text textScore;

    public Button musicButton;
    public Button soundButton;

    private AudioSource music;

    public GameObject gameOverPanel;

    public List<Sprite> startNumbersList = new List<Sprite>();
    public GameObject UIElements;
    public Image startNumber;
    public GameObject player;

    private void Start()
    {
        Time.timeScale = 1f;
        music = gameObject.GetComponent<AudioSource>();

        StartCoroutine(CountDown());

        if (GameController.instance.sfxOff) soundButton.image.sprite = GameController.instance.soundButtonsSprites[2];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) StartMenu();
    }

    IEnumerator CountDown()
    {
        for (int i = 0; i < startNumbersList.Count; i++)
        {
            startNumber.gameObject.SetActive(true);
            startNumber.sprite = startNumbersList[i];
            GameController.instance.PlaySFX("Count");
            
            yield return new WaitForSeconds(1f);
            startNumber.gameObject.SetActive(false);
        }

        if (GameController.instance.musicOff)
        {
            musicButton.image.sprite = GameController.instance.soundButtonsSprites[0];
            music.mute = true;
        }
        else
        {
            music.Play();
        }

        UIElements.SetActive(true);
        player.SetActive(true);

        GameController.instance.onGame = true;
    }


    public void Score(float radiusEnemy)
    {
        if (radiusEnemy < 1) score += 3;
        else if (radiusEnemy < 2 && radiusEnemy >= 1) score += 2;
        else score += 1;

        GameController.instance.PlaySFX("Score");
        textScore.text = "SCORE: " + score;
    }

    public void ToggleMusic()
    {
        GameController.instance.PlaySFX("Click");

        if (GameController.instance.musicOff) musicButton.image.sprite = GameController.instance.soundButtonsSprites[1];
        else musicButton.image.sprite = GameController.instance.soundButtonsSprites[0];

        GameController.instance.musicOff = !GameController.instance.musicOff;
        music.mute = !music.mute;
    }

    public void ToggleSFX()
    {
        GameController.instance.ToggleSFX(soundButton);
    }

    public void StartMenu()
    {
        GameController.instance.PlaySFX("Click");
        GameController.instance.onGame = false;
        SceneManager.LoadScene("StartMenu");
    }

    public void GameOver()
    {
        music.mute = true;
        GameController.instance.PlaySFX("GO");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameController.instance.PlaySFX("Click");
        GameController.instance.onGame = false;
        SceneManager.LoadScene("Game");
    }
}
