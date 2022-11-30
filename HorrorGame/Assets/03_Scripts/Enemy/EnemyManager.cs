using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IReceiveDamage
{
    public int hP;
    public int damageForce;
    public static State stateInstance;

    [SerializeField]
    private StateMachine stateMachine;

    public EnemyAI enemyAI;

    public bool isBoss;

    // Start is called before the first frame update
    void Start()
    {
        stateInstance = GetComponent<State>();
        stateMachine = GetComponent<StateMachine>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hP <= 0)
        {
            Debug.Log("c va a morir");
            //StateMachine.instance.ChangeState(EnemyAI.instance.die);
            stateMachine.ChangeState(enemyAI.die);
        }
        
    }

    //Receive damage
    [ContextMenu("Damage")]
    public void Damage()
    {
        hP -= damageForce;
        if (isBoss)
        {
            stateMachine.ChangeState(enemyAI.damage);
        }
    }
}

public interface IReceiveDamage
{
    void Damage();
}
