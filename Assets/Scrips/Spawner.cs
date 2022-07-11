using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public ScriptableEnemy spawnManager;

    int cantSpawn = 4;

    void Start()
    {
        Spawning();
    }

    void Spawning()
    {
        int Spawned = 0;

        for (int i = 0; i < spawnManager.cant; i++)
        {
            GameObject currentEntity = Instantiate(enemyPrefab, spawnManager.spawnPoint[Spawned], Quaternion.identity);
            currentEntity.name = spawnManager.prefabName + cantSpawn;
            Spawned = (Spawned + 1) % spawnManager.spawnPoint.Length;

            cantSpawn++;
        }
    }
}
