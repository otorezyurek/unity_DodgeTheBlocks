using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPositions;

    public GameObject blockPrefab;

    public float timeToSpawn;
    public float timeBetweenSpawn;
    public float timeDecrease;

    // Start is called before the first frame update
    void Update()
    {
        if(Time.time >= timeToSpawn)
		{
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenSpawn;
            timeBetweenSpawn -= timeDecrease;
        }
    }

    void SpawnBlocks()
	{
        int index = Random.Range(0, spawnPositions.Length);

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if (i != index)
            {
                Instantiate(blockPrefab, spawnPositions[i].position, Quaternion.identity);
            }
        }
    }

}
