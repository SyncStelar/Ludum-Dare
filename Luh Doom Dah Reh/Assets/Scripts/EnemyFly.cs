using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour {
    public Transform player;
    public float speed = 0.1f;

    [SerializeField] private float maxDistanceFromPlayer = 10f;

    private bool moveLeft = false;

    private void Start() {
        if (Random.value > 0.5) {
            moveLeft = true;
        }
    }

    private void FixedUpdate() {

        transform.LookAt(player, Vector3.up);

        float x = 1;

        if (moveLeft) {
            x *= -1;
        }

        float z = 0;

        if (Vector3.Distance(player.position, transform.position) >= maxDistanceFromPlayer) {
            z = 1;
        }

        transform.Translate(new Vector3(x, 0, z) * speed * Time.deltaTime);
    }
}
