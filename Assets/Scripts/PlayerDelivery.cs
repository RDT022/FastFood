using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDelivery : MonoBehaviour
{
    public bool hasDelivery = false;

    public GameObject deliverySprite;

    // Update is called once per frame
    void Update()
    {
        if(hasDelivery)
        {
            deliverySprite.SetActive(true);
        }
        else
        {
            deliverySprite.SetActive(false);
        }
    }
}
