using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public float airPressure;
    public float heat;

    public Vector3[] corners;


    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        corners = new Vector3[8];
        MakeCube();

        Gizmos.matrix = transform.localToWorldMatrix;

        foreach (Vector3 corner in corners)
        {
            Gizmos.DrawSphere(corner, 0.1f);
        }
    }

    void MakeCube()
    {
        corners[0] = new Vector3(0, 0, 0);
        corners[1] = new Vector3(1, 0, 0);
        corners[2] = new Vector3(0, 0, 1);
        corners[3] = new Vector3(1, 0, 1);
        corners[4] = new Vector3(0, 1, 0);
        corners[5] = new Vector3(1, 1, 0);
        corners[6] = new Vector3(0, 1, 1);
        corners[7] = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
