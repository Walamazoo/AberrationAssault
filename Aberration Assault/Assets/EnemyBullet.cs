using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for everything except lines 11 and 39-41 https://www.youtube.com/watch?v=_Z1t7MNk0c4&list=PLBIb_auVtBwDgHLhYc-NG633rTbTPim9z&index=2

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    
    [SerializeField] GameObject _hitEffect;

    private Transform _player;
    private Vector2 _target;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = new Vector2(_player.position.x, _player.position.y);
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
