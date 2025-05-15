using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool IsGrounded { get; set; } = false;
    public bool IsDead { get; set; } = false;
    public bool IsInLightZone { get; set; } = false;

    public void Die()
    {
        if (IsDead)
        {
            return;
        }

        IsDead = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log($"{gameObject.name} 사망 처리");

        GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
    }

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) 
        {
            IsGrounded = false;
        }
    }
}
