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
        if (spawnTimer > 0.5f)
        {
            currentAmountSpawner++;
            spawnTimer = 0;

            if (currentAmountSpawner < amountSpawner)
            {
                GameObject _newEnemy = Instantiate(enemy, GameController.instance.centerPoint.transform.position, transform.rotation);
                int _index = Random.Range(0, 19);
                _newEnemy.GetComponent<SpriteRenderer>().sprite = enemiesSprites[_index];
            }
        }

        if(currentAmountSpawner > amountSpawner + stopTime)
        {
            amountSpawner = Random.Range(2, 10);
            currentAmountSpawner = 0;
        }
    }
}
