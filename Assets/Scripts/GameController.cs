using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject centerPoint;
    public GameObject player;

    public int score;

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
    }
}
