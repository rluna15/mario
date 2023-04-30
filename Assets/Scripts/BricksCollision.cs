using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BricksCollision : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] Tilemap tilemap;

    [SerializeField] AudioManager audioManager;

    Vector3 playerPos;
    Vector3 tilePos;
    Vector3 posOffset = new Vector3(0, 0.5f, 0);

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
        if (other.gameObject.tag == "Bricks")
        {
            playerPos = transform.position;
            tilePos = playerPos + posOffset;
            
            Vector3Int position = grid.WorldToCell(tilePos);
            tilemap.SetTile(position, null);

            audioManager.PlayBrickBreak();
        }
    }
}
