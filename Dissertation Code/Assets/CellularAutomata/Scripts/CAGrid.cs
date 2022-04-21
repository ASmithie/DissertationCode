using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAGrid : MonoBehaviour
{

    public int xLength;
    public int yLength;
    public int zLength;


    //public List<Cell> cells = new List<Cell>();
    public Cell[,,] cells;

    public Cell cell;

    public CellBehaviour behaviour;
    public CellBehaviour startBehaviour;

    public int stepRate = -1;

    int stepCurrent = 0;

    // Start is called before the first frame update
    void Start()
    {

        cells = new Cell[xLength, yLength, zLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    Cell newCell = Instantiate(cell, new Vector3(x, y, z), Quaternion.identity, transform);
                    //cells.Add(newCell);
                    cells[x, y, z] = newCell;
                    //newCell.airPressure = Random.Range(0f, 1f);

                }
            }
        }

        foreach (Cell c in cells)
        {
            Cell[] neighbourhood = new Cell[6];
            float newPressure = startBehaviour.CalculatePressure(c, neighbourhood, this);
            float newHeat = startBehaviour.CalculateHeat(c, neighbourhood, this);
            c.UpdatePressure(newPressure);
            c.UpdateHeat(newHeat);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (stepCurrent < stepRate || stepRate == -1)
        {
            stepCurrent++;
            float[,,] newPressures = new float[xLength, yLength, zLength];
            float[,,] newHeats = new float[xLength, yLength, zLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    for (int z = 0; z < zLength; z++)
                    {
                        Cell[] neighbourhood = new Cell[6];
                        neighbourhood = FindNeighbourhood(cells[x, y, z]);
                        float newPressure = behaviour.CalculatePressure(cells[x, y, z], neighbourhood, this);
                        newPressures[x, y, z] = newPressure;
                        float newHeat = behaviour.CalculateHeat(cells[x, y, z], neighbourhood, this);
                        newHeats[x, y, z] = newHeat;
                    }
                }
            }

            UpdateCells(newPressures, newHeats);
        }

        if (Input.GetButtonDown("Jump")) { stepCurrent = 0; }
    }

    void UpdateCells(float[,,] newPressures, float[,,] newHeats)
    {
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    cells[x, y, z].UpdatePressure(newPressures[x, y, z]);
                    cells[x, y, z].UpdateHeat(newHeats[x, y, z]);
                }
            }
        }
    }

    Cell[] FindNeighbourhood(Cell c)
    {
        Cell[] neighbourhood = new Cell[6];
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    if (c == cells[x, y, z])
                    {
                        if (x != 0)
                        {
                            neighbourhood[0] = cells[x - 1, y, z];
                            //Debug.Log("0" + neighbourhood[0]);
                        }
                        if (y != 0)
                        {
                            neighbourhood[1] = cells[x, y - 1, z];
                            //Debug.Log("1" + neighbourhood[1]);
                        }
                        if (z != 0)
                        {
                            neighbourhood[2] = cells[x, y, z - 1];
                            //Debug.Log("2" + neighbourhood[2]);
                        }
                        if (x < xLength - 1)
                        {
                            neighbourhood[3] = cells[x + 1, y, z];
                            //Debug.Log("3" + neighbourhood[3]);
                        }
                        if (y < yLength - 1)
                        {
                            neighbourhood[4] = cells[x, y + 1, z];
                            //Debug.Log("4" + neighbourhood[4]);
                        }
                        if (z < zLength - 1)
                        {
                            neighbourhood[5] = cells[x, y, z + 1];
                            //Debug.Log("5" + neighbourhood[5]);
                        }
                        return neighbourhood;
                    }
                }
            }
        }
        return neighbourhood;
    }
}
