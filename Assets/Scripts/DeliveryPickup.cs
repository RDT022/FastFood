using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickup : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;

    [SerializeField]
    private LocationHolder lh;


    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if(pd != null)
            {
                pd.hasDelivery = true;
                pd.shiftStarted = true;
                pd.addTime(20);
                GameObject point = lh.DropoffPoints[Random.Range(0,lh.DropoffPoints.Length)];
                point.SetActive(true);
                lh.ActivePoint = point;
                audioSource.PlayOneShot(clip);
                gameObject.SetActive(false);
            }
        }
    }
}
