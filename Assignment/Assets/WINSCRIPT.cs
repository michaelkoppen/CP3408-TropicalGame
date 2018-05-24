using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINSCRIPT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.CompareTag ("Player")) {
			print ("YOU WIN");
			Application.Quit();
		}

		print ("tehe");
		if (other.CompareTag("boulder")) {
			Destroy (other.gameObject);
		}

	}
}
