using UnityEngine;

public class WhiteController : MonoBehaviour
{
    public float moveSpeed = 5f;//속도 기본값
    public float jumpForce = 7f;//점프력 기본값

    public Sprite idleSprite; //스프라이트 불러오는거
    public Sprite moveSprite; //동일
    public Sprite jumpSprite; //동일
    public Sprite dieSprite;  //동일

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead)
            return;

        Debug.Log("Update 실행 중");

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K키 눌림!");
            LightDie();
        }
        float move = 0f;
        //키 입력       키 바꿀때 여기 수정   
        if (Input.GetKey(KeyCode.A)) move = -1f; //x값 줄여줌으로써 왼쪽으로 감
        if (Input.GetKey(KeyCode.D)) move = 1f; //x값 늘려줌으로써 오른쪽으로 감

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        //방향 전환 할때 그림이 움직이도록 해줌
        if (move != 0)
            spriteRenderer.flipX = move < 0;

        //점프를 담당해줌
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        //땅에 닿았거나 아닐때 모션이랑 걸어다닐때 나오는 모션 해주는거 //여기가 진심 wrkxdma
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

    public void LightDie()//죽었을때 LightZoneTrigger.cs에 호출받음
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        spriteRenderer.sprite = dieSprite;
        Debug.Log("WhiteController: 사망처리됨");
    }
}
