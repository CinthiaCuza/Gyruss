using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject centerPoint;
    private GameScreen gameScreen;

    [SerializeField] private float rbVelocity;

    private void Start()
    {
        gameScreen = FindObjectOfType<GameScreen>();
        centerPoint = GameObject.FindGameObjectWithTag("Center");
        rb = GetComponent<Rigidbody2D>();

        Invoke("DesactivateShoot", 0.5f);

        Vector3 _direction = centerPoint.transform.position - transform.position;
        rb.velocity = new Vector2 (_direction.x, _direction.y).normalized * rbVelocity;
    }

    public void DesactivateShoot()
    {
        Destroy(gameObject);
    }
}
