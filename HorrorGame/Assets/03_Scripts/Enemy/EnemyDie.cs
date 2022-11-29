using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : State
{
    public float dissableAfter;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Moricion");
        StartCoroutine(DieTime());
    }

    public override void Exit()
    {
        base.Exit();
    }

    //Dissables Zombie's GameObject after dissableAfter seconds 
    IEnumerator DieTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(dissableAfter);

            this.gameObject.SetActive(false);
        }
    }
}
