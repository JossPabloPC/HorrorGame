using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : State
{
    public bool isHurting;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Auch");
        isHurting = false;
        //StartCoroutine(Resume());
    }

    IEnumerator Resume()
    {
        isHurting = true;
        yield return new WaitForSeconds(3);
    }

    public override void Exit()
    {
        isHurting = false;
        base.Exit();
    }
}
