using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WFC_Interpreter
{
    protected   Cell    [,] m_grid;
    public WFC_Interpreter(Cell[,] grid)
    {
        m_grid = grid;
    }

}
