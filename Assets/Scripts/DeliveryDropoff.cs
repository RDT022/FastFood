using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDropoff : MonoBehaviour
{

    public GameObject[] PickupPoints;
    public AudioSource audioSource;
    public AudioClip clip;

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if(pd != null)
            {
                pd.hasDelivery = false;
                pd.addTime(10);
                pd.Score += (1000 + (10 * (int)pd.deliveryTimer));
                PickupPoints[Random.Range(0,PickupPoints.Length)].SetActive(true);
                audioSource.PlayOneShot(clip);
                gameObject.SetActive(false);
            }
        }
    }
}
