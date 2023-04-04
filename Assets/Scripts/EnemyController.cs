using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 8f * Time.deltaTime * 8f);
    }
}
