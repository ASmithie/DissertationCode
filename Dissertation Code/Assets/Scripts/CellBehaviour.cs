using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellBehaviour : ScriptableObject
{
    public abstract float CalculatePressure(Cell cell, List<Cell> neighbourhood, CAGrid grid);
}
