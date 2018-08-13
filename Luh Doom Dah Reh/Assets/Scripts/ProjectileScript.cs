using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float damage = 15f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Hit Something");
            }

        }

        

        
    }
}
