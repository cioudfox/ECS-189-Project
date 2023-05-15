using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerController pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; //Must be greater than the length and width of the tilemap
    float opDist;



    void Start()
    {
        pm = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }

        if (pm.GetMoveDir().x > 0 && pm.GetMoveDir().y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;  //Right
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().x < 0 && pm.GetMoveDir().y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;    //Left
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().y > 0 && pm.GetMoveDir().x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position; //Up
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().y < 0 && pm.GetMoveDir().x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;    //Down
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().x > 0 && pm.GetMoveDir().y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Up").position;   //Right up
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().x > 0 && pm.GetMoveDir().y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;  //Right down
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().x < 0 && pm.GetMoveDir().y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;  //Left up
                SpawnChunk();
            }
        }
        else if (pm.GetMoveDir().x < 0 && pm.GetMoveDir().y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position; //Left down
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }
}
