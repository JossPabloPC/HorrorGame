using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator door;

    public bool unlocked;
    public bool inReach;
    public bool locked;
    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        inReach=false;
        hasKey=false;
        unlocked=false;
        locked=true;
    }

    protected void OnTriggerEnter(Collider other)
    {
        PlayerStats psI = other.GetComponent<PlayerStats>();
        if (psI != null&&psI.HasKey)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }    
        if (hasKey && Input.GetKey(KeyCode.E))
        {
            unlocked = true;
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    }

    void DoorOpens ()
    {
        if (unlocked)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            
        }

    }

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
        }

    }

}
