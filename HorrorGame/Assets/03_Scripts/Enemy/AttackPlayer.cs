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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(navAgent.remainingDistance > 1.4)
        //{

        //}
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
            Debug.Log("Attacking");
            navAgent.SetDestination(pointToFollow.position);
            if(navAgent.remainingDistance > 1.4)
            {
                m_stateMachine.ChangeState(m_character.chase);
            }
            yield return new WaitForSeconds(attackSpan);
        }
    }
}
