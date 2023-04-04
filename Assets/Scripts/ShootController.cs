using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject centerPoint;
    private void Start()
    {
        Invoke("DesactivateShoot", 0.5f);

        rb = GetComponent<Rigidbody2D>();
        centerPoint = GameObject.FindGameObjectWithTag("Center");

        Vector3 direction = centerPoint.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * 20f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void DesactivateShoot()
    {
        gameObject.SetActive(false);
    }
}