using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {

	[SerializeField] private string loadLevel;

	void OnTriggerEnter (Collider other)
	{
		
		if (other.CompareTag ("Player")) {
			SceneManager.LoadScene (loadLevel);
		}

		print ("tehe");
		if (other.CompareTag("boulder")) {
			Destroy (other.gameObject);
		}

	}
}