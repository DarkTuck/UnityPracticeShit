using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnRate = 3;
    public int spawnCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
  
        for(int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(-7f, 4f);
            float y = Random.Range(-4f, 4f);
            Vector3 spawnPosition = new Vector3(x, y, 0);
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }

    }
}
