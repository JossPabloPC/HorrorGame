using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZombieAnimations))]

public class EnemyManager : MonoBehaviour, IReceiveDamage
{
    public int hP;
    public int damageForce;
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
            StateMachine.instance.ChangeState(EnemyAI.instance.die);
        }
        
    }

    //Receive damage
    public void Damage()
    {
        hP -= damageForce;
    }
}

public interface IReceiveDamage
{
    void Damage();
}
