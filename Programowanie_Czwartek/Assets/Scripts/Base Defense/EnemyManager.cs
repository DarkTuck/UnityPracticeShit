using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    private int currentWave = 0;
    private int currentCycleWave = 0;
    private int waveCycle = 1;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] SpawnData[] spawnWaves;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [HideInInspector]
    public List<Enemy> activeEnemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        waveText.text = currentWave.ToString();
    }

    void Spawn()
    {
        SpawnData currentSpawnData = spawnWaves[currentCycleWave];
        for(int i = 0; i < currentSpawnData.count * waveCycle; i++)
        {
            Vector3 pos = new Vector3(Random.Range(minX, maxX),
                Random.Range(minY, maxY), 0);

            Enemy enemyToSpawn = currentSpawnData.possibleEnemies
                [Random.Range(0, currentSpawnData.possibleEnemies.Length)];

            Enemy spawnedEnemy = Instantiate(enemyToSpawn, pos, Quaternion.identity);
            activeEnemies.Add(spawnedEnemy);
        }

    }

    public void OnEnemyKilled(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        if(activeEnemies.Count <= 0)
        {
            currentWave++;
            currentCycleWave++;
            if(currentCycleWave >= spawnWaves.Length)
            {
                waveCycle++;
                currentCycleWave = 0;
            }
            waveText.text = currentWave.ToString();
            Spawn();
        }
    }
}
