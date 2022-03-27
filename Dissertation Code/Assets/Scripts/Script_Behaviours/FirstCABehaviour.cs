using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/FirstCA")]
public class FirstCABehaviour : CellBehaviour
{

    public float PressureTransferModifier;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        float totalPressure = 0;
        float neighbourhoodSize = 0;
        for (int i = 0; i < neighbourhood.Length; i++)
        {
            if (neighbourhood[i] != null)
            {
                totalPressure += neighbourhood[i].airPressure;
                neighbourhoodSize++;
            }
        }

        float averagePressure = totalPressure / neighbourhoodSize;

        if (averagePressure >= cell.airPressure)
        {
            return cell.airPressure + averagePressure * PressureTransferModifier;
        } else
        {
            return cell.airPressure - averagePressure * PressureTransferModifier;
        }
    }
}
