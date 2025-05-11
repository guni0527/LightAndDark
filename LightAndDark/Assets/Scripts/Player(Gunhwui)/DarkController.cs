using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkController : MonoBehaviour
{
    public float moveSpeed = 5f;//�ӵ� �⺻��
    public float jumpForce = 7f;//������ �⺻��

    public Sprite idleSprite;   //��������Ʈ �ҷ����°�
    public Sprite moveSprite;   //����
    public Sprite jumpSprite;   //����
    public Sprite dieSprite;    //����

    private Rigidbody2D rb;     //�����ٵ�
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //�ڽĿ� ���� ���
    }

    void Update()
    {
        float move = 0f;
        //Ű �Է�       Ű �ٲܶ� ���� ���� 
        if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;//x�� �ٿ������ν� �������� ��
        if (Input.GetKey(KeyCode.RightArrow)) move = 1f;//x�� �÷������ν� �������� ��

        if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = dieSprite;
            rb.velocity = Vector2.zero; //���������� �������� �ʰ�����
            return;
        }




        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        //���� ��ȯ �Ҷ� �׸��� �����̵��� ����
        if (move != 0)
            spriteRenderer.flipX = move < 0;


        //������ �������
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        //���� ��Ұų� �ƴҶ� ����̶� �ɾ�ٴҶ� ������ ��� ���ִ°�
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

