using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damage = 100f;

	void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            PlayerHP player = col.GetComponent<PlayerHP>();
            player.TakenDamage(damage);
        }
    }
}
