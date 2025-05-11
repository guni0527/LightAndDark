using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkController : MonoBehaviour
{
    public float moveSpeed = 5f;//속도 기본값
    public float jumpForce = 7f;//점프력 기본값

    public Sprite idleSprite;   //스프라이트 불러오는거
    public Sprite moveSprite;    //동일
    public Sprite jumpSprite;    //동일

    private Rigidbody2D rb;//리기드바디
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // 자식에 있을 경우
    }

    void Update()
    {
        float move = 0f;
        //키 입력       키 바꿀때 여기 수정 
        if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;//x값 줄여줌으로써 왼쪽으로 감
        if (Input.GetKey(KeyCode.RightArrow)) move = 1f;//x값 늘려줌으로써 왼쪽으로 감

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // 방향 전환
        if (move != 0)
            spriteRenderer.flipX = move < 0;

        // 점프
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // 스프라이트 상태 변경 tlqkf
        if (!isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else if (Mathf.Abs(move) > 0.1f)
        {
            spriteRenderer.sprite = moveSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

