using UnityEngine;

public class WhiteController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;//속도 기본값
    [SerializeField] private float jumpForce = 7f;//점프력 기본값

    [SerializeField] private Sprite idleSprite; //스프라이트 불러오는거
    [SerializeField] private Sprite moveSprite; //동일
    [SerializeField] private Sprite jumpSprite; //동일
    [SerializeField] private Sprite dieSprite;  //동일

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isDead = false;
    private float move = 0f;
    private bool jumpRequested = false;

    public bool isInLightZone = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        move = 0f;
        //키 입력       키 바꿀때 여기 수정   
        if (Input.GetKey(KeyCode.A)) move = -1f; //x값 줄여줌으로써 왼쪽으로 감
        if (Input.GetKey(KeyCode.D)) move = 1f; //x값 늘려줌으로써 오른쪽으로 감

        //점프를 담당해줌
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jumpRequested = true;
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

        //방향 전환 할때 그림이 움직이도록 해줌
        if (move != 0)
            spriteRenderer.flipX = move < 0;
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (jumpRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            jumpRequested = false;
        }

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

    public void LightDie()//죽었을때 LightZoneTrigger.cs에 호출받음
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        spriteRenderer.sprite = dieSprite;
        Debug.Log("WhiteController: 사망처리됨");
    }
}
