using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float radius = 0.5f;
    public float speed = 5.0f;
    public bool stopIncreaseRadius;

    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (!stopIncreaseRadius)
        {
            radius += 0.5f;
        }
        
        if (radius == 6)
        {
            stopIncreaseRadius = true;
        }

        transform.RotateAround(GameController.instance.centerPoint.transform.position, Vector3.forward, speed * Time.deltaTime);
        //transform.position += transform.forward * radius;
    }
}
