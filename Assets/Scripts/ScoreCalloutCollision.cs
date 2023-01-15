using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalloutCollision : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] CapsuleCollider2D body;
    [SerializeField] BoxCollider2D head;

    [Header("Callouts")]
    [SerializeField] GameObject callout100;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    void CreateCallout(GameObject callout)
    {
        
    }

    ///<summary>
    ///<param name="calloutNum">Enter the score value to display</param>
    ///</summary>
    public void ShowCallOut(int calloutNum)
    {

    }
}
