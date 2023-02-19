using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;

    EnemyMovement enemyMovement;
    PlayerController playerController;

    BoxCollider2D feetCollider;
    Rigidbody2D myRigidBody2D;
    Rigidbody2D playerRigidBody2D;

    bool isTouching;

    void Start()
    {
        feetCollider = player.GetComponent<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        playerRigidBody2D = player.GetComponent<Rigidbody2D>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        isTouching = headCollider.IsTouching(feetCollider);

        if (isTouching)
        {
            playerController.killedEnemy();
            enemyMovement.enabled = false;
            myRigidBody2D.bodyType = RigidbodyType2D.Static;
            animator.SetBool("isDead", true);
            playerRigidBody2D.velocity = new Vector2(0, 14f);
            Destroy(gameObject, 0.2f);
        }
    }
}
