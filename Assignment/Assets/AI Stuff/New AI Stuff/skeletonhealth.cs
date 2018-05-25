using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//KYLE ADDED THIS
using UnityEngine.SceneManagement;
//END OF ADDING

public class skeletonhealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 0f;
	public Slider healthbar;
	Animator anim;

	//KYLE ADDED THIS
	[SerializeField] private string loadLevel;
	public GameObject hurtScreen;
	bool beingHurt;
	//END OF ADDING



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;

		//KYLE ADDED THIS
		beingHurt = false;
		//END OF ADDING




	}

	// Update is called once per frame
	void Update () {
		//KYLE ADDED THIS
		if (beingHurt && hurtScreen != null) {
			hurtScreen.SetActive (true);
		} else if(hurtScreen!= null) {hurtScreen.SetActive (false);
		}
		//END OF ADDING



	}

	public void healthUpdate(float damage) {
		//KYLE ADDED THIS
		StartCoroutine(FlashScreen());
		//END OF ADDING


		currentHealth += damage;
		healthbar.value = currentHealth;


		if (currentHealth <= 0) {
			Death ();
		}
	}

	public void Death() {

		//KYLE/MICHAEL ADDED THIS
		if(gameObject.CompareTag("Player") && loadLevel != null) {
			SceneManager.LoadScene (loadLevel);	
		} else {
			//Destroy (gameObject, 1f);
			anim.SetBool ("isDead", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isIdle", false);
		}

		//END OF ADDING
	}

	//ADDED BY KYLE
	IEnumerator FlashScreen(){
		if (hurtScreen != null) 
		{
			beingHurt = true;
			float time = 0;
			float hurtTime = 1f;
			while (time < hurtTime) {

				time += Time.deltaTime;
				yield return null;
			}
			beingHurt = false;
		}
	}
	//END OF ADDING

}