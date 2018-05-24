using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoulderBoulder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onCollisionEnter(Collision col) {
		if (col.gameObject.tag == "lava") {
			Destroy (gameObject);
		}
	}
}
