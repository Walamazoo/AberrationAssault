using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code for NavMesh created based on https://www.youtube.com/watch?v=W-NIYi1t16Q and https://github.com/h8man/NavMeshPlus/wiki/HOW-TO

public class DroneMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

}
