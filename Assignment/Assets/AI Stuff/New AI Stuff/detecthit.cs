using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detecthit : MonoBehaviour {

	//public Slider healthbar;
	private bool isHit = false;
	private float damage;
	public string opponent;
	public string character;


	void OnTriggerEnter(Collider other) {
		//other.gameObject.GetComponent<skeletonhealth> ().healthUpdate(-damage);
		isHit = true;
		Damage (other);
		//Debug.Log ("Hit");
	}

	void Damage(Collider other) {
		if (other.gameObject.tag != opponent) {
			return;
		}
		if (isHit) {
			other.gameObject.GetComponent<skeletonhealth> ().healthUpdate(-damage);
			isHit = false;
		}
	}

	// Use this for initialization
	void Start () {
		//Set the amount of damage the character will do
		if (character == "club") {
			damage = 40f;
		} else if (character == "spear") {
			damage = 20f;
		} else if (character == "sword") {
			damage = 30f;
		} else if (character == "axe") {
			damage = 20f;
		} else if (character == "skeleton") {
			damage = 30f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
