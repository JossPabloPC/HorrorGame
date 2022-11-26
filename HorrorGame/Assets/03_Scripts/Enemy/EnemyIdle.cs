using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyIdle : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Estoy en Idle");
        //canIdle = true;
    }

    public override void Exit()
    {
        base.Exit();
        //canIdle = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 0 && other.gameObject.layer != 7)
        {
            m_stateMachine.ChangeState(m_character.chase);
        }
    }

    [ContextMenu("Disparo")]
    public void GotShot()
    {
        m_stateMachine.ChangeState(m_character.chase);
        Debug.Log("Me dispararon");
    }
}
