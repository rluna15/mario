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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Move();
        Jump();
    }

    void Move() 
    {
        rb.velocity = new Vector2( moveInput * moveSpeed, rb.velocity.y);

        /* TODO: Enable after the assets are imported */
        // isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        // if (isMoving)
        // {
        //     transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        // }
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
}
