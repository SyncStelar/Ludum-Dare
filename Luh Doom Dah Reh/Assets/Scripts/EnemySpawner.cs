using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private int maxNumOfEnemies;

    private void Update() {
        if (EnemyAI.numEnemiesToSpawn > 0 && EnemyAI.numEnemiesLeft < maxNumOfEnemies) {

        }
    }
}
