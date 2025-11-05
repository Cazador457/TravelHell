using UnityEngine;
using UnityEngine.AI;

public class PatrolForPoints : IPatrol
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int patrolIndex;

    public PatrolForPoints(NavMeshAgent agent, Transform[] patrolPoints, int patrolIndex)
    {
        this.agent = agent;
        this.patrolPoints = patrolPoints;
        this.patrolIndex = patrolIndex;
    }

    public void Destination()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        patrolIndex = 0;
        agent.SetDestination(patrolPoints[patrolIndex].position);
    }

    public void ChangeDestination()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[patrolIndex].position);
        }
    }
}
