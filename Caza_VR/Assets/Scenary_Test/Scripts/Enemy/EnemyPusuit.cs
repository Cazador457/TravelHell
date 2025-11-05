using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyPusuit : Enemy
{
    public GameObject target;
    private NavMeshAgent agent;
    private float stopRange=1.5f;
    private Transform targetT;
    private void Start()
    {
        target = GameObject.Find("XR Origin Hands (XR Rig)");
        targetT=target.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override void OnEnable()
    {
        LightMovPatrol.OnPursuit += Pursuit;
        
    }
    private void OnDisable()
    {
        LightMovPatrol.OnPursuit -= Pursuit;
    }
    void Pursuit()
    {
        float distance = Vector3.Distance(agent.nextPosition,targetT.position);
        if (distance > stopRange)
        {
            agent.SetDestination(targetT.position);
        }
        else if (distance < stopRange)
        {
            ataak();
        }
    }
    private void ataak()
    {
        Debug.Log("Atacando");
    }
}
