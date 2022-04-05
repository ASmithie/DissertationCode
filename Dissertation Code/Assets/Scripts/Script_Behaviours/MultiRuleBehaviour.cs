using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/MultiRuleCA")]
public class MultiRuleBehaviour : CellBehaviour
{

    public float PressureTransferModifier;
    public float meanOffset;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        float totalPressure = 0;
        float neighbourhoodSize = 0;
        for (int i = 0; i < neighbourhood.Length; i++)
        {
            if (neighbourhood[i] != null && !neighbourhood[i].isInert)
            {
                totalPressure += neighbourhood[i].airPressure;
                neighbourhoodSize++;
            }
        }

        float averagePressure = totalPressure / neighbourhoodSize;
        //PressureTransferModifier = Mathf.Abs(cell.airPressure + averagePressure);

        if (averagePressure > cell.airPressure + meanOffset)
        {
            return cell.airPressure + PressureTransferModifier * Mathf.InverseLerp(0f, 100000f, averagePressure) * neighbourhoodSize;
        }
        else if (averagePressure <= cell.airPressure + meanOffset && averagePressure >= cell.airPressure)
        {
            return cell.airPressure;
        }
        else if (averagePressure < cell.airPressure && averagePressure > 100f)
        {
            return cell.airPressure - PressureTransferModifier * Mathf.InverseLerp(0f, 100000f, averagePressure) * neighbourhoodSize;
        }
        else
        {
            return cell.airPressure;
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
            if (neighbourhood[i] != null && !neighbourhood[i].isInert)
            {
                totalHeat += neighbourhood[i].heat;
                neighbourhoodSize++;
            }
        }

        float averageHeat = totalHeat / neighbourhoodSize;
        //PressureTransferModifier = Mathf.Abs(cell.airPressure + averagePressure);

        if (averageHeat > cell.heat + meanHeatOffset)
        {
            return cell.heat + HeatTransferModifier * Mathf.InverseLerp(0f, 100f, averageHeat) * neighbourhoodSize;
        }
        else if (averageHeat <= cell.heat + meanHeatOffset && averageHeat >= cell.heat)
        {
            return cell.heat;
        }
        else if (averageHeat < cell.heat && averageHeat > 1f)
        {
            return cell.heat - HeatTransferModifier * Mathf.InverseLerp(0f, 100f, averageHeat) * neighbourhoodSize;
        }
        else
        {
            return cell.heat;
        }
    }
}
