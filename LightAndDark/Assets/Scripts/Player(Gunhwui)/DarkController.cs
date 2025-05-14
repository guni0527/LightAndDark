using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkController : MonoBehaviour
{
    public float moveSpeed = 5f;//속도 기본값
    public float jumpForce = 7f;//점프력 기본값

    public Sprite idleSprite;   //스프라이트를 불러줌
    public Sprite moveSprite;   //동일
    public Sprite jumpSprite;   //동일
    public Sprite dieSprite;    //동일
    

    private Rigidbody2D rb;     //�����ٵ�
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isDead = false;

    private float moveInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //메인 오브젝트안에 자식오브젝트까지 검사
    }

    void Update()
    {
        if (isDead)
            return;

        moveInput = 0f;
        //키 입력       키 바꿀때 여기 수정 
        if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;//x값 줄여줌으로써 왼쪽으로 감
        if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;//x값 늘려줌으로써 왼쪽으로 감

        //Move 스프라이트가 다른방향을 볼수있게 해줌
        if (moveInput != 0)
            spriteRenderer.flipX = moveInput < 0;


        //조작관련임
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        //맞춰서 스프라이트를 불러줌
        if (!isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else if (Mathf.Abs(moveInput) > 0.1f)
        {
            spriteRenderer.sprite = moveSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (rb.velocity.y < -0.1f && isGrounded)
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // 기존: contact.normal.y > 0.5f
            // 개선: Y축 위 방향 + X축 밀착일 경우 필터링
            if (contact.normal.y > 0.5f && Mathf.Abs(contact.normal.x) < 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
    public void DarkDie()//죽었을때 LightZoneTrigger.cs에 호출받음
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        spriteRenderer.sprite = dieSprite;
        Debug.Log("DarkController: 사망처리됨");
    }
    

}

