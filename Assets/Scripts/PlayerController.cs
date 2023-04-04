using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        MovementPlayer();
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
}
