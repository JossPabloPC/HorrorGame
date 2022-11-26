using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : State
{
    public NavMeshAgent navAgent;
    public Transform pointToFollow;
    public int attackSpan;
    public bool canAttack;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attack");
        canAttack = true;
        StartCoroutine(RoutineAttack());
    }

    public override void Exit()
    {
        base.Exit();
        canAttack = false;
        StopAllCoroutines();
    }

    IEnumerator RoutineAttack()
    {
        while (canAttack)
        {
            if(navAgent.remainingDistance > 1.5)
            {
                m_stateMachine.ChangeState(m_character.chase);
            }
            Debug.Log("Attacking");
            navAgent.SetDestination(pointToFollow.position);
            yield return new WaitForSeconds(attackSpan);
        }
    }
}
