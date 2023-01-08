using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCallout : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, moveSpeed);
    }
}
