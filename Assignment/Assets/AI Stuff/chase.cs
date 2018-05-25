using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class chase : MonoBehaviour {

	public Transform player;
	Animator anim;
	private bool collidedWithPlayer = false;
	NavMeshAgent nav;
	public string character;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	float moveSpeed = 3f; 
	float rotSpeed = 5f;
	float accuracyWP = 5.0f;

	private bool isWandering = false;
	private bool isRotatingLeft = false;
	private bool isRotatingRight = false;
	private bool isWalking = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		//float angle = Vector3.Angle (direction, head.up);

		if (state == "patrol" && waypoints.Length > 0) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isAttacking", false);

			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) {
				currentWP++;
				if (currentWP >= waypoints.Length) {
					currentWP = 0;
				}
			}
			//rotate towards next waypoint
			direction = waypoints [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			//this.transform.Translate (0, 0, Time.deltaTime * moveSpeed);
			nav.SetDestination (waypoints [currentWP].transform.position);
		}

		if (character == "skeleton") {
			if (anim.GetBool ("isDead")) {
				nav.SetDestination (this.transform.position);
				Destroy (gameObject, 2.5f);
			} else {
				if (Vector3.Distance (player.position, this.transform.position) < 5 || state == "pursuing") {
					state = "pursuing";
					//nav.SetDestination (player.position);
					this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
					if (direction.magnitude > 2) {
						//this.transform.Translate (0, 00, Time.deltaTime * moveSpeed);
						nav.SetDestination (player.position);
						anim.SetBool ("isIdle", false);
						anim.SetBool ("isWalking", true);
						anim.SetBool ("isAttacking", false);
					} else {
						this.transform.Translate (0, 00, 0);
						anim.SetBool ("isIdle", false);
						anim.SetBool ("isWalking", false);
						anim.SetBool ("isAttacking", true);
					}
				} else {
					state = "patrol";
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isAttacking", false);
				}
			}

		} else if (character == "golem") {
			if (Vector3.Distance (player.position, this.transform.position) < 15 || state == "pursuing") {
				state = "pursuing";
				//nav.SetDestination (player.position);
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
				if (direction.magnitude > 8) {
					//this.transform.Translate (0, 00, Time.deltaTime * moveSpeed);
					nav.SetDestination (player.position);
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isAttacking", false);
				} else {
					this.transform.Translate (0, 00, 0);
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isAttacking", true);
				}
			} else {
				state = "patrol";
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			}
		}
	}
}
		//if (Vector3.Distance (player.position, this.transform.position) < 10) {
		//	
		//
		//	this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
		//
		//	anim.SetBool ("isIdle", false);
		//	if (direction.magnitude > 3) {
		//		this.transform.Translate (0, 0, 0.05f);
		//		anim.SetBool ("isWalking", true);
		//		anim.SetBool ("isAttacking", false);
		//	} else {
		//		anim.SetBool ("isAttacking", true);
		//		anim.SetBool ("isWalking", false);
		//	} 
		//} //else {
		//	//anim.SetBool ("isIdle", true);
		//	//anim.SetBool ("isWalking", false);
		//	//anim.SetBool ("isAttacking", false);
		//	if (isWandering == false) {
		//		StartCoroutine (Wander ());
		//	}
		//	if (isRotatingRight == true) {
		//		anim.SetBool ("isIdle", true);
		//		anim.SetBool ("isWalking", false);
		//		anim.SetBool ("isAttacking", false);
		//		transform.Rotate (transform.up * Time.deltaTime * rotSpeed);
		//	}
		//	if (isRotatingLeft == true) {
		//		anim.SetBool ("isIdle", true);
		//		anim.SetBool ("isWalking", false);
		//		anim.SetBool ("isAttacking", false);
		//		transform.Rotate (transform.up * Time.deltaTime * -rotSpeed);
		//	}
		//	if (isWalking == true) {
		//		anim.SetBool ("isIdle", false);
		//		anim.SetBool ("isWalking", true);
		//		anim.SetBool ("isAttacking", false);
		//		this.transform.Translate (0, 0, 0.05f);
		//	}
		//}
	
		


	//IEnumerator Wander() {
	//	int rotTime = Random.Range (1, 3);
	//	int rotateWait = Random.Range (1, 4);
	//	int rotateLorR = Random.Range (1, 2);
	//	int walkWait = Random.Range (1, 4);
	//	int walkTime = Random.Range (1, 5);
	//
	//	isWandering = true;
	//
	//	yield return new WaitForSeconds (walkWait);
	//	isWalking = true;
	//	yield return new WaitForSeconds (walkTime);
	//	isWalking = false;
	//	yield return new WaitForSeconds (rotateWait);
	//	if (rotateLorR == 1) {
	//		isRotatingRight = true;
	//		yield return new WaitForSeconds (rotTime);
	//		isRotatingRight = false;
	//	}
	//	if (rotateLorR == 2) {
	//		isRotatingLeft = true;
	//		yield return new WaitForSeconds (rotTime);
	//		isRotatingLeft = false;
	//	}
	//	isWandering = false;
	//}
