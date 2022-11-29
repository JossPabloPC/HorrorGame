using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickableObj
{
    public override void OnTriggerWithPlayer(PlayerStats playerStats)
    {
        base.OnTriggerWithPlayer(playerStats);
        playerStats.HasKey = true;
        gameObject.SetActive(false);
    }
}
