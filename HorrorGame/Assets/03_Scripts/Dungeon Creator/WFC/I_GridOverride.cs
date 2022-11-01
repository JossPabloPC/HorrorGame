using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_GridOverride{

    public void OverrideColumEntropy(int column, int[] newOptions);
    public void OverrideRowEntropy(int row, int[] newOptions);
    public void OverrideSingleCell(int row, int column, int[] new_options);
}
