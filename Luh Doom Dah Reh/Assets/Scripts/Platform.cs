using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public string leaveBoolString;
    public string appearBoolString;
    public AnimationClip isLeave;
    public AnimationClip isAppear;

    public List<int> numOfOuterPlatformsPerWave = new List<int>();
    public List<int> numOfMiddlePlatformsPerWave = new List<int>();

    public List<GameObject> goOuterLayer = new List<GameObject>();
    private List<Vector3> originOuterLayer = new List<Vector3>();

    public List<GameObject> goMiddleLayer = new List<GameObject>();
    private List<Vector3> originMiddleLayer = new List<Vector3>();

    private List<GameObject> goList = new List<GameObject>();

    private void Awake() {
        Debug.Log(isLeave.name);
        foreach (GameObject go in goOuterLayer) {
            originOuterLayer.Add(go.transform.position);
            go.SetActive(true);
            goList.Add(go);
        }

        foreach (GameObject go in goMiddleLayer) {
            originMiddleLayer.Add(go.transform.position);
            go.SetActive(true);
            goList.Add(go);
        }
    }

    private void Update() {
        OnCompleteAnim();
    }

    public void ChangePlatform(List<GameObject> list, List<int> platformPerWave) {
        List<GameObject> disappearGo = new List<GameObject>(list);
        List<GameObject> appearGo = new List<GameObject>(list);

        for (int i = 0; i < platformPerWave[(WaveCounter.waveCount - 1)]; i++) {
            disappearGo.RemoveAt(Random.Range(0, disappearGo.Count));
        }

        for (int i = 0; i < disappearGo.Count; i++) {
            appearGo.Remove(appearGo[i]);
        }

        for (int i = 0; i < appearGo.Count; i++) {
            if (appearGo[i].activeInHierarchy) {
                appearGo.Remove(appearGo[i]);
                i--;
            }
        }

        foreach (GameObject go in disappearGo) {
            Animator anim = go.GetComponent<Animator>();
            anim.SetBool(leaveBoolString, true);
        }

        foreach (GameObject go in appearGo) {
            go.SetActive(true);
            Animator anim = go.GetComponent<Animator>();
            anim.SetBool(appearBoolString, true);
        }
    }

    private void OnCompleteAnim() {
        foreach (GameObject go in goList) {
            Animator anim = go.GetComponent<Animator>();
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime >= -1) {
                if (info.IsName(isLeave.name)) {
                    go.SetActive(false);
                    anim.SetBool(leaveBoolString, false);
                }

                if (info.IsName(isAppear.name)) {
                    anim.SetBool(appearBoolString, false);
                }
            }
        }
    }

}
