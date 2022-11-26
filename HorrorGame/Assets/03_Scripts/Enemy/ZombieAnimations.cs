using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
    public State currentState;

    public Animator zombieAnimator;

    // Start is called before the first frame update
    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = StateMachine.instance.GetCurrentState();
        if (currentState == EnemyAI.instance.chase)
        {
            zombieAnimator.SetBool("Chasing", true);
            zombieAnimator.SetBool("Attacking", false);
        }
        else if(currentState == EnemyAI.instance.attack)
        {
            zombieAnimator.SetBool("Attacking", true);
        }
        else if(currentState == EnemyAI.instance.die)
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
