using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] GameObject player;

    [Header("Death Sprite")]
    [SerializeField] Sprite deathSprite;
    [SerializeField] GameObject enemyObject;

    EnemyMovement enemyMovement;

    BoxCollider2D feetCollider;
    Rigidbody2D rb;
    Rigidbody2D playerRB;
    SpriteRenderer sr;

    bool isTouching;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = player.GetComponent<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        playerRB = GetComponent<Rigidbody2D>();
        sr = enemyObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isTouching = headCollider.IsTouching(feetCollider);

        if (isTouching)
        {
            rb.bodyType = RigidbodyType2D.Static;
            enemyMovement.enabled = false;
            sr.sprite = deathSprite;
        }
    }
}
