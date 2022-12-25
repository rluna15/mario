using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] float warpDelay;

    [Header("Objects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject warpOut;

    PlayerController playerController;

    bool inWarp = false;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
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
            player.transform.position = warpOut.transform.position;
            
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

    IEnumerator StartWarp() 
    {
        
    }
}
