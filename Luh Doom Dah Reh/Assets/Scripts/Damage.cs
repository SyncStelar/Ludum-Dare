using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damage = 100f;

	void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            PlayerHP player = col.gameObject.GetComponent<PlayerHP>();
            player.TakenDamage(damage);
        }
    }
}
