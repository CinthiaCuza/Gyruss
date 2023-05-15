using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public List<GameObject> playerShipsList = new List<GameObject>();

    public Button soundButton;

    private void Start()
    {
        Time.timeScale = 1f;
        SelectShip(GameController.instance.selectedShip);
        if (GameController.instance.sfxOff) soundButton.image.sprite = GameController.instance.soundButtonsSprites[2];
    }

    public void PalySFX(string clipName)
    {
        GameController.instance.PlaySFX(clipName);
    }

    public void SelectShip(int pos)
    {
        playerShipsList[GameController.instance.selectedShip].transform.localScale = Vector3.one;
        GameController.instance.selectedShip = pos;
        playerShipsList[pos].transform.localScale = new Vector3(1.4f, 1.4f, 1f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleSFX()
    {
        GameController.instance.ToggleSFX(soundButton);
    }
}
