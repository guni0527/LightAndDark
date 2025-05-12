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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //메인 오브젝트안에 자식오브젝트까지 검사
    }

    void Update()
    {
        if (isDead)
            return;

        float move = 0f;
        //키 입력       키 바꿀때 여기 수정 
        if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;//x값 줄여줌으로써 왼쪽으로 감
        if (Input.GetKey(KeyCode.RightArrow)) move = 1f;//x값 늘려줌으로써 왼쪽으로 감

       




        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        //Move 스프라이트가 다른방향을 볼수있게 해줌
        if (move != 0)
            spriteRenderer.flipX = move < 0;


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
    public void DarkDie()//죽었을때 LightZoneTrigger.cs에 호출받음
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        spriteRenderer.sprite = dieSprite;
        Debug.Log("DarkController: 사망처리됨");
    }
    

}

