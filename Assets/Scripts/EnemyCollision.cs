using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D headCollider;
    [SerializeField] GameObject player;

    EnemyMovement enemyMovement;

    BoxCollider2D feetCollider;

    bool isTouching;

    void Start()
    {
        feetCollider = player.GetComponent<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        isTouching = headCollider.IsTouching(feetCollider);

        if (isTouching)
        {
            enemyMovement.enabled = false;
            Debug.Log("killed by player");
        }
    }
}
