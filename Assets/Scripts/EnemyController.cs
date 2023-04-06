using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float radius;
    private float speed;
    private float radiusTimer;

    public GameObject explosion;

    private void Update()
    {
        radiusTimer += Time.deltaTime;
        Rotate();
    }

    void Rotate()
    {
        if (radiusTimer > 0.02f)
        {
            speed = Random.Range(40, 90);
            radiusTimer = 0;

            if (transform.localScale.x <= 0.7)
            {
                Vector3 _enemyScale = new Vector3(0.002f, 0.002f, 1f);
                transform.localScale = transform.localScale + _enemyScale;
            }

            if (radius < 3)
            {
                radius += 0.01f;
                var _direction = (transform.position - new Vector3(0, 0, 0)).normalized;
                transform.position = _direction * radius;
            }
        }

        transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
    }

    public void Explosion()
    {
        explosion.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("DestroyEnemy", 0.1f);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
