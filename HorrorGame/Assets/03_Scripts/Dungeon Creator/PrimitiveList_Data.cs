using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName ="ScriptableObjects/Mood data", order = 2)]
[System.Serializable]
public class PrimitiveList_Data : ScriptableObject
{
    public List<Fragment_Data> fragmentList;

    /// <summary>
    /// Get a fragment from the list by giving its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Fragment_Data GetFragmentByID(int id)
    {
        for(int i =0; i< fragmentList.Count; i++)
        {
            if (id == fragmentList[i].id)
                return fragmentList[i];
        }
        return null;
    }
}
