using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public float radius = 5f;
    public float damage = 30f; 

	// Use this for initialization
	void Start () {
        Explode();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Explode()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            if(hit.gameObject.tag == "Enemy")
            {
                float distance = Vector3.Distance(explosionPosition, hit.gameObject.transform.position);
                float distanceMultiplier = radius - distance;
                hit.gameObject.GetComponent<EnemyAI>().TakeDamage(damage * Mathf.Abs(distanceMultiplier));

            }
            
        }
        Destroy(gameObject,1f);
    }
}
