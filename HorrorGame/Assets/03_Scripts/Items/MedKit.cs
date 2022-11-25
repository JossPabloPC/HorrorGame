using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : PickableObj
{
    public int health;
    public override void OnTriggerWithPlayer(PlayerStats playerStats)
    {
        base.OnTriggerWithPlayer(playerStats);
        playerStats.Health += health;
        ItemPooler.Instance.hkPooler.Release(this.gameObject);

    }
}
