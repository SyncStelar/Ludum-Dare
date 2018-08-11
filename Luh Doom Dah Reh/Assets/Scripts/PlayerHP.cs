using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {
    public float health = 100f;
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
    }

    // Update is called once per frame
    void Eliminate()
    {
        Destroy(gameObject);
    }
}
