using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float radius = 0.5f;
    private float speed = 50f;
    private float radiusTimer;

    private void Start()
    {
        transform.position = new Vector3(0.05f, 0.05f, 0f);
    }

    private void Update()
    {
        radiusTimer += Time.deltaTime;
        Rotate();
    }

    void Rotate()
    {
        if (radiusTimer > 0.015f)
        {
            speed = Random.Range(50, 80);
            radiusTimer = 0;

            if (radius < 3)
            {
                radius += 0.01f;
                var _direction = (transform.position - GameController.instance.centerPoint.transform.position).normalized;
                transform.position = _direction * radius;
            }
        }
        
        transform.RotateAround(GameController.instance.centerPoint.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
