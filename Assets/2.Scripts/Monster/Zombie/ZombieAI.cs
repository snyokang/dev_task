using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D col;
    private float jumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();

        jumped = 0f;
    }

    void FixedUpdate()
    {
        jumped = Mathf.Max(jumped - Time.fixedDeltaTime, 0f);
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.left;
        Vector2 offset = Vector2.left * (col.bounds.extents.x + 0.2f)
            + Vector2.up * (col.bounds.extents.y + 0.1f);

        RaycastHit2D hit = Physics2D.Raycast(origin + offset, direction, 0.2f);
        
        if (hit.collider)
        {
            if (hit.collider.tag == "Monster")
            {
                if (jumped < 0.001f)
                {
                    animator.Play("Jump");
                    rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * speed / 3 * 2);
                    jumped = 1.5f;
                }
                animator.SetBool("IsAttacking", false);
            } else if (hit.collider.tag == "Hero")
            {
                animator.SetBool("IsAttacking", true);
            }
        } else
        {
            animator.SetBool("IsAttacking", false);
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
        }

        Debug.DrawRay(origin + offset, direction * 0.2f, Color.red);
    }
    
    public void OnAttack()
    {
        // Deals damage
    }
}
