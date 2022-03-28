using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    Cell cellInside;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (cellInside)
            {
                cellInside.UpdatePressure(100000f);
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cell"))
        {
            cellInside = other.gameObject.GetComponent<Cell>();
        }
    }
}
