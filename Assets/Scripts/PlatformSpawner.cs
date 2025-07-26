using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;      // Assign your Ground prefab here
    public Transform player;               // Assign the Player transform here
    public float platformLength = 10f;     // Z-length of your ground tile
    public int initialPlatforms = 5;       // Number of starting platforms
    public float spawnDistanceAhead = 30f; // How far ahead to keep spawning

    private float spawnZ = 0f;
    private Queue<GameObject> spawnedPlatforms = new Queue<GameObject>();

    void Start()
    {
        // Spawn initial platforms
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // If player is close to the last spawn point, add a new platform
        if (player.position.z + spawnDistanceAhead > spawnZ)
        {
            SpawnPlatform();
            RemoveOldPlatform();
        }
    }

    void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3(0, 0, spawnZ);
        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        spawnedPlatforms.Enqueue(newPlatform);
        spawnZ += platformLength;
    }

    void RemoveOldPlatform()
    {
        // Remove the oldest platform to save memory
        if (spawnedPlatforms.Count > initialPlatforms)
        {
            Destroy(spawnedPlatforms.Dequeue());
        }
    }
}
