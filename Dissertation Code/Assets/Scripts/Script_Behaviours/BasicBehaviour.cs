using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/Basic")]
public class BasicBehaviour : CellBehaviour
{

    public float addPressure;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        return cell.airPressure >= 255 ? cell.airPressure : cell.airPressure + addPressure;
    }
}
