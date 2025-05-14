using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 이동 및 점프 물리 처리 담당
/// - PlayerInputHandler 입력 기반으로 Rigidbody2D 이동 제어
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private PlayerState state;

    /// <summary>
    /// 필수 컴포넌트 초기화
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        state = GetComponent<PlayerState>();
    }

    /// <summary>
    /// 물리 기반 이동 및 점프 처리
    /// - 사망 상태에서는 동작 중단
    /// </summary>
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
