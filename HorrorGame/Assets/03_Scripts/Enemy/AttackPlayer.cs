using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : State
{
    public NavMeshAgent navAgent;
    public Transform pointToFollow;
    [SerializeField]
    private float attackingDistance;
    public int attackSpan;
    public bool canAttack;
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log("Distancia: " + navAgent.remainingDistance);
    }

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
            //yield return new WaitForSeconds(attackSpan);
            navAgent.SetDestination(pointToFollow.position);
            if(navAgent.remainingDistance > attackingDistance && !navAgent.pathPending)
            {
                m_stateMachine.ChangeState(m_character.chase);
                Debug.LogError("aki");
            }
            Debug.Log("Attacking");
            yield return new WaitForEndOfFrame();
        }
    }
}
