using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnemyController : MonoBehaviour
{
    [SerializeField] DroneMovement _drone;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            _drone._target = gameObject.transform;
            Destroy(gameObject);
        }
    }
}
