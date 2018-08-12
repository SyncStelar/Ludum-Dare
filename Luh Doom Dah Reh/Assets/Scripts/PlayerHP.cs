using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
    public float health = 100f;
    public Image HP;
//    public AudioSource TargetHurt;

    // Use this for initialization
    public void TakenDamage(float amount)
    {
        
//        TargetHurt.Play();
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
        Destroy(gameObject);
    }
}
