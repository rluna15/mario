using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
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
    bool canMove = true;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    Animator animator;
    SpriteRenderer sp;
    AudioManager audioManager;

    [Header("SFX")]
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip growSFX;

    [Header("Sprites")]
    [SerializeField] Sprite small;
    [SerializeField] Sprite big;

    [Header("Enemy Conditions")]
    [SerializeField] bool enemyKilled = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            Move();
            Jump();
            Animate();
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpHoldTime = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, 1f * jumpForce);

            // PlaySound(jumpSFX);
            audioManager.PlayJump();
            
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

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public bool GetCanMove()
    {
        return canMove;
    }

    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "box" || other.gameObject.tag == "Bricks")
        {
            isJumping = false;
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (!enemyKilled)
            {
                PlaySound(deathSFX);
                animator.SetBool("onDeath", true);
            }
            else
            {
                enemyKilled = false;
            }
        }

        if (other.gameObject.tag == "GrowShroom")
        {
            // PlaySound(growSFX);
            audioManager.PlayGrowShroom();
            sp.sprite = big;
            Destroy(other.gameObject);
        }
    }

    public void killedEnemy()
    {
        enemyKilled = true;
    }
}
