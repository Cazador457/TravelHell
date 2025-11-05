using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyMeleVar : Enemy
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    private int currentPoint = 0;

    private bool initialized = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (initialized)
        {
            _patrolMovement?.ChangeDestination();
        }
    }
}
