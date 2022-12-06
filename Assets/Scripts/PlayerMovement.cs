using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float topSpeed = 5.0f;
    public float rotSpeed = 90.0f;

    public float terrainMoveSpeed = 1.0f;
    public float terrainRotSpeed = 1.0f;

    public Image gasMeterMask;
    float gasMeterMaskOGSize;
    float gasMeterValue = 100f;

    float movePlayer;
    float rotPlayer;

    public bool murphyMode;

    [SerializeField]
    ParticleSystem sparks;
    bool isSparking = false;
    [SerializeField]
    ParticleSystem smoke;
    [SerializeField]
    ParticleSystem splash;
    bool isSplashing = false;


    Rigidbody2D rb;

    void Start()
    {
        sparks.Stop();
        smoke.Play();
        rb = GetComponent<Rigidbody2D>();
        gasMeterMaskOGSize = gasMeterMask.rectTransform.rect.width;
    }

    void Update()
    {
        readInputs();
        if (gasMeterValue <= 0)
        {
            gasMeterValue = 0;
            topSpeed = 5f;
            smoke.Stop();
        }
        else
        {
            topSpeed = 10f;
            if (movePlayer != 0)
            {
                gasMeterValue -= 1.5f * Time.deltaTime;
            }
            else if (rotPlayer != 0)
            {
                gasMeterValue -= Time.deltaTime;
            }
        }
        rb.velocity = transform.up * topSpeed * movePlayer * terrainMoveSpeed;
        transform.Rotate(0f, 0f, -1 * rotSpeed * rotPlayer * Time.deltaTime * terrainRotSpeed);
        UpdateGasMeter();
    }

    void readInputs()
    {
        movePlayer = Input.GetAxis("Vertical");
        rotPlayer = Input.GetAxis("Horizontal");
    }

    void UpdateGasMeter()
    {
        gasMeterMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gasMeterMaskOGSize * (gasMeterValue / 100));
    }

    public void RefillGas()
    {
        gasMeterValue = 100f;
        smoke.Play();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(murphyMode)
        {
            gasMeterValue -= Time.deltaTime;
        }
        if (!isSparking)
        {
            sparks.Play();
            Invoke("sparkReset", 0.1f);
            isSparking = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        sparks.Stop();
    }

    void sparkReset()
    {
        isSparking = false;
    }

    public void splashParticle()
    {
        if(!isSplashing)
        {
            splash.Play();
            Invoke("splashReset", 0.1f);
            isSplashing = true;
        }
    }

    void splashReset()
    {
        isSplashing = false;
    }
}
