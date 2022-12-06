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

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gasMeterMaskOGSize = gasMeterMask.rectTransform.rect.width;
    }

    void Update()
    {
        readInputs();
        if(movePlayer!= 0)
        {
            gasMeterValue -= 1.5f * Time.deltaTime;
        }
        else if(rotPlayer!= 0)
        {
            gasMeterValue -= Time.deltaTime;
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
    }
}
