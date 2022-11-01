using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    [SerializeField] private int                m_columns   = 10;
    [SerializeField] private int                m_rows      = 1;
    [SerializeField] private PrimitiveList_Data m_sockets_data;

    Wave_Function_Collapse wave_function_collapse;
    public WFC_I_GameObject m_RoomCreator;


    Cell[,] m_grid;


    void Start()
    {
        wave_function_collapse = new Wave_Function_Collapse(m_columns, m_rows);
        wave_function_collapse.Load_Primitives(m_sockets_data);
        wave_function_collapse.Create_Grid();
        wave_function_collapse.Create_Rules();

        wave_function_collapse.OverrideRowEntropy(0,new int[] {2,3,4});
        wave_function_collapse.OverrideSingleCell(0, 0, new int[] {0});
        wave_function_collapse.OverrideSingleCell(0, m_columns - 1, new int[] {1});

        m_grid = wave_function_collapse.Run(false);

        m_RoomCreator = new WFC_I_GameObject(m_grid, m_sockets_data);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed");
            m_RoomCreator.DisplayNextRoom();
        }
    }

}
