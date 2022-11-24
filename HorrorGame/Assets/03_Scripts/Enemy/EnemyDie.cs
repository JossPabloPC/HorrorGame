using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Moricion");
        /// TO DO: Ejecutar animacion
        this.gameObject.SetActive(false);
        //m_stateMachine.ChangeState(m_character.chase);
    }

    public override void Exit()
    {
        base.Exit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
