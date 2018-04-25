using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Test")) 
		{
			Destroy (col.gameObject);
		}
	}
	


}
