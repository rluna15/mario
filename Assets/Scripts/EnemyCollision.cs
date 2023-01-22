using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] GameObject player;

    EnemyMovement enemyMovement;

    BoxCollider2D feetCollider;
    Rigidbody2D myRigidBody2D;

    bool isTouching;
    bool isDead = false;

    void Start()
    {
        feetCollider = player.GetComponent<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouching = headCollider.IsTouching(feetCollider);

        if (isTouching)
        {
            enemyMovement.enabled = false;
            myRigidBody2D.bodyType = RigidbodyType2D.Static;
            isDead = true;
        }
    }

    public bool GetStatus() {
        return isDead;
    }
}
