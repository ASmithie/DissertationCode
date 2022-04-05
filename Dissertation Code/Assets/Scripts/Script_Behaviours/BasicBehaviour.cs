using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/Basic")]
public class BasicBehaviour : CellBehaviour
{

    public float addPressure;

    public float addHeat;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        return cell.airPressure + addPressure;
    }

    public override float CalculateHeat(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        return cell.heat + addHeat;
    }
}
