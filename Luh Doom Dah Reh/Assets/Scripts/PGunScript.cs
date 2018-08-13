using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGunScript : MonoBehaviour {

    private bool CanFire;
    private Transform bulletSpawn;
    public Animator gunMoves;

    [SerializeField]
    public Camera cam;
    public float ProjectileSpeed = 50f;
    public float fireRate = 0.5f;
    public GameObject Projectile;


	// Use this for initialization
	void Start () {
        gunMoves = gameObject.GetComponent<Animator>();
        bulletSpawn = gameObject.transform.Find("BulletSpawn");
        CanFire = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanFire)
            {
                Fire();
            }
        }

    }

    void Fire()
    {
        RaycastHit hit;
        Vector3 TargetDirection;
        CanFire = false;
        Invoke("ResetFire", fireRate);
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 10f, false);
            Debug.Log("Did Hit");
            TargetDirection = hit.point - bulletSpawn.transform.position;
            TargetDirection.Normalize();
            gunMoves.Play("PGun_Shoot");
            var bullet = Instantiate(Projectile, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = TargetDirection * ProjectileSpeed;


        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.blue, 100f, false);
            Debug.Log("Did not Hit");
            gunMoves.Play("PGun_Shoot");

            var bullet = Instantiate(Projectile, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ProjectileSpeed;
        }

    }

    void ResetFire()
    {
        CanFire = true;
    }

}
