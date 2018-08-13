using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float speed = 1f;
    public float dmg = 15;

    public Transform player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }

    private void Update() {
        transform.Translate(0, 0, speed, Space.Self); 
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHP>().TakenDamage(dmg);
        }

        if (other.gameObject.tag != "Enemy") {
            Destroy(gameObject);
        }
    }

}
