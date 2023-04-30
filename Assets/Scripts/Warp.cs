using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Warp : MonoBehaviour
{
    [SerializeField] float warpDelay;
    [SerializeField] float lensSize;
    [Tooltip("Warp to a different map with different camera bounds")]
    [SerializeField] bool differentLoc;

    [Header("Objects")]
    [SerializeField] GameObject player;
    [SerializeField] Transform warpInTarget;
    [SerializeField] Transform warpOut;
    [SerializeField] Transform warpOutTarget;

    [Header("Follow Camera")]
    [SerializeField] GameObject followCam;
    [SerializeField] PolygonCollider2D origianlCameraBounds;
    [SerializeField] PolygonCollider2D newCameraBounds;

    PlayerController playerController;
    CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D myRigidbody2D;
    BoxCollider2D boxCollider2D;
    AudioManager audioManager;

    CinemachineConfiner cinemachineConfiner;
    CinemachineVirtualCamera cinemachineVirtualCamera;

    bool inWarp = false;
    bool canWarp = false;
    bool endWarp = false;
    bool playingSFX = false;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        capsuleCollider2D = player.GetComponent<CapsuleCollider2D>();
        myRigidbody2D = player.GetComponent<Rigidbody2D>();
        boxCollider2D = player.GetComponent<BoxCollider2D>();

        cinemachineConfiner = followCam.GetComponent<CinemachineConfiner>();
        cinemachineVirtualCamera = followCam.GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        CheckWarp();
    }

    void CheckWarp()
    {
        if (Input.GetKeyDown(KeyCode.S) && inWarp)
        {
            audioManager.PlayWarp();
            canWarp = true;
        }

        if (canWarp)
        {
            RunWarp();
        }

        if (endWarp)
        {
            EndWarp();
        }
    }

    void RunWarp()
    {
        playerController.DisableMovement();
        myRigidbody2D.bodyType = RigidbodyType2D.Static;
        capsuleCollider2D.enabled = false;
        boxCollider2D.enabled = false;

        var speed = warpDelay * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, warpInTarget.transform.position, speed);

        if (player.transform.position == warpInTarget.transform.position)
        {
            Debug.Log("Reached target");

            player.transform.position = warpOut.transform.position;
            canWarp = false;
            endWarp = true;

            if (differentLoc)
            {
                cinemachineConfiner.m_BoundingShape2D = newCameraBounds;
                cinemachineVirtualCamera.m_Lens.OrthographicSize = lensSize;
            }

        }

    }

    void EndWarp()
    {
        if (!playingSFX)
        {
            audioManager.PlayWarp();
            playingSFX = true;
        }

        var speed = warpDelay * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, warpOutTarget.transform.position, speed);

        if (player.transform.position == warpOutTarget.transform.position)
        {
            myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            capsuleCollider2D.enabled = true;
            boxCollider2D.enabled = true;
            playerController.EnableMovement();

            endWarp = false;
            playingSFX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inWarp = true;
            audioManager = other.gameObject.GetComponent<AudioManager>();
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
