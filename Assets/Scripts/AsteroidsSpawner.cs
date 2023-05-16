using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] float timeToSpawn;
    public GameObject asteroidPrefab;
    public Transform[] spawners;

    public List<Sprite> asteroidsSprites = new List<Sprite>();

    IEnumerator Start()
    {
        while (true)
        {
            if (GameController.instance.onGame)
            {
                int lenght = Random.Range(0, 10);

                for (int i = 0; i < lenght; i++)
                {
                    GameObject newAsteroid = Instantiate(asteroidPrefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                    newAsteroid.GetComponent<SpriteRenderer>().sprite = asteroidsSprites[Random.Range(0, 8)];
                }
            }

            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
