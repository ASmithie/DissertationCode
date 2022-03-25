using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/Basic")]
public class CABehaviour : CellBehaviour
{

    public float addPressure;

    public override float CalculatePressure(Cell cell, List<Cell> neighbourhood, CAGrid grid)
    {
        return cell.airPressure + addPressure;
    }
}
