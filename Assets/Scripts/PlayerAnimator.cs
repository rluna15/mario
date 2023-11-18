using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.IsJumping())
        {
            animator.SetBool("isJumping", true);
        }
        else 
        {
            animator.SetBool("isJumping", false);
        }
    }
}
