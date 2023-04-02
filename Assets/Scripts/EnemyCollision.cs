using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemyMovement.enabled = false;
        other.gameObject.GetComponent<PlayerController>().killedEnemy();
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 14f);
        animator.SetBool("isDead", true);
        Destroy(enemy, 0.2f);
    }
}
