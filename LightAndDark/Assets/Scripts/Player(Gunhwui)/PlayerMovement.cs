using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private PlayerState state;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        state = GetComponent<PlayerState>();
    }


    void FixedUpdate()
    {
        if (state.IsDead)
        {
            return;
        }

        rb.velocity = new Vector2(input.MoveInput * moveSpeed, rb.velocity.y);

        if (input.JumpRequested && state.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state.IsGrounded = false;
            input.ConsumeJumpRequest();
        }

        if (rb.velocity.y < -0.1f && state.IsGrounded)
        {
            state.IsGrounded = false;
        }
    }
}
