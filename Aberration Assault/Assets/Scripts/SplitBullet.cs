using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : MonoBehaviour
{
    [SerializeField] float _speed = 10;

    [SerializeField] GameObject _hitEffect;

    private Vector2 _target;

    void Start()
    {
        _target = new Vector2(0, 1) * 5;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position.x == _target.x && transform.position.y == _target.y)
        {
            DestroyProjectile();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.1f);
        Destroy(gameObject);
    }
}
