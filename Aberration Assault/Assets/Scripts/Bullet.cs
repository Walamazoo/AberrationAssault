using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code destruction on collision created based on https://www.youtube.com/watch?v=LNLVOjbrQj4

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.1f);
        Destroy(gameObject);
    }
}
