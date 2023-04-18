using System.Collections.Generic;
using UnityEngine;

public class InfiniteLevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles; // tablica przeszkód do umieszczenia w poziomie
    [SerializeField] GameObject[] groundTiles; // tablica elementów poziomu (np. ziemi, trawy, itp.)
    [SerializeField]int numberOfGroundTiles = 10; // liczba elementów poziomu na starcie
    [SerializeField]float tileSize = 1f; // rozmiar elementu poziomu
    [SerializeField]float obstacleSpawnProbability = 0.5f; // prawdopodobieñstwo, ¿e przeszkoda zostanie wygenerowana na polu
    [SerializeField]float minObstacleX = -10f; // minimalna pozycja X przeszkody
    [SerializeField]float maxObstacleX = 10f;
    private Transform playerTransform; // transform gracza
    private float spawnZ = 0f; // pozycja Z ostatniego elementu poziomu
    private List<GameObject> activeGroundTiles; // lista aktywnych elementów poziomu
    private List<GameObject> activeObstacles; // lista aktywnych przeszkód

    void Start()
    {
        activeGroundTiles = new List<GameObject>();
        activeObstacles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // generowanie pocz¹tkowych elementów poziomu
        for (int i = 0; i < numberOfGroundTiles; i++)
        {
            SpawnGroundTile();
        }
    }

    void Update()
    {
        // jeœli gracz jest na odleg³oœæ dwóch elementów poziomu od koñca, wygeneruj nowe elementy poziomu
        if (playerTransform.position.z - 2 * tileSize > spawnZ - numberOfGroundTiles * tileSize)
        {
            SpawnGroundTile();
            DeleteGroundTile();
            SpawnObstacle();
        }
    }

    // generowanie nowego elementu poziomu
    private void SpawnGroundTile()
    {
        int randomIndex = Random.Range(0, groundTiles.Length);
        GameObject tile = Instantiate(groundTiles[randomIndex], transform.forward * spawnZ, transform.rotation);
        activeGroundTiles.Add(tile);
        spawnZ += tileSize;
    }

    // usuwanie najstarszego elementu poziomu
    private void DeleteGroundTile()
    {
        GameObject tile = activeGroundTiles[0];
        activeGroundTiles.RemoveAt(0);
        Destroy(tile);
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        if (Random.value < obstacleSpawnProbability)
        {
            float obstacleX = Random.Range(minObstacleX, maxObstacleX);
            float obstacleY = Random.Range(-0.2f, 1.5f);
            Vector3 obstaclePosition = new Vector3(obstacleX, obstacleY, spawnZ);
            GameObject obstacle = Instantiate(obstacles[randomIndex], obstaclePosition, transform.rotation);
            activeObstacles.Add(obstacle);
        }
    }
}