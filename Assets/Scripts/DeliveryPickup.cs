using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickup : MonoBehaviour
{

    public GameObject[] DropOffPoints;
    public AudioSource audioSource;
    public AudioClip clip;

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if(pd != null)
            {
                pd.hasDelivery = true;
                pd.addTime();
                DropOffPoints[Random.Range(0,DropOffPoints.Length)].SetActive(true);
                audioSource.PlayOneShot(clip);
                gameObject.SetActive(false);
            }
        }
    }
}
