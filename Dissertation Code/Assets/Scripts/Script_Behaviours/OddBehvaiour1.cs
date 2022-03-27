using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/MultiRuleCA")]
public class OddBehaviour1 : CellBehaviour
{

    public float PressureTransferModifier;
    public float meanOffset;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        float totalPressure = 0;
        float neighbourhoodSize = 0;
        for(int i = 0; i < neighbourhood.Length; i++)
        {
            if(neighbourhood[i] != null)
            {
                totalPressure += neighbourhood[i].airPressure;
                neighbourhoodSize++;
            }
        }

        float averagePressure = totalPressure / neighbourhoodSize;
        PressureTransferModifier = Mathf.Abs(cell.airPressure + averagePressure);

        if(averagePressure > cell.airPressure + meanOffset)
        {
            return cell.airPressure + 1f * PressureTransferModifier;
        }
        else if(averagePressure <= cell.airPressure + meanOffset && averagePressure >= cell.airPressure - meanOffset)
        {
            return cell.airPressure;
        }
        else
        {
            return cell.airPressure - 1f * PressureTransferModifier;
        }
    }
}