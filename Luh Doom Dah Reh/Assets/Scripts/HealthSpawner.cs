using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour {

    public static int numOfHpPacksLeft = 0;
    public static int numOfHpPacksToSpawn = 0;

    public GameObject healthPackPrefab;
    public Transform spawnPos;

    public float minSpawnRate = 15.1f;
    public float maxSpawnRate = 25.1f;
    public int maxSpawnAmount = 2;

    private bool canSpawn = true;

    private float t = 0;
    private void FixedUpdate() {
        t += Time.deltaTime;

        if (!canSpawn || t < Random.Range(minSpawnRate, maxSpawnRate)) {
            return;
        }

        if (numOfHpPacksToSpawn > 0 && numOfHpPacksLeft < maxSpawnAmount) {
            Instantiate(healthPackPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            canSpawn = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.transform.tag == "Player") {
            canSpawn = true;
        }
    }
}
