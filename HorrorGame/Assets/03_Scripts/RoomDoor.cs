using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class RoomDoor : MonoBehaviour
{
    public UnityEvent   onDoorOpen;
    private BoxCollider m_collider;
    private void Start()
    {
        m_collider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        RoomTrigger tmp = other.GetComponent<RoomTrigger>();
        if (tmp != null)
        {
            DungeonCreator.Instace.DisplayNextRoom();
            m_collider.enabled = false;
            onDoorOpen.Invoke();
        }
    }
}
