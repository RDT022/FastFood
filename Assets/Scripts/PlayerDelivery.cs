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

    public GameObject[] DropOffPoints;

    public GameObject[] PickupPoints;

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
        if (shiftStarted)
        {
            deliveryTimer -= Time.deltaTime;
        }
        if (deliveryTimer < 0)
        {
            shiftStarted = false;
            foreach (GameObject p in DropOffPoints)
            {
                if (p.activeSelf == true)
                {
                    p.SetActive(false);
                }
            }
            PickupPoints[Random.Range(0, PickupPoints.Length)].SetActive(true);
            Lives--;
            deliveryTimer = starterTimerValue;
            hasDelivery = false;
        }
        else
        {
            deliverySprite.SetActive(false);
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
}
