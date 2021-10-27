using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code for NavMesh created based on https://www.youtube.com/watch?v=W-NIYi1t16Q and https://github.com/h8man/NavMeshPlus/wiki/HOW-TO

public class DroneMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        _agent.SetDestination(_target.position);
    }

}
