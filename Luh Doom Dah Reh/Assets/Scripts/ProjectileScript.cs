using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

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
                collision.gameObject.GetComponent<EnemyAI>().TakeDamage(15f);
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
