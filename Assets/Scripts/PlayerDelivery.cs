using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDelivery : MonoBehaviour
{
    public bool hasDelivery = false;

    public bool shiftStarted = false;

    public int Score;

    public float deliveryTimer { get; private set; }

    public float starterTimerValue;

    public GameObject deliverySprite;

    [SerializeField]
    private LocationHolder lh;

    [SerializeField]
    ParticleSystem stars;

    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
        }
    }

    private int _lives = 5;

    private void Start()
    {
        deliveryTimer = starterTimerValue;
    }

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
        if (shiftStarted)
        {
            deliveryTimer -= Time.deltaTime;
        }
        if (deliveryTimer < 0)
        {
            shiftStarted = false;
            lh.ActivePoint.SetActive(false);
            GameObject point = lh.PickupPoints[Random.Range(0, lh.PickupPoints.Length)];
            point.SetActive(true);
            Lives--;
            deliveryTimer = starterTimerValue;
            hasDelivery = false;
            lh.ActivePoint = point;
        }
        if(Lives == 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void addTime(int t)
    {
        deliveryTimer += t;
    }

    public void emitStars()
    {
        stars.Play();
    }
}
