using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public EnemyAI m_character;
    public StateMachine m_stateMachine;

    public void Init(EnemyAI character, StateMachine stateMachine)
    {
        m_character = character;
        m_stateMachine = stateMachine;
        this.enabled = false;
    }

    //What to do when enters the state
    public virtual void Enter()
    {

    }

    //What to do when exiting the state
    public virtual void Exit()
    {

    }
}
