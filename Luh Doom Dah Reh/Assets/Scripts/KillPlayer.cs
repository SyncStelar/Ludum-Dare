﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHP>().TakenDamage(collision.gameObject.GetComponent<PlayerHP>().health);
        }
    }
}
