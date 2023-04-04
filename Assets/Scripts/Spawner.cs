using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public List<Sprite> enemiesSprites = new List<Sprite>();

    private float spawnTimer;
    

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > Random.Range(2, 4))
        {
            spawnTimer = 0;

            GameObject newEnemy = Instantiate(enemy, GameController.instance.centerPoint.transform.position, transform.rotation);

            int index = Random.Range(0, 19);
            newEnemy.GetComponent<SpriteRenderer>().sprite = enemiesSprites[index];
        }
    }
}
