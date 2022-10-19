using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float topSpeed = 5.0f;
    public float rotSpeed = 90.0f;

    float movePlayer;
    float rotPlayer;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        readInputs();

        rb.velocity = transform.up * topSpeed * movePlayer;
        transform.Rotate(0f, 0f, -1 * rotSpeed * rotPlayer * Time.deltaTime);
    }

    void readInputs()
    {
        movePlayer = Input.GetAxis("Vertical");
        rotPlayer = Input.GetAxis("Horizontal");
    }
}
