using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 5f;

    Vector2 movementVector;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.y * movementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpHeight);
            rb.velocity *= jumpHeight;

            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }          
    }
}
