using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] Object coin;
    [SerializeField] Object growShroom;
    [SerializeField] Object fireFlower;
    [SerializeField] Sprite disabledSprite;

    [Header("Select")]
    [SerializeField] bool isCoin;
    [SerializeField] bool isMultiHit;
    [SerializeField] int hitCount;
    [SerializeField] bool isGrowShroom;
    [SerializeField] bool isFireFlower;

    [Header("Score Callouts")]
    [SerializeField] float calloutDeath;
    [SerializeField] GameObject callout100;

    bool isHit = false;

    Object obj;

    SpriteRenderer sp;

    Vector3 position;
    Vector3 offSet = new Vector3(0, 1f, 0);

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        position = transform.position + offSet;
    } 

    public void ShowItem()
    {
        if(isCoin && !isHit)
        {
            isHit = true;
            sp.sprite = disabledSprite;
            obj = Instantiate(coin, position, Quaternion.identity);
            Destroy(obj, 0.3f);

            CreateCallout();
        }

        if (isMultiHit && !isHit)
        {
            hitCount--;
            obj = Instantiate(coin, position, Quaternion.identity);
            Destroy(obj, 0.3f);

            if (hitCount < 1)
            {
                isHit = true;
                sp.sprite = disabledSprite;

                CreateCallout();
            }
        }
        
        if(isGrowShroom && !isHit)
        {
            isHit = true;
            obj = Instantiate(growShroom, position, Quaternion.identity);
            sp.sprite = disabledSprite;
            Debug.Log("Show GrowShroom.");
        }

        if(isFireFlower && !isHit)
        {
            isHit = true;
            obj = Instantiate(fireFlower, position, Quaternion.identity);
            sp.sprite = disabledSprite;
            Debug.Log("Show FireFlower.");
        }
    }

    void CreateCallout()
    {
        obj = Instantiate(callout100, position, Quaternion.identity);
        Destroy(obj, calloutDeath);
    }
}
