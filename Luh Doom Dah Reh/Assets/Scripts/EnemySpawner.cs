using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public bool isStationary = true;
    //[SerializeField] private float minSpawnRate = 10.1f;
    //[SerializeField] private float MaxSpawnRate = 20.1f;

    //[SerializeField] private int maxNumOfEnemies;

    public Transform spawnPos;
    [SerializeField] private GameObject enemyPrefab;

    [System.NonSerialized] public bool canSpawn = true;

    //private float time = 0;

    //private void Update() {
    //    time += Time.deltaTime;

    //    if ((!canSpawn || spawnPos != null || enemyTypeInt >= enemyPrefab.Count) && time < Random.Range(minSpawnRate, MaxSpawnRate)) {
    //        return;
    //    }

    //    if (EnemyAI.numEnemiesToSpawn > 0 && EnemyAI.numEnemiesLeft < maxNumOfEnemies) {
    //        Instantiate(enemyPrefab[enemyTypeInt], spawnPos.transform.position, spawnPos.transform.rotation);
    //        time = 0;
    //    }
    //}

    public void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
    }
}
