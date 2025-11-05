using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : Enemy
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;
    private StateMachine stateMachine;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    private int currentPoint = 0;

    public Transform player;

    public void Initialized()
    {
        _patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex);
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
        Initialized();
        stateMachine = new StateMachine();
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        _patrolMovement?.ChangeDestination();
    }
    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pursuit();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _patrolMovement?.ChangeDestination();
        }
    }
    public void Pursuit()
    {
        StartCoroutine(Pursuits());
    }
    IEnumerator Pursuits()
    {
        StartCoroutine(RotateTowardsPlayer());
        yield return new WaitForSeconds(1.5f);
        agent.SetDestination(player.position);
    }
    IEnumerator RotateTowardsPlayer()
    {
        float elapsed = 0;
        float waittime = 1.5f;
        while (elapsed < waittime && player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }


}
