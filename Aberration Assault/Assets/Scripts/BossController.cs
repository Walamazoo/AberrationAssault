using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Healthbar code done with help from https://www.youtube.com/watch?v=cXefXSD2SM0&t=209s

public class BossController : MonoBehaviour
{
    [SerializeField] DroneMovement _drone;

    [SerializeField] int _health = 50;

    [SerializeField] float _speed = 1;
    [SerializeField] GameObject[] _patrolPoints;
    [SerializeField] int _patrolPointIndex = 0;
    [SerializeField] Transform _target;
    [SerializeField] Rigidbody2D _rb;

    private bool _droneAttack = false;

    [SerializeField] Transform[] _firePoints;
    [SerializeField] Transform _bigFirePoint;
    [SerializeField] GameObject _bulletprefab;
    [SerializeField] GameObject _bigBulletprefab;

    [SerializeField] GameObject _player;
    [SerializeField] float _fireDistance = 15f;

    [SerializeField] SpriteRenderer _sprite;
    private Color _normalColor;

    [SerializeField] float _firerate;
    [SerializeField] float _bigFirerate;

    private bool _phase1 = false;
    private bool _phase2 = false;

    public Slider _healthBar;

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
            _healthBar.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (_health <= 400 && _phase1 == false)
        {
            InvokeRepeating("EnemyShoot", 0.5f, _firerate);
            _phase1 = true;
        }

        if (_health <= 200 && _phase2 == false)
        {
            InvokeRepeating("EnemyBigShoot", 0f, _bigFirerate);
            _phase2 = true;
        }

        _healthBar.value = _health;

        //Help with patrolling from https://www.youtube.com/watch?v=8eWbSN2T8TE

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        float xPos = _target.transform.position.x;
        float yPos = _target.transform.position.y;
        Vector2 pos = new Vector2(xPos, yPos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            if (_drone.target == null || _drone.target == _drone.defaultTarget)
            {
                _drone.target = gameObject.transform;
            }
            _health = _health - collision.gameObject.GetComponent<Bullet>()._damage;
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
            _health = _health - _drone._droneDamage;
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
        int point = Random.Range(0, _firePoints.Length);
        if (Vector2.Distance(transform.position, _player.transform.position) < _fireDistance)
        {
            GameObject bullet = Instantiate(_bulletprefab, _firePoints[point].position, Quaternion.identity);
        }
    }

    void EnemyBigShoot()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _fireDistance)
        {
            GameObject bullet = Instantiate(_bigBulletprefab, _bigFirePoint.position, Quaternion.identity);
        }
    }
}
