using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    SphereCollider Item;

	// Use this for initialization
	void Start () {
        Item = gameObject.GetComponent<SphereCollider>();
        ScanForItems(Item);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ScanForItems(SphereCollider Item)
    {
        Vector3 center = Item.transform.position + Item.center;
        float radius = Item.radius;

        Collider[] allOverlappingColliders = Physics.OverlapSphere(center, radius);
    }
}
