using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IReceiveDamage
{
    public int hP;
    public int hitForce;
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
            Debug.Log("c va a morir");
            //stateInstance.m_stateMachine.ChangeState(stateInstance.m_character.die);
            StateMachine.instance.ChangeState(EnemyAI.instance.die);
        }
        
    }

    public void Damage()
    {
        hP -= hitForce;
    }
}

public interface IReceiveDamage
{
    void Damage();
}
