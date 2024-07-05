using System.Collections.Generic;
using UnityEngine;

public class TileManagmentScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilesPrefabs;
    private float xSpawn;
    private float tileLength;
    private Transform playerTransform;
    private float numberofTiles;
    private List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
        xSpawn = 0;
        tileLength = 153.5f;
        playerTransform = GameObject.FindWithTag("Player").transform;
        numberofTiles = 3;
        for (int i = 0; i < numberofTiles; i++)
        {
            TileSpawn(Random.Range(0, tilesPrefabs.Length));
        }
    }
    void Update()
    {
        if (playerTransform.position.x - 100 > xSpawn - (numberofTiles * tileLength))
        {
            TileSpawn(Random.Range(0, tilesPrefabs.Length));
            DeleteTile();
        }
    }
    private void TileSpawn(int tileIndex)
    {
        GameObject go = Instantiate(tilesPrefabs[tileIndex], transform.right * xSpawn, transform.rotation);
        activeTiles.Add(go);
        xSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}