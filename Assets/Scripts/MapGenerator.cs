using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;

    public Transform player;
    public int chunkSize;
    public int maxViewDistanceMultiplier;
    private int maxViewDistance;


    private void Start()
    {
        maxViewDistance = chunkSize * maxViewDistanceMultiplier;
    }
    private void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > chunkSize && Mathf.Abs(player.transform.position.y - transform.position.y) > chunkSize)
        {
            transform.position = new Vector2(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));
        }
    }
    public void InitialGenerate()
    {
        for(int i= -1; i<2; ++i)
        {
            for(int j= -1; j<2; ++j)
            {
                Vector2 pos = new Vector2(j * chunkSize * 2, i * chunkSize * 2);
                Lean.Pool.LeanPool.Spawn(mapPrefab, pos, new Quaternion(0, 0, 0, 0), transform);
            }
        }
    }

}
