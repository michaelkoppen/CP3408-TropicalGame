using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

	public GameObject player;




	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.LookAt(player.transform);
		}
		
	}
}
