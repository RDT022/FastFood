using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDelivery : MonoBehaviour
{
    public bool hasDelivery = false;

    public bool fakeDelivery = false;

    public bool shiftStarted = false;

    public int Score;

    public float deliveryTimer { get; private set; }

    public float starterTimerValue;
    [SerializeField]
    GameObject deliverySprite;
    [SerializeField]
    GameObject fakeDeliverySprite;

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
        if (hasDelivery)
        {
            deliverySprite.SetActive(true);
        }
        else
        {
            deliverySprite.SetActive(false);
        }
        if (fakeDelivery)
        {
            fakeDeliverySprite.SetActive(true);
        }
        else
        {
            fakeDeliverySprite.SetActive(false);
        }
        if (shiftStarted)
        {
            deliveryTimer -= Time.deltaTime;
        }
        if (deliveryTimer < 0)
        {
            ReduceLives();
        }
        if (Lives == 0)
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

    public void ReduceLives()
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
}
