using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float randomYoffset = 2.5f;
    public float spawnDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float yOffset = Random.Range(-randomYoffset, randomYoffset);
        Instantiate(pipePrefab, transform.position + Vector3.up * yOffset, transform.rotation);
    }
}
