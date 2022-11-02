using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC_I_GameObject : WFC_Interpreter
{
    private PrimitiveList_Data m_primitives;
    private List<Room> m_roomsList;

    public WFC_I_GameObject(Cell[,] grid, PrimitiveList_Data primitives):base(grid)
    { 
        m_grid = grid;
        m_primitives = primitives;
        m_roomsList = new List<Room>();
        DisplayNextRoom();

    }
    /// <summary>
    /// Instantiates game objects with the given distance
    /// </summary>
    public void DisplayNextRoom()
    {
        int roomToInstance = m_roomsList.Count;
        if (roomToInstance == 0)
        {
            GameObject tmpRoom          =  RoomPooler.poolOfRooms[m_grid[0,0].FinalSolution].Get();
            tmpRoom.transform.position  =  Vector3.zero;
            m_roomsList.Add(tmpRoom.GetComponent<Room>());
        }
        else if(roomToInstance < m_grid.GetLength(1))
        {
            Vector3 offset              = m_primitives.GetFragmentByID(m_grid[0, roomToInstance].FinalSolution).Room.GetComponent<Room>().m_entrance.position;
            Vector3 origin              = m_roomsList[roomToInstance - 1].m_exit.position;
            GameObject tmpRoom          = RoomPooler.poolOfRooms[m_grid[0,roomToInstance].FinalSolution].Get();
            tmpRoom.transform.position  = origin - offset;
            m_roomsList.Add(tmpRoom.GetComponent<Room>());
        }
    }
}
