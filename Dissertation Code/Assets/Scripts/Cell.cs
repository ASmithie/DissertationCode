using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{

    public float airPressure;
    public float heat;

    Vector3[] corners;

    void OnDrawGizmos()
    {
        MakeCube();

        Gizmos.matrix = transform.localToWorldMatrix;

        foreach (Vector3 corner in corners)
        {
            Gizmos.DrawSphere(corner, 0.1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //RenderCube();
    }

    void MakeCube()
    {
        corners = new Vector3[8];
        corners[0] = new Vector3(0, 0, 0);
        corners[1] = new Vector3(1, 0, 0);
        corners[2] = new Vector3(1, 1, 0);
        corners[3] = new Vector3(0, 1, 0);
        corners[4] = new Vector3(0, 1, 1);
        corners[5] = new Vector3(1, 1, 1);
        corners[6] = new Vector3(1, 0, 1);
        corners[7] = new Vector3(0, 0, 1);
    }

    void RenderCube()
    {
        int[] triangles = {
            0, 2, 1, //face front
	        0, 3, 2,
            2, 3, 4, //face top
	        2, 4, 5,
            1, 2, 5, //face right
	        1, 5, 6,
            0, 7, 4, //face left
	        0, 4, 3,
            5, 4, 7, //face back
	        5, 7, 6,
            0, 6, 7, //face bottom
	        0, 1, 6
        };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = corners;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

}
