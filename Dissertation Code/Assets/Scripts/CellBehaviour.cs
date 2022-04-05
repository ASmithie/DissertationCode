using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellBehaviour : ScriptableObject
{
    public abstract float CalculatePressure(Cell cell, Cell[] neighbourhood, CAGrid grid);

    public abstract float CalculateHeat(Cell cell, Cell[] neighbourhood, CAGrid grid);
}
