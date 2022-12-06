using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDropoff : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;

    [SerializeField]
    private LocationHolder lh;

    void Update()
    {
        if(lh.ActivePoint != gameObject)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if(pd != null)
            {
                if (pd.fakeDelivery)
                {
                    pd.fakeDelivery = false;
                    pd.ReduceLives();
                }
                else
                {
                    pd.hasDelivery = false;
                    pd.addTime(30);
                    pd.Score += (1000 + (10 * (int)pd.deliveryTimer));
                    GameObject point = lh.PickupPoints[Random.Range(0, lh.PickupPoints.Length)];
                    point.SetActive(true);
                    lh.ActivePoint = point;
                    audioSource.PlayOneShot(clip);
                    pd.emitStars();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
