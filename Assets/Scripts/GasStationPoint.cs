using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationPoint : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
            if(pm != null)
            {
                pm.RefillGas();
            }
        }
    }
}
