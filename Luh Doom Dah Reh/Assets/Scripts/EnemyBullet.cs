using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float speed = 1f;

    private void Update() {
        transform.Translate(0, 0, speed, Space.Self); 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Enemy") {
            Destroy(gameObject);
        }
    }

}
