using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistance : MonoBehaviour {

	public Transform target;
	public float range;
	public float dx;
	public float midRange;

	private Transform transform;
	private Vector3 offset;
	public AudioSource Audio;
	public float volume;



	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		dx = 0.0f;
		Audio.volume = 0.0f;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform) {
			offset = target.position - transform.position;
			dx = offset.sqrMagnitude;
		}


		if(dx < range * range){
			Debug.Log ("Range 1");
		}


		if(dx < midRange * midRange){
			Debug.Log ("Range 2");
			volume = 0.5f - dx / (midRange * midRange);
			Audio.volume = volume;
		}




	}
}
