using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour{

	public Animator anim;

	public void Start(){
		anim = this.GetComponent<Animator> ();
	}

	public void Roll(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			anim.SetBool ("Roll", true);
			this.GetComponent<NewMovement> ().enabled = false;
		} else {
			this.GetComponent<NewMovement> ().enabled = true;
		}

	}
}
