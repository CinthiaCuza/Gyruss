using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private StartMenu startMenu;

    [UnityTest]
    public IEnumerator SelectShip()
    {
        GameObject gameGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/StartMenu"));
        startMenu = gameGO.GetComponent<StartMenu>();

        GameObject ship1 = new GameObject();
        GameObject ship2 = new GameObject();
            ;
        startMenu.playerShipsList[0] = ship1;
        startMenu.playerShipsList[1] = ship2;

        startMenu.SelectShip(1);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(startMenu.playerShipsList[0].transform.localScale, Vector3.one);
        //Assert.AreEqual(GameController.instance.selectedShip, 1);
        Assert.AreEqual(startMenu.playerShipsList[1].transform.localScale, new Vector3(1.4f, 1.4f, 1f));
    }
}
