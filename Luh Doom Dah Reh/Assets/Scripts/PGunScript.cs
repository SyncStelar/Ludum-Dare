using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGunScript : MonoBehaviour {
    [SerializeField]
    public Transform bulletSpawn;
    public GameObject Projectile;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    void Fire()
    {
        var bullet = Instantiate(Projectile, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5f;
        Destroy(bullet, 2.0f);


    }
}
