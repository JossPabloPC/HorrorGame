using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    int m_columns = 10;
    int m_rows = 1;
    PrimitiveList_Data m_sockets_data;

    Wave_Function_Collapse wave_function_collapse;


    Cell[,] m_grid;


    void Start()
    {
        wave_function_collapse = new Wave_Function_Collapse(m_columns, m_rows);
        wave_function_collapse.Load_Primitives(m_sockets_data);
        wave_function_collapse.Create_Grid();
        wave_function_collapse.Create_Rules();
        m_grid = wave_function_collapse.Run(true);

    }

}
