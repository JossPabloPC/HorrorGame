using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class RoomDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RoomTrigger tmp = other.GetComponent<RoomTrigger>();
        if (tmp != null)
        {
            DungeonCreator.Instace.m_RoomCreator.DisplayNextRoom();
        }
    }
}
