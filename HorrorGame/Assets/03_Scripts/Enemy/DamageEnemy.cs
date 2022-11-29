using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Auch");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
