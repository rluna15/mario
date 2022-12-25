using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] float warpDelay;
    [SerializeField] Transform warpTarget;

    [Header("Objects")]
    [SerializeField] GameObject player;
    [SerializeField] Transform warpOut;

    [Header("Follow Camera")]
    [SerializeField] GameObject followCam;
    [SerializeField] PolygonCollider2D origianlCameraBounds;
    [SerializeField] PolygonCollider2D newCameraBounds;

    PlayerController playerController;
    CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D myRigidbody2D;
    BoxCollider2D boxCollider2D;

    bool inWarp = false;
    bool canWarp = false;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        capsuleCollider2D = player.GetComponent<CapsuleCollider2D>();
        myRigidbody2D = player.GetComponent<Rigidbody2D>();
        boxCollider2D = player.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        CheckWarp();
    }

    void CheckWarp()
    {
        if (Input.GetKeyDown(KeyCode.S) && inWarp)
        {
            Debug.Log("Start warp");
            canWarp = true;
        }

        if (canWarp)
        {
            RunWarp();
        }
    }

    void RunWarp()
    {
        playerController.DisableMovement();
        myRigidbody2D.bodyType = RigidbodyType2D.Static;
        capsuleCollider2D.enabled = false;
        boxCollider2D.enabled = false;

        var speed = warpDelay * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, warpTarget.transform.position, speed);

        if (player.transform.position == warpTarget.transform.position)
        {
            Debug.Log("Reached target");

            player.transform.position = warpOut.transform.position;
            canWarp = false;
            myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            capsuleCollider2D.enabled = true;
            boxCollider2D.enabled = true;
            playerController.EnableMovement();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inWarp = true;
            Debug.Log("in warp");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inWarp = false;
            Debug.Log("out of warp");
        }
    }
}
