using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveCounter : MonoBehaviour {
    public Text waveTextBox;

    public string endSceneString;

    public List<int> numOfEnemiesToSpawnPerWave = new List<int>();

    public static int waveCount = 1;

    private void Start() {
        if (waveTextBox != null) {
            waveTextBox.text = "Wave 0";
        }
    }

    private void Update() {
        if (waveTextBox != null && waveTextBox.text == string.Format("Wave {0}", waveCount)) {
            return;
        }

        if (EnemyAI.numEnemiesToSpawn == 0 && EnemyAI.numEnemiesLeft == 0) {
            if (waveCount < numOfEnemiesToSpawnPerWave.Count) {
                waveCount++;
                if (waveCount < numOfEnemiesToSpawnPerWave.Count) {
                    EnemyAI.numEnemiesToSpawn = numOfEnemiesToSpawnPerWave[waveCount];
                }
            } else if (endSceneString != null) {
                SceneManager.LoadScene(endSceneString);
            }
        } 

        if (waveTextBox != null) {
            waveTextBox.text = string.Format("Wave {0}", waveCount);
        }
    }
}
