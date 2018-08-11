using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    GameObject currentWeapon;

    [SerializeField]
    public GameObject[] weapons;
    //public GameObject[] Shot;
    //public Transform BulletSpawn;
    public int Num_Weapons = 2;
    int slotNo;
    int lastSlot;
    bool StartWeapon;


	// Use this for initialization
	void Start () {
        weapons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i).gameObject;
        }
        slotNo = 0;
        StartWeapon = true;
        GetWeapon(slotNo);
        StartWeapon = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            Switch(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Switch(false);
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
                slotNo ++;
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
                slotNo --;
            }
            GetWeapon(slotNo);
        }

    }

    void GetWeapon(int currentSlot)
    {
        weapons[currentSlot].SetActive(true);
        Debug.Log(currentSlot + " assigned");
        if (StartWeapon != true)
        {
            weapons[lastSlot].SetActive(false);
            Debug.Log(lastSlot + " removed");
        }
      
        lastSlot = currentSlot;
    }
}
