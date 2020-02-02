using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementControl : MonoBehaviour {

	public float moveSpeed;
	Animator anim;
	private Rigidbody rb;

	void Start (){
		anim = GetComponent<Animator> ();
		//rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		PlayerMovement ();
		Animations ();
	}

	void PlayerMovement(){
		anim.SetBool ("Idle", false);

		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		Vector3 playerMovement = new Vector3 (hor, 0f, ver) * moveSpeed * Time.deltaTime;
		transform.Translate (playerMovement, Space.Self);

	}

	void Animations(){
		
		if(Input.GetKeyDown("w")){
			anim.SetBool ("Front", true);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Idle", false);
		}else if(Input.GetKeyUp("w")){
			anim.SetBool ("Front", false);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Idle", true);
		}
	
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger ("Attack");
		}
	}
	private void OnTriggerEnter(Collider other){
	}
}
	
