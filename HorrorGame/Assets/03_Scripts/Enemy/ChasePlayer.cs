using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChasePlayer : State
{
    public NavMeshAgent navAgent;
    public Transform pointToFollow;
    [SerializeField]
    private bool foundPlayer;

    private void Update()
    {
        if (foundPlayer)
        {
            Chase();
            Debug.Log("Te sigo");
            if (navAgent.remainingDistance <= 1.4)
            {
                //Debug.Log("Attack");
                m_stateMachine.ChangeState(m_character.attack);
            }
        }
        else if (!foundPlayer)
        {
            Debug.Log("Idle");
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
        base.Exit();
        foundPlayer = false;
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
            Debug.Log("webos bai");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer != 0)
    //    {
    //        foundPlayer = true;
    //        Enter();
    //    }
    //}
}
