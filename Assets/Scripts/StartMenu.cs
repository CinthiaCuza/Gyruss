using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public List<GameObject> playerShipsList = new List<GameObject>();

    public GameObject selectShipComponent;
    public GameObject controlsComponent;

    private void Start()
    {
        Time.timeScale = 1f;
        SelectShip(GameController.instance.selectedShip);
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

    public void ControlsButton()
    {
        selectShipComponent.SetActive(false);
        controlsComponent.SetActive(true);
    }

    public void SelectShipButton()
    {
        selectShipComponent.SetActive(true);
        controlsComponent.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
