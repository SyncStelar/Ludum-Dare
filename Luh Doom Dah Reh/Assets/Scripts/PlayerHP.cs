using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {
    public float health = 100f;
    public Image HP;
    public AudioClip TargetHurt;

    public string gameOverSceneString;

    // Use this for initialization
    public void TakenDamage(float amount)
    {

        GetComponent<AudioSource>().PlayOneShot(TargetHurt);
        health -= amount;
        if (health <= 0f)
        {
            Eliminate();
        }
        HP.fillAmount = health;
    }

    // Update is called once per frame
    void Eliminate()
    {
        SceneManager.LoadScene(gameOverSceneString);
    }
}
