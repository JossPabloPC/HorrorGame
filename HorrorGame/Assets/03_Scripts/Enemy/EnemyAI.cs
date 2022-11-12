using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyIdle))]
[RequireComponent(typeof(ChasePlayer))]

public class EnemyAI : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnemyIdle idle;
    public ChasePlayer chase;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        idle = GetComponent<EnemyIdle>();
        chase = GetComponent<ChasePlayer>();

        idle.Init(this, stateMachine);
        chase.Init(this, stateMachine);

        stateMachine.Init(idle);
    }
}
