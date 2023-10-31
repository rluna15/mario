using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private bool isMoving;
    private Transform parentObject;
    private Rigidbody2D parentRb;

    private void Awake()
    {
        parentObject = transform.parent;
        parentRb = parentObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        isMoving = Mathf.Abs(parentRb.velocity.x) > Mathf.Epsilon;

        if (isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(parentRb.velocity.x), 1f);
        }
    }
}
