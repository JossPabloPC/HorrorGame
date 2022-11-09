using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : PickableObj
{
    public int ammo;
    public override void OnTriggerWithPlayer(PlayerStats playerStats)
    {
        base.OnTriggerWithPlayer(playerStats);
        playerStats.Ammo += ammo;
    }
}
