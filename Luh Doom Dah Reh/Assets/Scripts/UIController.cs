using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ChangeScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public void EnableGO(GameObject go) {
        go.SetActive(true);
    }

    public void DisableGO(GameObject go) {
        go.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
