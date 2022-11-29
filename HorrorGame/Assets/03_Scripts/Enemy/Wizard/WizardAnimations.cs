using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimations : MonoBehaviour
{
    public State currentState;

    public Animator wizardAnimator;
    public StateMachine stateMachine;
    public EnemyAI enemyAI;
    public EnemyManager manager;

    [SerializeField]
    private bool isHurting;

    [SerializeField]
    private float time2Resume;

    // Start is called before the first frame update
    void Start()
    {
        wizardAnimator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        enemyAI = GetComponent<EnemyAI>();
        manager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentState = StateMachine.instance.GetCurrentState();
        currentState = stateMachine.GetCurrentState();
        if (currentState == enemyAI.chase) //EnemyAI.instance.chase)
        {
            wizardAnimator.SetBool("Idle", false);
            wizardAnimator.SetBool("Chasing", true);
            wizardAnimator.SetBool("Attacking", false);
        }
        else if (currentState == enemyAI.attack)//EnemyAI.instance.attack)
        {
            Debug.Log("aki ehe");
            wizardAnimator.SetBool("Idle", false);
            wizardAnimator.SetBool("Chasing", false);
            wizardAnimator.SetBool("Attacking", true);
        }
        else if (currentState == enemyAI.die)//EnemyAI.instance.die)
        {
            wizardAnimator.SetTrigger("Die");
        }
        else if(manager.isBoss && currentState == enemyAI.damage && !isHurting)
        {
            Debug.Log("boi ejecutar animacion");
            wizardAnimator.SetTrigger("Damage");
            isHurting = true;
            StartCoroutine(Resume());
        }
        else if(currentState == enemyAI.idle)
        {
            wizardAnimator.SetBool("Idle", true);
            wizardAnimator.SetBool("Chasing", false);
            wizardAnimator.SetBool("Attacking", false);
        }
    }
    IEnumerator Resume()
    {
        yield return new WaitForSeconds(2f);
        stateMachine.ChangeState(stateMachine.lastState);
        isHurting = false;
    }

}
