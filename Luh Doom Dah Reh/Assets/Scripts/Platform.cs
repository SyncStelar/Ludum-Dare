using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public GameObject prefab;
    List<GameObject> goList;
    void Start()
    {
        goList = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            // This random position is for fun :D
            Vector3 rndPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));

            // Create a new GameObject from prefab and move to random position
            goList.Add((GameObject)Instantiate(prefab, rndPos, Quaternion.identity));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(goList.Count);
            foreach (GameObject go in goList)
            {
                Debug.Log(go.name);
            }
        }
    }
}
