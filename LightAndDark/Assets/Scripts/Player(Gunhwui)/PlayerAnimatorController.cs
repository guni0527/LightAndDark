using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Sprite idleSprite, moveSprite, jumpSprite, dieSprite;

    private SpriteRenderer spriteRenderer;
    private PlayerInputHandler input;
    private PlayerState state;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        input = GetComponent<PlayerInputHandler>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (state.IsDead)
        {
            spriteRenderer.sprite = dieSprite;
            return;
        }

        if (!state.IsGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else if (Mathf.Abs(input.MoveInput) > 0.1f)
        {
            spriteRenderer.sprite = moveSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        if (input.MoveInput != 0)
        {
            spriteRenderer.flipX = input.MoveInput < 0;
        }
    }
}
