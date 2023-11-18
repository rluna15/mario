using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTime;
    [SerializeField] float defaultGravity;
    [SerializeField] float gravityMult;

    private bool canMove = true;
    private float jumpHoldTime;
    private bool isJumping;
    private bool isGrounded;

    private InputManager inputManager;
    private Rigidbody2D rb;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            HandleMovement();
            HandleJump();
        }
    }

    private void HandleMovement()
    {
        float moveInput = inputManager.GetMoveInput();

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        float jumpInput = inputManager.GetJumpInput();

        if (jumpInput > 0 && !isGrounded)
        {
            isJumping = true;
            jumpHoldTime = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);
        }

        if (jumpInput > 0 && !isJumping)
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

        if (jumpInput == 0)
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
