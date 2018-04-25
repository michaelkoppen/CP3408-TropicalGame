using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skeletonhealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 0f;
	public Slider healthbar;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

	}

	// Update is called once per frame
	void Update () {

	}

	public void healthUpdate(float damage) {
		if (currentHealth < 0) {
			//Do death stuff
		} else {
			currentHealth += damage;
			healthbar.value = currentHealth;
			Debug.Log ("Damage Dealt:" + damage);
			Debug.Log ("Current Health:" + currentHealth);
			Debug.Log ("Current Health:" + healthbar.value);
		}
	}
}
