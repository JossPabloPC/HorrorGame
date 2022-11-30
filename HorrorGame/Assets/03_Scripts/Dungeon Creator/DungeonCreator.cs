using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DungeonCreator : MonoBehaviour
{
    public delegate void Notify();
    public event Notify rebuildNavMesh;

    [SerializeField] private int                m_columns   = 10;
    public int                roomNumbers;
    [SerializeField] private int                m_rows      = 1;
    [SerializeField] private PrimitiveList_Data m_sockets_data;

    private Wave_Function_Collapse wave_function_collapse;
    private  WFC_I_GameObject m_RoomCreator;
    public static DungeonCreator Instace;


    Cell[,] m_grid;

    private void Awake()
    {
        Instace = this;
    }

    void Start()
    {
        roomNumbers = 1;
        wave_function_collapse = new Wave_Function_Collapse(m_columns, m_rows);
        wave_function_collapse.Load_Primitives(m_sockets_data);
        wave_function_collapse.Create_Grid();
        wave_function_collapse.Create_Rules();

        wave_function_collapse.OverrideRowEntropy(0,new int[] {2,3,4,5});
        wave_function_collapse.OverrideSingleCell(0, 0, new int[] {0});
        getRoomWithKey(6);
        wave_function_collapse.OverrideSingleCell(0, m_columns - 1, new int[] {1});

        m_grid = wave_function_collapse.Run(false);

        m_RoomCreator = new WFC_I_GameObject(m_grid, m_sockets_data);

    }


    private void getRoomWithKey(int roomWithKeyID)
    {
        int room = Random.Range(1, m_columns-1);
        wave_function_collapse.OverrideSingleCell(0, room, new int[] { roomWithKeyID });
    }

    public void DisplayNextRoom()
    {
        roomNumbers ++;
        Room room = m_RoomCreator.DisplayNextRoom();
        if(roomNumbers == m_columns - 1 ){
            room.isBeforeBoss = true;
        }
        else{
            room.isBeforeBoss = false;
        }
        rebuildNavMesh.Invoke();
    }
}
