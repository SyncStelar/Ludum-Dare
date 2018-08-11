using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private bool isStationary = true;
    [SerializeField] private int enemyTypeInt = 0;
    [SerializeField] private float minSpawnRate = 10.1f;
    [SerializeField] private float MaxSpawnRate = 20.1f;

    [SerializeField] private int maxNumOfEnemies;

    [SerializeField] private List<GameObject> enemyPrefab = new List<GameObject>();

    private bool canSpawn = false;

    private float time = 0;

    private void Update() {
        time += Time.deltaTime;

        if ((!canSpawn || enemyTypeInt >= enemyPrefab.Count) && time < Random.Range(minSpawnRate, MaxSpawnRate)) {
            return;
        }

        if (EnemyAI.numEnemiesToSpawn > 0 && EnemyAI.numEnemiesLeft < maxNumOfEnemies) {
            Instantiate(enemyPrefab[enemyTypeInt], transform.position, transform.rotation);
            time = 0;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (isStationary && collision.gameObject.tag == "Player") {
            canSpawn = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (isStationary && collision.gameObject.tag == "Player") {
            canSpawn = true;
        }
    }
}
