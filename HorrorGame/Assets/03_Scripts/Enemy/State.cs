using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected EnemyAI m_character;
    protected StateMachine m_stateMachine;

    public void Init(EnemyAI character, StateMachine stateMachine)
    {
        m_character = character;
        m_stateMachine = stateMachine;
        this.enabled = false;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}
