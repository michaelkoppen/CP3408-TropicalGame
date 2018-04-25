using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			GetComponent<Animation>().Play("WeaponAttack");
		}
		
	}
}
