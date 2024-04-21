using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpPower = 5f;
    
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float deltaX;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(deltaX * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        deltaX = ctx.ReadValue<Vector2>().x;
        Vector3 localScale = transform.localScale;
        if ((deltaX < 0f && localScale.x > 0f) || (deltaX > 0f && localScale.x < 0f))
        {
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
