using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    GameObject currentWeapon;

    [SerializeField]
    public GameObject[] weapons;
    public Transform bulletSpawn;
    public int Num_Weapons = 2;
    public GameObject Projectile;
    public GameObject Rocket;
    public Camera cam;
    public float ProjectileSpeed = 40f;
    public float RocketSpeed = 20f;
    int slotNo;
    int lastSlot;

    bool StartWeapon;


    // Use this for initialization
    void Start()
    {
        weapons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i).gameObject;
        }
        slotNo = 0;
        StartWeapon = true;
        GetWeapon(slotNo);
        StartWeapon = false;
        //bulletSpawn = weapons[slotNo].transform.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Switch(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Switch(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    void Switch(bool scrollUp)
    {
        if (scrollUp)
        {
            if (slotNo >= Num_Weapons - 1)
            {
                slotNo = 0;
            }
            else
            {
                slotNo++;
            }
            GetWeapon(slotNo);
        }
        else
        {
            if (slotNo <= 0)
            {
                slotNo = Num_Weapons - 1;
            }
            else
            {
                slotNo--;
            }
            GetWeapon(slotNo);
        }

    }

    void GetWeapon(int currentSlot)
    {
        weapons[currentSlot].SetActive(true);
        bulletSpawn = weapons[slotNo].transform.Find("BulletSpawn");

        Debug.Log(currentSlot + " assigned");
        if (StartWeapon != true)
        {
            weapons[lastSlot].SetActive(false);
            Debug.Log(lastSlot + " removed");
        }

        lastSlot = currentSlot;
    }

    void Fire()
    {
        Debug.Log(slotNo);
        RaycastHit hit;
        Vector3 TargetDirection;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 10000000f, false);
            Debug.Log("Did Hit");
            TargetDirection = hit.point - bulletSpawn.transform.position;
            TargetDirection.Normalize();
            if (slotNo == 0)
            {
                var bullet = Instantiate(Projectile, bulletSpawn.position, bulletSpawn.rotation);

                bullet.GetComponent<Rigidbody>().velocity = TargetDirection * ProjectileSpeed;
                

            }
            if (slotNo == 1)
            {
                var bullet = Instantiate(Rocket, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = TargetDirection * RocketSpeed;
              
            }

        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.blue, 100f, false);
            Debug.Log("Did not Hit");
            if (slotNo == 0)
            {
                var bullet = Instantiate(Projectile, bulletSpawn.position, bulletSpawn.rotation);

                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ProjectileSpeed;
                

            }
            if (slotNo == 1)
            {
                var bullet = Instantiate(Rocket, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * RocketSpeed;
                
            }
        }

        
        


    }
}
