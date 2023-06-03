using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
        }
    }
}