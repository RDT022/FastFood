using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDropoff : MonoBehaviour
{

    public GameObject[] PickupPoints;

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if(pd != null)
            {
                pd.hasDelivery = false;
                PickupPoints[Random.Range(0,PickupPoints.Length)].SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
