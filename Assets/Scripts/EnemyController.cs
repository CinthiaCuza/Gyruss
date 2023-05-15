using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public float radius;
    [SerializeField] private float minValueSpeed;
    [SerializeField] private float maxValueSpeed;

    private float speed;
    private float radiusTimer;

    public GameObject explosion;

    [HideInInspector] public GameScreen gameScreen;

    private void Start()
    {
        gameScreen = FindObjectOfType<GameScreen>();
        StartCoroutine(GameController.instance.DestroyObject(gameObject, 20f));
    }

    private void Update()
    {
        radiusTimer += Time.deltaTime;
        Rotate();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.PlaySFX("Explosion");
            collision.gameObject.GetComponent<PlayerController>().Explosion();
            Explosion();
            gameScreen.Invoke("GameOver", 0.12f);
        }
    }

    void Rotate()
    {
        if (radiusTimer > 0.02f)
        {
            speed = UnityEngine.Random.Range(minValueSpeed, maxValueSpeed);
            radiusTimer = 0;

            if (transform.localScale.x <= 0.7)
            {
                Vector3 _enemyScale = new Vector3(0.002f, 0.002f, 1f);
                transform.localScale = transform.localScale + _enemyScale;
            }

            // #1
            radius += 0.01f;
            var _direction = (transform.position - new Vector3(0, 0, 0)).normalized;
            transform.position = _direction * radius;

            //if (radius < 3) #1
        }

        transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
    }

    public void Shooted()
    {
        gameScreen.Score(radius);
        Explosion();
    }

    public void Explosion()
    {
        explosion.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(GameController.instance.DestroyObject(gameObject, 0.1f));
    }
}
