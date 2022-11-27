using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimations : MonoBehaviour
{
    public State currentState;

    public Animator wizardAnimator;
    public StateMachine stateMachine;
    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        wizardAnimator = GetComponent<Animator>();
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
            wizardAnimator.SetBool("Chasing", true);
            wizardAnimator.SetBool("Attacking", false);
        }
        else if (currentState == enemyAI.attack)//EnemyAI.instance.attack)
        {
            wizardAnimator.SetBool("Chasing", false);
            wizardAnimator.SetBool("Attacking", true);
        }
        else if (currentState == enemyAI.die)//EnemyAI.instance.die)
        {
            wizardAnimator.SetTrigger("Die");
        }
        else
        {
            wizardAnimator.SetBool("Attacking", false);
            wizardAnimator.SetBool("Chasing", false);

        }
    }
}
