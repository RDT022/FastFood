using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.terrainMoveSpeed = 0.5f;
            pm.terrainRotSpeed = 2f;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.splashParticle();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.terrainMoveSpeed = 1f;
            pm.terrainRotSpeed = 1f;
        }
    }
}
