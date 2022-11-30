using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    public Transform m_entrance;
    public Transform m_exit;

    public int roomNumber;
    public bool isBeforeBoss;

    [SerializeField] private NavMeshSurface [] roomsSurfaces;

    private void Start()
    {
        DungeonCreator.Instace.rebuildNavMesh += RebuildNavMesh;
    }

    private void RebuildNavMesh()
    {
        for(int i = 0; i<roomsSurfaces.Length; i++)
        {
            roomsSurfaces[i].BuildNavMesh();
        }
    }
}