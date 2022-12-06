using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickupMLM : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;

    [SerializeField]
    private LocationHolder lh;

    bool interactedWith = false;

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetAxis("Fire1") > 0 && interactedWith == false)
        {
            interactedWith = true;
            int fakeChance = Random.Range(0, 10);
            PlayerDelivery pd = col.gameObject.GetComponent<PlayerDelivery>();
            if (pd != null)
            {
                if (pd.fakeDelivery)
                {
                    pd.fakeDelivery = false;
                }
                else if (!pd.hasDelivery)
                {
                    if (fakeChance <= 4)
                    {
                        pd.fakeDelivery = true;
                    }
                    else
                    {
                        pd.hasDelivery = true;
                    }
                    pd.addTime(20);
                    pd.shiftStarted = true;
                    GameObject point = lh.DropoffPoints[Random.Range(0, lh.DropoffPoints.Length)];
                    point.SetActive(true);
                    lh.ActivePoint = point;
                    audioSource.PlayOneShot(clip);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Invoke("Deactivate", 10f);
        interactedWith = false;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
