using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonThrowerController : MonoBehaviour {

	public Transform player;
	public Animator anim;
	public Transform firePoint;
	public GameObject bonePrefab;
	private float shootTime = 2.3f;
	private float shootDelay = 3.5f;

	public int ID;

	void Start(){
		anim = this.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	void Update () {
		if (Vector3.Distance (player.position, this.transform.position) < 13) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 3f * Time.deltaTime);

			anim.SetBool ("isIdle", false);

			if (direction.magnitude > 10) {
				//0.05f is the movement speed towards the player
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
				InvokeRepeating ("Shoot", shootTime, shootDelay);
			}
		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
		}
	}
	void Shoot (){
		Instantiate (bonePrefab, firePoint.position, firePoint.rotation);
		CancelInvoke ("Shoot");
	}
}
