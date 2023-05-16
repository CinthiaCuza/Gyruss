using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Borders
{
    public float up, down, left, right;
}

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    public Borders borders;
    int inBorder = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * speed;

        rb.angularVelocity = Random.Range(-50f, 50f);
    }

    private void Update()
    {
        var _pos = transform.position;
        var _x = transform.position.x;
        var _y = transform.position.y;

        if (_x > borders.right) ChangeAsteroid(borders.left, _pos.y);
        if (_x < borders.left) ChangeAsteroid(borders.right, _pos.y);
        if (_y > borders.up) ChangeAsteroid(_pos.x, borders.down);
        if (_y < borders.down) ChangeAsteroid(_pos.x, borders.up);
    }

    void ChangeAsteroid(float posX, float posY)
    {
        inBorder++;

        if (inBorder >= 2)
        {
            Destroy(gameObject);
        }
        else
        {
            var _pos = transform.position;

            _pos.x = posX;
            _pos.y = posY;

            transform.position = _pos;
        }
    }
}
