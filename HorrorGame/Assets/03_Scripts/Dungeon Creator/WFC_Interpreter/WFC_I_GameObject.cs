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
            GameObject tmpRoom =  GameObject.Instantiate(m_primitives.GetFragmentByID(m_grid[0, 0].FinalSolution).Room, Vector3.zero, Quaternion.identity);
            m_roomsList.Add(tmpRoom.GetComponent<Room>());
        }
        else
        {
            Vector3 offset = m_primitives.GetFragmentByID(m_grid[0, 0].FinalSolution).Room.GetComponent<Room>().m_entrance.position;
            Vector3 origin = m_roomsList[m_roomsList.Count - 1].m_exit.position;
            Vector3 position = origin + offset;
            GameObject tmpRoom = GameObject.Instantiate(m_primitives.GetFragmentByID(m_grid[0, m_roomsList.Count].FinalSolution).Room, position, Quaternion.identity);
            m_roomsList.Add(tmpRoom.GetComponent<Room>());
        }
    }


    ///
}
