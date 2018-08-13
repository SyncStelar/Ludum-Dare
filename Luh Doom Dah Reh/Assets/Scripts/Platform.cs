using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public string leaveBoolString;
    public string appearBoolString;
    public AnimationClip isLeave;
    public AnimationClip isAppear;
    public AnimationClip isHidden;
    public AnimationClip isIdle;

    public int maxNumOfEnemies = 5;

    public float minSpawnRate = 5f;
    public float maxSpawnRate = 10f;

    public float spawnPercentChance = 3;

    public Material originalMat;
    public Material coloredMat;

    public List<int> numOfOuterPlatformsPerWave = new List<int>();
    public List<int> numOfMiddlePlatformsPerWave = new List<int>();

    public List<GameObject> goOuterLayer = new List<GameObject>();
    //private List<Vector3> originOuterLayer = new List<Vector3>();

    public List<GameObject> goMiddleLayer = new List<GameObject>();
    //private List<Vector3> originMiddleLayer = new List<Vector3>();

    private List<GameObject> goList = new List<GameObject>();

    private void Start() {
        foreach (GameObject go in goOuterLayer) {
            //originOuterLayer.Add(go.transform.position);
            goList.Add(go);
        }

        foreach (GameObject go in goMiddleLayer) {
            //originMiddleLayer.Add(go.transform.position);
            goList.Add(go);
        }
    }

    private float t = 0;

    private void Update() {
        t += Time.deltaTime;
        SpawnCheck();
        OnCompleteAnim();
    }

    private void SpawnCheck() {
        if (EnemyAI.numEnemiesToSpawn > 0 && t > Random.Range(minSpawnRate, maxSpawnRate) && EnemyAI.numEnemiesLeft < maxNumOfEnemies) {
            for (int i = 0; i < goList.Count; i++) {
                float avgSpawnRate = (maxSpawnRate - minSpawnRate) / 2 * (spawnPercentChance /100);
                bool spawn = false;
                if ((avgSpawnRate + minSpawnRate) >= Random.Range(minSpawnRate, maxSpawnRate)) {
                    spawn = true;
                }
                if (spawn && EnemyAI.numEnemiesToSpawn > 0 && EnemyAI.numEnemiesLeft < maxNumOfEnemies) {
                    if (goList[i].GetComponent<EnemySpawner>() && goList[i].GetComponent<EnemySpawner>().canSpawn && goList[i].GetComponent<EnemySpawner>().canSpawnCollider) {
                        goList[i].GetComponent<EnemySpawner>().SpawnEnemy();
                    }
                }
            }
            t = 0;
        }
    }

    public void ChangePlatform(List<GameObject> list, List<int> platformPerWave) {
        List<GameObject> disappearGo = new List<GameObject>(list);
        List<GameObject> appearGo = new List<GameObject>(list);

        Debug.Log("ChangePlatform 1");

        //removes x platforms from list of removing platforms.
        for (int i = 0; i < platformPerWave[(WaveCounter.waveCount - 1)]; i++) {
            disappearGo.RemoveAt(Random.Range(0, disappearGo.Count));
        }
        Debug.Log("changePlatform 2");

        //removes platforms to be removed from scene from list of platforms to be returned.
        for (int j = 0; j < disappearGo.Count; j++) {
            appearGo.Remove(disappearGo[j]);
        }

        Debug.Log("changePlatform 3");

        //check if that platform is running idle animation. if yes, remove those platforms from list of platforms to be returned.
        for (int k = 0; k < appearGo.Count; k++) {
            Animator anim = appearGo[k].GetComponentInChildren<Animator>(true);
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime >= -1 && info.IsName(isIdle.name)) {
                appearGo.Remove(appearGo[k]);
                k--;
            }
        }

        Debug.Log("changePlatform 4");

        //set platforms to be removed into red and activate animation isLeave.
        foreach (GameObject go in disappearGo) {
            Animator anim = go.GetComponentInChildren<Animator>(true);

            anim.SetBool(leaveBoolString, true);
            go.GetComponent<EnemySpawner>().canSpawn = false;
        }

        Debug.Log("changePlatform 5");

        //activate isAppear animation
        foreach (GameObject go in appearGo) {
            Animator anim = go.GetComponentInChildren<Animator>(true);

            anim.SetBool(appearBoolString, true);
            go.GetComponent<EnemySpawner>().canSpawn = true;
        }
    }

    private void OnCompleteAnim() {
        foreach (GameObject go in goList) {
            Animator anim = go.GetComponentInChildren<Animator>(true);
            Renderer rend = go.GetComponentInChildren<Renderer>(true);

            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

            if (info.IsName(isLeave.name)) {
                rend.material = coloredMat;
            } else {
                rend.material = originalMat;
            }

            if (info.normalizedTime >= -1) {
                if (info.IsName(isLeave.name)) {
                    anim.SetBool(leaveBoolString, false);
                }

                if (info.IsName(isAppear.name)) {
                    anim.SetBool(appearBoolString, false);
                }
            }
        }
    }

}
