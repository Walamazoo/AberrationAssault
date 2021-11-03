using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Help with patrolling from https://www.youtube.com/watch?v=8eWbSN2T8TE

public class EnemyController : MonoBehaviour
{
    [SerializeField] DroneMovement _drone;

    [SerializeField] int _health = 50;

    [SerializeField] float _speed = 1;
    [SerializeField] GameObject[] _patrolPoints;
    [SerializeField] int _patrolPointIndex = 0;
    [SerializeField] Transform _target;
    [SerializeField] Rigidbody2D _rb;

    private bool _droneAttack = false;

    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _player;
    [SerializeField] GameObject _bulletprefab;

    [SerializeField] float _bulletForce = 10f;

    void Start()
    {
        _target = _patrolPoints[0].transform;

        InvokeRepeating("Damage", 0f, 1.0f);
        //InvokeRepeating("EnemyShoot", 0f, 3f);

    }

    void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    void FixedUpdate()
    {

        float xPos = _target.transform.position.x;
        float yPos = _target.transform.position.y;
        Vector2 pos = new Vector2(xPos, yPos);

        Vector2 lookDirection = pos - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            _drone._target = gameObject.transform;
            _health = _health - 2;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone") == true)
        {
            _droneAttack = true;
        }
        if (collision.gameObject.CompareTag("PatrolPoint") == true)
        {
            _patrolPointIndex++;
            if (_patrolPointIndex >= _patrolPoints.Length)
            {
                _patrolPointIndex = 0;
            }
            _target = _patrolPoints[_patrolPointIndex].transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone") == true)
        {
            _droneAttack = false;
        }
    }

    void Damage()
    {
        if (_droneAttack == true)
        {
            _health = _health - 5;
        }
    }

    void EnemyShoot()
    {
        GameObject bullet = Instantiate(_bulletprefab, _firePoint.position, _player.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_player.up * _bulletForce, ForceMode2D.Impulse);
    }

}
