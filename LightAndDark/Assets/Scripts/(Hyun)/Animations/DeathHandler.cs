using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.gravityScale = 0f;
        rb.isKinematic = true;

        animator.SetTrigger("Trigger_Die_Dark");

        Invoke(nameof(DestroySelf), 2f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
