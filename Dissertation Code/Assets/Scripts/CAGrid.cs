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

    // Start is called before the first frame update
    void Start()
    {

        cells = new Cell[xLength,yLength,zLength];

        for (int x =0; x < xLength; x++)
        {
            for(int y =0; y < yLength; y++)
            {
                for(int z=0; z < zLength; z++)
                {
                    Cell newCell = Instantiate(cell, new Vector3(x, y, z), Quaternion.identity, transform);
                    //cells.Add(newCell);
                    cells[x, y, z] = newCell;
                    
                }
            }
        }

        Cell[] neighbourhood = new Cell[6];
        neighbourhood = FindNeighbourhood(cells[3,3,3]);
        foreach(Cell c in neighbourhood) { Debug.DrawRay(c.transform.position, Vector3.up, Color.red, 10); }

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Cell c in cells)
        {
            Cell[] neighbourhood = new Cell[6];
            neighbourhood = FindNeighbourhood(c);
            float newPressure = behaviour.CalculatePressure(c, neighbourhood, this);
            c.UpdatePressure(newPressure);
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
                        if(x != 0)
                        {
                            neighbourhood[0] = cells[x - 1, y, z];
                            //Debug.Log("0" + neighbourhood[0]);
                        }
                        if(y != 0)
                        {
                            neighbourhood[1] = cells[x, y - 1, z];
                            //Debug.Log("1" + neighbourhood[1]);
                        }
                        if(z != 0)
                        {
                            neighbourhood[2] = cells[x, y, z - 1];
                            //Debug.Log("2" + neighbourhood[2]);
                        }
                        if(x < xLength-1)
                        {
                            neighbourhood[3] = cells[x + 1, y, z];
                            //Debug.Log("3" + neighbourhood[3]);
                        }
                        if(y < yLength-1)
                        {
                            neighbourhood[4] = cells[x, y + 1, z];
                            //Debug.Log("4" + neighbourhood[4]);
                        }
                        if(z < zLength-1)
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
