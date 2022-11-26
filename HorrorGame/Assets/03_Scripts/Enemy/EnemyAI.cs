using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyIdle))]
[RequireComponent(typeof(ChasePlayer))]
[RequireComponent(typeof(AttackPlayer))]
[RequireComponent(typeof(EnemyDie))]

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public StateMachine stateMachine;
    public EnemyIdle idle;
    public ChasePlayer chase;
    public AttackPlayer attack;
    public EnemyDie die;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        idle = GetComponent<EnemyIdle>();
        chase = GetComponent<ChasePlayer>();
        attack = GetComponent<AttackPlayer>();
        die = GetComponent<EnemyDie>();

        idle.Init(this, stateMachine);
        chase.Init(this, stateMachine);
        attack.Init(this, stateMachine);
        die.Init(this, stateMachine);

        stateMachine.Init(idle);
    }
}
