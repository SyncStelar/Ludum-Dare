﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveCounter : MonoBehaviour {
    public Text waveTextBox;

    public string endSceneString;

    public List<int> numOfEnemiesToSpawnPerWave = new List<int>();

    public static int waveCount = 0;

    public Platform platform;

    private void Start() {
        if (waveTextBox != null) {
            waveCount = 1;
            waveTextBox.text = "Wave 1";
            Debug.Log("Wave Count: " + waveCount);
            EnemyAI.numEnemiesToSpawn = numOfEnemiesToSpawnPerWave[waveCount - 1];
            platform.ChangePlatform(platform.goOuterLayer, platform.numOfOuterPlatformsPerWave);
            platform.ChangePlatform(platform.goMiddleLayer, platform.numOfMiddlePlatformsPerWave);
        }
    }

    private void Update() {
        if (waveTextBox == null) {
            return;
        }

        if (EnemyAI.numEnemiesToSpawn == 0 && EnemyAI.numEnemiesLeft == 0) {
            if (waveCount <= numOfEnemiesToSpawnPerWave.Count) {
                waveCount++;
                EnemyAI.numEnemiesToSpawn = numOfEnemiesToSpawnPerWave[waveCount];
                platform.ChangePlatform(platform.goOuterLayer, platform.numOfOuterPlatformsPerWave);
                platform.ChangePlatform(platform.goMiddleLayer, platform.numOfMiddlePlatformsPerWave);
            } else if (endSceneString != null) {
                SceneManager.LoadScene(endSceneString);
            }
        } 

        if (waveTextBox != null /*&& waveTextBox.text == string.Format("Wave {0}", waveCount)*/) {
            waveTextBox.text = string.Format("Wave {0}", waveCount);
        }
    }
}
