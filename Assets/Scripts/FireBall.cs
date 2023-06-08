using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] float collisionCount = 3f;

    Animator animator;
    Rigidbody2D rb2D;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckCollisionCount();
    }

    void CheckCollisionCount()
    {
        if (collisionCount == 0)
        {
            rb2D.isKinematic = true;
            rb2D.velocity = new Vector2(0f, 0f);
            animator.SetBool("Explode", true);
            Destroy(gameObject, 0.3f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            collisionCount = 0f;
        }
        else
        {
            collisionCount -= 1;
        }
    }
}
