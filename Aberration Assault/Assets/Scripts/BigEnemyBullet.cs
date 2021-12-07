using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyBullet : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] float _bulletForce = 10f;

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
        GameObject split = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f) * _bulletForce, ForceMode2D.Impulse);
        GameObject split2 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * _bulletForce, ForceMode2D.Impulse);
        GameObject split3 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split3.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0) * _bulletForce, ForceMode2D.Impulse);
        GameObject split4 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split4.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, -1f) * _bulletForce, ForceMode2D.Impulse);
        GameObject split5 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split5.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1f) * _bulletForce, ForceMode2D.Impulse);
        GameObject split6 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split6.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, -1f) * _bulletForce, ForceMode2D.Impulse);
        GameObject split7 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split7.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0) * _bulletForce, ForceMode2D.Impulse);
        GameObject split8 = Instantiate(_splitBulletPrefab, transform.position, Quaternion.identity);
        split8.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * _bulletForce, ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
