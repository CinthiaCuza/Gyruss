using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreen : MonoBehaviour 
{
    public int score;
    public TMP_Text textScore;

    private void Start()
    {
        GameController.instance.PlayMusic("Theme");
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
}
