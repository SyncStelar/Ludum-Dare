using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    GameObject currentWeapon;

    [SerializeField]
    public GameObject[] weapons;
    public int Num_Weapons = 2;
    public Camera cam;
    public Animator GunAnim;
    public Transform weapon_ui;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKeyDown("c"))
        {
            Switch(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Switch(false);
        }
        if (Input.GetKeyDown("1"))
        {
            if (slotNo != 0)
            {
                slotNo = 0;
                GetWeapon(slotNo);
            }
            
        }
        if (Input.GetKeyDown("2"))
        {
            if (slotNo != 1)
            {
                slotNo = 1;
                GetWeapon(slotNo);
            }

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
        GunAnim = weapons[currentSlot].GetComponent<Animator>();
        if (currentSlot == 0)
        {
            GunAnim.Play("P_Gun_Draw");
            weapon_ui.Find("RocketLauncher").gameObject.SetActive(false);

            weapon_ui.Find("Pistol").gameObject.SetActive(true);

        }
        if (currentSlot == 1)
        {
            GunAnim.Play("RLauncher_Draw");
            weapon_ui.Find("Pistol").gameObject.SetActive(false);

            weapon_ui.Find("RocketLauncher").gameObject.SetActive(true);

        }
        Debug.Log(currentSlot + " assigned");
        if (StartWeapon != true)
        {
            weapons[lastSlot].SetActive(false);
            Debug.Log(lastSlot + " removed");
        }

        lastSlot = currentSlot;
    }

   

    
}

