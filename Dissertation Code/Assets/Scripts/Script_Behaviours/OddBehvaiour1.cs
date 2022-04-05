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
        for (int i = 0; i < neighbourhood.Length; i++)
        {
            if (neighbourhood[i] != null)
            {
                totalPressure += neighbourhood[i].airPressure;
                neighbourhoodSize++;
            }
        }

        float averagePressure = totalPressure / neighbourhoodSize;
        PressureTransferModifier = Mathf.Abs(cell.airPressure + averagePressure);

        if (averagePressure > cell.airPressure + meanOffset)
        {
            return cell.airPressure + 1f * PressureTransferModifier;
        }
        else if (averagePressure <= cell.airPressure + meanOffset && averagePressure >= cell.airPressure - meanOffset)
        {
            return cell.airPressure;
        }
        else
        {
            return cell.airPressure - 1f * PressureTransferModifier;
        }
    }


    public float HeatTransferModifier;
    public float meanHeatOffset;

    public override float CalculateHeat(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        float totalHeat = 0;
        float neighbourhoodSize = 0;
        for (int i = 0; i < neighbourhood.Length; i++)
        {
            if (neighbourhood[i] != null)
            {
                totalHeat += neighbourhood[i].heat;
                neighbourhoodSize++;
            }
        }

        float averageHeat = totalHeat / neighbourhoodSize;
        HeatTransferModifier = Mathf.Abs(cell.heat + averageHeat);

        if (averageHeat > cell.heat + meanHeatOffset)
        {
            return cell.heat + 1f * HeatTransferModifier;
        }
        else if (averageHeat <= cell.heat + meanHeatOffset && averageHeat >= cell.heat - meanHeatOffset)
        {
            return cell.heat;
        }
        else
        {
            return cell.heat - 1f * HeatTransferModifier;
        }
    }
}
