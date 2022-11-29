using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Pickung up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            this.gameObject.SetActive(false);
        }
    }
}
