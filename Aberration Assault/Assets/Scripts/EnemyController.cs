using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for sprite color changing on lines 37-38 and 110 from https://stuartspixelgames.com/2019/02/19/how-to-change-sprites-colour-or-transparency-unity-c/

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
    [SerializeField] GameObject _bulletprefab;

    [SerializeField] GameObject _player;
    [SerializeField] float _fireDistance = 15f;

    [SerializeField] SpriteRenderer _sprite;
    private Color _normalColor;

    [SerializeField] int _droprate;
    [SerializeField] GameObject _healthDropPrefab;
    [SerializeField] GameObject _materialDropPrefab;

    [SerializeField] float _firerate;

    void Start()
    {
        _target = _patrolPoints[0].transform;

        InvokeRepeating("Damage", 0f, 0.5f);
        InvokeRepeating("EnemyShoot", 0f, _firerate);

        _sprite = GetComponent<SpriteRenderer>();
        _normalColor = _sprite.color;
    }

    void Update()
    {
        if (_health <= 0)
        {
            if (Random.Range(1, _droprate) == 1)
            {
                GameObject HealthDrop = Instantiate(_healthDropPrefab, gameObject.transform.position, Quaternion.identity);
            }
            if (Random.Range(1, _droprate) == 2)
            {
                GameObject MaterialDrop = Instantiate(_materialDropPrefab, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        //Help with patrolling from https://www.youtube.com/watch?v=8eWbSN2T8TE

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
            _drone.target = gameObject.transform;
            _health = _health - 2;
            StartCoroutine(damageFlash());
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
            StartCoroutine(damageFlash());
        }
    }

    IEnumerator damageFlash()
    {
        _sprite.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        _sprite.color = _normalColor;
    }

    //Help with shooting from https://www.youtube.com/watch?v=_Z1t7MNk0c4&list=PLBIb_auVtBwDgHLhYc-NG633rTbTPim9z&index=2
    void EnemyShoot()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _fireDistance)
        {
            GameObject bullet = Instantiate(_bulletprefab, _firePoint.position, Quaternion.identity);
        }
    }

}
