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

        for(int i = 0; i < neighbourhood.Length; i++)
        {
            if(neighbourhood[i] != null)
            {
                totalPressure += neighbourhood[i].airPressure;
            }
        }

        if(totalPressure / 6 >= cell.airPressure)
        {
            return cell.airPressure >= 255f ? cell.airPressure : cell.airPressure + totalPressure * PressureTransferModifier;
        } else
        {
            return cell.airPressure <= 0f ? cell.airPressure : cell.airPressure - totalPressure * PressureTransferModifier;
        }
    }
}
