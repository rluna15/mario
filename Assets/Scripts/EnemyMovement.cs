using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Animator animator;

    bool canMove = true;

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")) == true && canMove)
        {
            animator.enabled = true;
            Move();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            moveSpeed = -moveSpeed;
            FlipSprite();
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<FireBall>()) 
        {
            FindObjectOfType<PlayerController>().killedEnemy("FireBall");
            // rb.isKinematic = true;
            rb.bodyType = RigidbodyType2D.Static;
            canMove = false;
            animator.enabled = false;
        }
    }

    void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}
