using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public List<Sprite> enemiesSprites = new List<Sprite>();

    private float spawnTimer;
    private int amountEnemies;
    private int currentAmountEnemies;

    [SerializeField] private int stopTime;

    private void Start()
    {
        amountEnemies = Random.Range(2, 11);
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
            currentAmountEnemies++;
            spawnTimer = 0;

            if (currentAmountEnemies < amountEnemies)
            {
                GameObject _newEnemy = Instantiate(enemy, new Vector3(0.01f, 0.01f, 0f), transform.rotation);
                int _index = Random.Range(0, 20);
                _newEnemy.GetComponent<SpriteRenderer>().sprite = enemiesSprites[_index];

                GameController.instance.PlaySFX("EnemySpawn");
            }
        }

        if(currentAmountEnemies > amountEnemies + stopTime)
        {
            amountEnemies = Random.Range(2, 11);
            currentAmountEnemies = 0;
        }
    }
}
