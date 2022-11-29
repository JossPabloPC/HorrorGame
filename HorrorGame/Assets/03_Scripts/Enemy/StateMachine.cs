using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State m_currentState;

    public State lastState;

    public void Init(State firstState)
    {
        m_currentState = firstState;
        firstState.enabled = true;
        firstState.Enter();
    }

    public void ChangeState(State newState)
    {
        m_currentState.Exit();
        lastState = m_currentState;
        m_currentState.enabled = false;
        m_currentState = newState;
        m_currentState.enabled = true;
        newState.Enter();
    }

    public State GetCurrentState()
    {
        return m_currentState;
    }
}
