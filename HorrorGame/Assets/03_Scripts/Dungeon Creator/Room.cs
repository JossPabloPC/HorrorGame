using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    public Transform m_entrance;
    public Transform m_exit;

    [SerializeField] private NavMeshSurface [] romsSurfaces;

    private void OnEnable()
    {
        Debug.Log("CreateNavMesh");
    }
}