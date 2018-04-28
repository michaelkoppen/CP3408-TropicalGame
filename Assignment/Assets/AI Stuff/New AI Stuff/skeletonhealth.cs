using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skeletonhealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 0f;
	public Slider healthbar;
	Animator anim;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void healthUpdate(float damage) {
		currentHealth += damage;
		healthbar.value = currentHealth;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	public void Death() {
		Destroy (gameObject, 1f);
		anim.SetTrigger ("isDead");

	}
}
