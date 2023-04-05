using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shoot;
    public GameObject spawnPoint;

    private float shootTimer = 0.35f; 
    private float currentShootTimer;
    private bool canShoot;

    public List<Sprite> playerSprites = new List<Sprite>();

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[GameController.instance.selectedShip];
        currentShootTimer = shootTimer;
    }

    private void Update()
    {
        MovementPlayer();
        Shoot();
    }

    public void MovementPlayer()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 10f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
        }
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer > currentShootTimer)
        {
            canShoot = true;
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            shootTimer = 0f;

            GameController.instance.PlaySFX("Laser");
            Instantiate(shoot, spawnPoint.transform.position, transform.rotation);
            
        }
    }
}
