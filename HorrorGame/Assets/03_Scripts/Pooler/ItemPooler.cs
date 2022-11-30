using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPooler : MonoBehaviour
{
    public GameObject healthKit;
    public GameObject ammo;
    public Pooler hkPooler;
    public Pooler ammoPooler;

    public static ItemPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        hkPooler    = new Pooler();
        ammoPooler  = new Pooler();
        hkPooler    .Init(healthKit);
        ammoPooler  .Init(ammo);
    }
}
