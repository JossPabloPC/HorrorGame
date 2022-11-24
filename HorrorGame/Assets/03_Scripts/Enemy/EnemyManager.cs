using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hP;
    public static State stateInstance;

    // Start is called before the first frame update
    void Start()
    {
        stateInstance = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hP <= 0)
        {
            //m_stateMachine.ChangeState(m_character.chase);
            Debug.Log("c va a morir");
            stateInstance.m_stateMachine.ChangeState(stateInstance.m_character.die);
        }
        
    }
}
