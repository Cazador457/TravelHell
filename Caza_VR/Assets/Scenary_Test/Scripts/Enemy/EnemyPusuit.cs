using UnityEngine;
using UnityEngine.AI;
using System;
using Unity.VisualScripting;
public class EnemyPusuit : Enemy
{
    public static Action OnRespawn;

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

    public override void Die()
    {
        OnRespawn?.Invoke();
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
