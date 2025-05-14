using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 상태 관리 클래스
/// - 사망 여부, 땅 착지 여부, 빛 영역 여부 관리
/// </summary>
public class PlayerState : MonoBehaviour
{
    public bool IsGrounded { get; set; } = false;
    public bool IsDead { get; set; } = false;
    public bool IsInLightZone { get; set; } = false;

    /// <summary>
    /// 플레이어 사망 처리
    /// - IsDead 플래그 설정
    /// - Rigidbody 정지 처리
    /// </summary>
    public void Die()
    {
        IsDead = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log($"{gameObject.name} 사망 처리");
    }

    /// <summary>
    /// 충돌 진입 시 착지 여부 판정
    /// - Y축 위 방향 + x축 밀착 시 IsGrounded true 설정
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f && Mathf.Abs(contact.normal.x) < 0.5f)
            {
                IsGrounded = true;
                break;
            }
        }
    }

    /// <summary>
    /// Ground 레이어에서 이탈 시 IsGrounded false 처리
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) 
        {
            IsGrounded = false;
        }
    }
}
