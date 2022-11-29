using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChasePlayer : State
{
    public NavMeshAgent navAgent;
    [SerializeField]
    private float attackingDistance;
    public Transform pointToFollow;
    [SerializeField]
    private bool foundPlayer;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (foundPlayer)
        {
            Chase();
            Debug.Log("Te sigo");
            //Debug.Log("Distancia: " + navAgent.remainingDistance);
            //If the enemy is close enough of the player it'll start attacking
            if (navAgent.remainingDistance <= attackingDistance && !navAgent.pathPending)
            {
                //Debug.LogError("Distancia: " + navAgent.remainingDistance);
                m_stateMachine.ChangeState(m_character.attack);
            }
        }
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Te vi");
        foundPlayer = true;

    }

    public override void Exit()
    {
        foundPlayer = false;
        navAgent.SetDestination(this.transform.position);
        base.Exit();
    }

    public void Chase()
    {
        navAgent.SetDestination(pointToFollow.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 0 && other.gameObject.layer != 7)
        {
            m_stateMachine.ChangeState(m_character.idle);
            navAgent.SetDestination(this.transform.position);
            Debug.Log("webos bai");
        }
    }
}
