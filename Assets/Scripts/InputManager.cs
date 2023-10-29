using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float moveInput;
    private float jumpInput;

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetAxisRaw("Jump");
    }

    public float GetMoveInput()
    {
        return moveInput;
    }

    public float GetJumpInput()
    {
        return jumpInput;
    }
}
