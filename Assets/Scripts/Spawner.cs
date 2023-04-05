using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public List<Sprite> enemiesSprites = new List<Sprite>();

    private float spawnTimer;
    private int amountSpawner;
    private int currentAmountSpawner;
    public int stopTime;

    private void Start()
    {
        amountSpawner = Random.Range(2, 10);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        SpawnEnemies();
    }

    private void SpawnEnemies() 
    {
        if (spawnTimer > 1)
        {
            currentAmountSpawner++;
            spawnTimer = 0;

            if (currentAmountSpawner < amountSpawner)
            {
                GameObject newEnemy = Instantiate(enemy, GameController.instance.centerPoint.transform.position, transform.rotation);
                int index = Random.Range(0, 19);
                newEnemy.GetComponent<SpriteRenderer>().sprite = enemiesSprites[index];
            }
        }

        if(currentAmountSpawner > amountSpawner + stopTime)
        {
            amountSpawner = Random.Range(2, 10);
            currentAmountSpawner = 0;
        }
    }
}
