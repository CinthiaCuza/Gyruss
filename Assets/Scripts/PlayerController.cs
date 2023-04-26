using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shoot;
    public GameObject spawnPoint;
    public GameObject explosion;

    [SerializeField] private float shootTimer; 

    private float currentShootTimer;

    private bool canShoot;
    private bool leftArrowDown;
    private bool rightArrowDown;

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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightArrowDown = true;
            leftArrowDown = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rightArrowDown = false;
            leftArrowDown = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) leftArrowDown = false;
        if (Input.GetKeyUp(KeyCode.RightArrow)) rightArrowDown = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (leftArrowDown) gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
            else gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rightArrowDown) gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 10f);
            else gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
        }
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer > currentShootTimer) canShoot = true;

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            shootTimer = 0f;

            GameController.instance.PlaySFX("Laser");
            Instantiate(shoot, spawnPoint.transform.position, transform.rotation);
        }
    }

    public void Explosion()
    {
        explosion.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("DestroyPlayer", 0.1f);
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
