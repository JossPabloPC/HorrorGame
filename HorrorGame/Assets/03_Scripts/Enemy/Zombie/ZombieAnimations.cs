using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
    public State currentState;

    public Animator zombieAnimator;
    public StateMachine stateMachine;
    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentState = StateMachine.instance.GetCurrentState();
        currentState = stateMachine.GetCurrentState();
        if (currentState == enemyAI.chase) //EnemyAI.instance.chase)
        {
            zombieAnimator.SetBool("Chasing", true);
            zombieAnimator.SetBool("Attacking", false);
        }
        else if(currentState == enemyAI.attack)//EnemyAI.instance.attack)
        {
            zombieAnimator.SetBool("Attacking", true);
        }
        else if(currentState == enemyAI.die)//EnemyAI.instance.die)
        {
            zombieAnimator.SetTrigger("Die");
        }
        else
        {
            zombieAnimator.SetBool("Attacking", false);
            zombieAnimator.SetBool("Chasing", false);

        }
    }
}
