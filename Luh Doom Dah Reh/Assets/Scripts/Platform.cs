using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public GameObject prefab;

    public List<int> numOfOuterPlatformsPerWave = new List<int>();
    public List<int> numOfMiddlePlatformsPerWave = new List<int>();

    public List<GameObject> goOuterLayer = new List<GameObject>();
    private List<Vector3> originOuterLayer = new List<Vector3>();

    public List<GameObject> goMiddleLayer = new List<GameObject>();
    private List<Vector3> originMiddleLayer = new List<Vector3>();

    private int numOfExistingPlatforms = 0;

    private List<GameObject> goList = new List<GameObject>();

    private void Start() {
        foreach (GameObject go in goOuterLayer) {
            originOuterLayer.Add(go.transform.position);
        }

        foreach (GameObject go in goMiddleLayer) {
            originMiddleLayer.Add(go.transform.position);
        }

        numOfExistingPlatforms = goList.Count;
    }

    private void Update()
    {

    }

    private void ChangePlatforms() {
        
    }
}
