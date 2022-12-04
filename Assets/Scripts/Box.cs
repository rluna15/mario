using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] Object coin;
    [SerializeField] Object growShroom;
    [SerializeField] Object fireFlower;

    [Header("Select")]
    [SerializeField] bool isCoin;
    [SerializeField] bool isGrowShroom;
    [SerializeField] bool isFireFlower;

    public void ShowItem()
    {
        if(isCoin)
        {
            Debug.Log("Show Coin.");
        }
        
        if(isGrowShroom)
        {
            Debug.Log("Show GrowShroom.");
        }

        if(isFireFlower)
        {
            Debug.Log("Show FireFlower.");
        }
    }
}
