using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour {

    [SerializeField] private Transform player;

    private void FixedUpdate() {
        transform.LookAt(player, Vector3.up);
    }
}
