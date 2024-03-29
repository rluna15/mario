using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject player;
    [SerializeField] float launchVelocity = 700f;
    float shootDirection;
    float velocityDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shootDirection = Mathf.Sign(player.transform.localScale.x);
            velocityDirection = Mathf.Sign(launchVelocity);

            if (shootDirection < 0 && velocityDirection > 0)
            {
                launchVelocity = -launchVelocity;
            }
            else if (shootDirection > 0 && velocityDirection < 0)
            {
                launchVelocity = Mathf.Abs(launchVelocity);
            }

            audioManager.PlayFireball();
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
        }
    }
}