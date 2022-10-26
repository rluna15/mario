using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTime;
    [SerializeField] float defaultGravity;
    [SerializeField] float gravityMult;

    float jumpHoldTime;
    float moveInput;

    bool isGrounded;
    bool isJumping;
    bool isMoving;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Move();
        Jump();
        Animate();
    }

    void Move() 
    {
        rb.velocity = new Vector2( moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpHoldTime = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpHoldTime > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);
                jumpHoldTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            rb.gravityScale = gravityMult;
        }
        else 
        {
            rb.gravityScale = defaultGravity;
        }
    }

    void Animate()
    {
        // flip sprite & move
        isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (isMoving && isGrounded)
        {
            animator.SetBool("onMove", true);
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
        else
        {
            animator.SetBool("onMove", false);
        }

        // flip sprite and jump
        if (!isGrounded && isMoving)
        {
            animator.SetBool("onJump", true);
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
        else 
        {
            animator.SetBool("onJump", false);
        }

        // handle jump
        if (isGrounded)
        {
            animator.SetBool("onJump", false);
        }
        else 
        {
            animator.SetBool("onJump", true);
        }
    }
}
