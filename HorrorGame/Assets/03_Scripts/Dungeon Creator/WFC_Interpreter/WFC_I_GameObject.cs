using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC_I_GameObject : WFC_Interpreter
{
    private PrimitiveList_Data m_primitives;
    private int m_roomsCreated;
    private List<Room> m_roomsList;

    public WFC_I_GameObject(Cell[,] grid, PrimitiveList_Data primitives):base(grid)
    { 
        m_grid = grid;
        m_primitives = primitives;
        m_roomsCreated = 0;
    }
    /// <summary>
    /// Instantiates game objects with the given distance
    /// </summary>
    public void DisplayNextRoom()
    {
        
    }


    ///
}
