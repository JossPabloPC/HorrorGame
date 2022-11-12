using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private int _ammo;
    [SerializeField]private int _health;

    public int Ammo
    {
        set { _ammo = value; }
        get { return _ammo; }
    }

    public int Health { get => _health; set => _health = value; }
}
