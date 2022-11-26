using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : State
{
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

    //Dissables Zombie's GameObject after 3s 
    IEnumerator DieTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            this.gameObject.SetActive(false);
        }
    }
}
