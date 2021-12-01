using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code for NavMesh navigation created based on https://www.youtube.com/watch?v=W-NIYi1t16Q and https://github.com/h8man/NavMeshPlus/wiki/HOW-TO

public class DroneMovement : MonoBehaviour
{
    public Transform target;
    [SerializeField] Transform _defaultTarget;
    [SerializeField] Rigidbody2D _rb;
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        if (target == null)
        {
            target = _defaultTarget;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            target = _defaultTarget;
        }
        _agent.SetDestination(target.position);
    }

    void FixedUpdate()
    {
        float xPos = target.transform.position.x;
        float yPos = target.transform.position.y;
        Vector2 pos = new Vector2(xPos, yPos);

        Vector2 lookDirection = pos - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }

}
