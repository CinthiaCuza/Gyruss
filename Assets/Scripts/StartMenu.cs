using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public List<GameObject> playerShipsList = new List<GameObject>();
    public void SelectShip(int pos)
    {
        GameController.instance.PlaySFX("SelectShip");

        playerShipsList[GameController.instance.selectedShip].transform.localScale = Vector3.one;
        GameController.instance.selectedShip = pos;
        playerShipsList[pos].transform.localScale = new Vector3(1.4f, 1.4f, 1f);
    }

    public void StartGame()
    {
        GameController.instance.PlaySFX("Click");
        SceneManager.LoadScene("GameScene");
    }
}
