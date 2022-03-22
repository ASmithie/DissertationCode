using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAGrid : MonoBehaviour
{

    public int xLength;
    public int yLength;
    public int zLength;


    public Cell[] cells;

    public Cell cell;

    public CellBehaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {

        cells = new Cell[xLength * yLength * zLength];

        for(float x =0f; x < xLength; x++)
        {
            for(float y =0f; y < yLength; y++)
            {
                for(float z=0f; z < zLength; z++)
                {
                    Instantiate(cell, new Vector3(x, y, z), Quaternion.identity, transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Cell c in cells)
        {
            float newPressure = behaviour.CalculatePressure(c, cells, this);
            Debug.Log(newPressure);
        }
    }
}
