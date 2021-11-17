using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyBullet : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] GameObject _splitBulletPrefab;

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
        /*
        for (int i=0;i<8;i++)
        {
            GameObject split = Instantiate(_splitBulletPrefab, transform.position, Quaternion.Euler((45 * i), 0, 0));
        }
        */
        
        Destroy(gameObject);
    }
}
