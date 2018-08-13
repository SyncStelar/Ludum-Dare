using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    [SerializeField]
    public float Damage = 40f;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 6f);


    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(Damage);
            Explode();
        }
        else
        {
            if (collision.gameObject.tag != "Player")
            {
                Explode();
                //Destroy(collision.gameObject);
                Debug.Log("Hit Something");

            }
            
        }


    }

    void Explode()
    {
        var splodin = Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
        Destroy(splodin, 1.5f);

    }
}
