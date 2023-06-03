using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    [SerializeField] bool growShroom;
    [SerializeField] bool fireFlower;
    [SerializeField] bool powerStar;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    void FlipSprite()
    {
        transform.localScale = new Vector2(-(Math.Sign(rb.velocity.x)), 1f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag != "Player" || other.tag != "Enemy")
        {
            moveSpeed = -moveSpeed;
            FlipSprite();
        }    
    }
}
