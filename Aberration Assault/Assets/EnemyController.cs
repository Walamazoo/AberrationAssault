using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] DroneMovement _drone;

    [SerializeField] int _health = 50;

    [SerializeField] GameObject[] _patrolPoints;
    [SerializeField] int _patrolPointIndex = 0;
    [SerializeField] Transform _target;
    [SerializeField] Rigidbody2D _rb;
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _target = _patrolPoints[0].transform;
        _agent.SetDestination(_target.position);
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
            //damage
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone") == true)
        {
            //damage
        }
        if (collision.gameObject.CompareTag("PatrolPoint") == true)
        {
            _patrolPointIndex++;
            if (_patrolPointIndex >= _patrolPoints.Length)
            {
                _patrolPointIndex = 0;
            }
            _target = _patrolPoints[_patrolPointIndex].transform;
            _agent.SetDestination(_target.position);
        }
    }

}
