using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "box")
        {
            Box box = other.gameObject.GetComponent<Box>();

            if (box.GetCoin() && !box.GetHit())
            {
                audioManager.PlayCoin();
            }

            box.ShowItem();
        }
    }
}
