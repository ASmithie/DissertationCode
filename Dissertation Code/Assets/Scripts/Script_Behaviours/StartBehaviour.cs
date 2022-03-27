using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CA/Behaviour/Start")]
public class StartBehaviour : CellBehaviour
{

    public float PressureTransferModifier;

    public override float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid)
    {
        return Random.Range(0f, 100f);
    }
}
