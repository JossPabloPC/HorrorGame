using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public static State instance;
    public EnemyAI m_character;
    public StateMachine m_stateMachine;

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
