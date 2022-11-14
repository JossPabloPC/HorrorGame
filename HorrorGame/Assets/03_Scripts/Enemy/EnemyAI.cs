using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyIdle))]
[RequireComponent(typeof(ChasePlayer))]
[RequireComponent(typeof(AttackPlayer))]

public class EnemyAI : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnemyIdle idle;
    public ChasePlayer chase;
    public AttackPlayer attack;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        idle = GetComponent<EnemyIdle>();
        chase = GetComponent<ChasePlayer>();
        attack = GetComponent<AttackPlayer>();

        idle.Init(this, stateMachine);
        chase.Init(this, stateMachine);
        attack.Init(this, stateMachine);

        stateMachine.Init(idle);
    }
}
