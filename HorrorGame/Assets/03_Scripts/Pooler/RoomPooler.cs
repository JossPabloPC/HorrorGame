using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPooler : MonoBehaviour
{
    public static Dictionary<int, Pooler> poolOfRooms;

    [SerializeField] private PrimitiveList_Data m_sockets_data;
    

    private void Awake()
    {
        poolOfRooms = new Dictionary<int, Pooler>();

        for (int i = 0; i < m_sockets_data.fragmentList.Count; i++)
        {
            poolOfRooms.Add(m_sockets_data.fragmentList[i].id, new Pooler());
            poolOfRooms[i].Init(m_sockets_data.fragmentList[i].Room);
        }
        
    }
}
