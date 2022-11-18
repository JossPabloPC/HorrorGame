using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyIdle : State
{
    bool canIdle;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Estoy en Idle");
        canIdle = true;
        //m_stateMachine.ChangeState(m_character.chase);
    }

    public override void Exit()
    {
        base.Exit();
        canIdle = false;
    }

    private void Update()
    {
        if (canIdle)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 0 && other.gameObject.layer != 7)
        {
            m_stateMachine.ChangeState(m_character.chase);
            Debug.Log("webos");
        }
    }

    [ContextMenu("Disparo")]
    public void GotShot()
    {
        m_stateMachine.ChangeState(m_character.chase);
        Debug.Log("Me dispararon");
    }
}
