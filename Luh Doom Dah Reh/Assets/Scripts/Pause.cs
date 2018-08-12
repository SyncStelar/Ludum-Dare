using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public Canvas UICanvas;
    public Canvas PauseCanvas;


	// Use this for initialization
	void Start () {
        UICanvas.enabled = true;
        PauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = true;
            UICanvas.enabled = false;
        }
	}
}
