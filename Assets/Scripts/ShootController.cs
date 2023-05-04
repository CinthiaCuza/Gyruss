using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject centerPoint;

    [SerializeField] private float rbVelocity;

    private void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("Center");
        rb = GetComponent<Rigidbody2D>();

        Invoke("DesactivateShoot", 0.5f);

        Vector3 _direction = centerPoint.transform.position - transform.position;
        rb.velocity = new Vector2 (_direction.x, _direction.y).normalized * rbVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Shooted();
            Destroy(gameObject);
        }
    }

    public void DesactivateShoot()
    {
        Destroy(gameObject);
    }
}
