using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLauncher_Script : MonoBehaviour {

    // Use this for initialization
    private bool CanFire;
    private Transform bulletSpawn;
    public Animator RocketMoves;

    [SerializeField]
    public Camera cam;
    public float RocketSpeed = 15f;
    public float fireRate = 2f;
    public GameObject Rocket;


    // Use this for initialization
    void Start()
    {
        RocketMoves = gameObject.GetComponent<Animator>();
        bulletSpawn = gameObject.transform.Find("BulletSpawn");
        CanFire = true;

    }

    // Update is called once per frame
    void Update()
    {
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
            RocketMoves.Play("RLauncher_Shoot");
            var bullet = Instantiate(Rocket, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = TargetDirection * RocketSpeed;


        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.blue, 100f, false);
            Debug.Log("Did not Hit");
            RocketMoves.Play("RLauncher_Shoot");

            var bullet = Instantiate(Rocket, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * RocketSpeed;
        }

    }

    void ResetFire()
    {
        CanFire = true;
    }

}
