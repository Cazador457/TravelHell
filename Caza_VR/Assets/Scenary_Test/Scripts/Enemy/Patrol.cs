using UnityEngine;
using UnityEngine.AI;
public class Patrol:MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent _agent;
    private int _patrolIndex;
    private float _arrive = 0.5f;
    [Header("Pursuit")]
    public Transform player;
    public float rangeVision = 5f;
    public float visionAngle = 60f;
    public bool sighted = false;
    public void Destination() //Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            _patrolIndex = 0;
            _agent.SetDestination(patrolPoints[_patrolIndex].position);
        }
    }
    public void ChangeDestination()  //Update si no se ocupa VisionEnemy()
    {
        if (patrolPoints.Length == 0) return;
        if (!_agent.pathPending && _agent.remainingDistance < _arrive)
        {
            _patrolIndex = (_patrolIndex + 1) % patrolPoints.Length;
            _agent.SetDestination(patrolPoints[_patrolIndex].position);
        }
    }
    /*bool SightedPlayer()
    {
        Vector3 rutePlayer = (player.position - transform.position.normalized);
        float proxPLayer = Vector3.Distance(transform.position, player.position);
        if (proxPLayer <= rangeVision)
        {
            float angleSight = Vector3.Angle(transform.forward, rutePlayer);
            if(angleSight<=visionAngle)
        }
    }
    void VisionEnemy()  //Update()
    {
        if (SightedPlayer())
        {
            sighted = true;
            _agent.SetDestination(player.position);
        }
        else
        {
            if (sighted)
            {
                sighted = false;
                ChangeDestination();
            }
        }
    }*/
}
