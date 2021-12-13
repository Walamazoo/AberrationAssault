using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBullet : MonoBehaviour
{
    [SerializeField] float _speed = 20;

    [SerializeField] GameObject _hitEffect;

    public int _damage;
    public Transform _enemy;

    private Vector2 _target;

    void Start()
    {
        _target = new Vector2(_enemy.position.x, _enemy.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position.x * 2 == _target.x * 2 && transform.position.y * 2 == _target.y * 2)
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
