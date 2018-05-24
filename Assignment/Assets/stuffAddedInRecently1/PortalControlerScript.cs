using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControlerScript : MonoBehaviour {

	//Initializing enemie
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;

	public GameObject lvlPortal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null)
		{
			lvlPortal.SetActive(true);
		}
	

	}
}
