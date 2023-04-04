using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject centerPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        centerPoint = GameObject.FindGameObjectWithTag("Center");

        Vector3 direction = centerPoint.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * 20f;
    }

    private void Update()
    {
        if(transform.position == centerPoint.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
