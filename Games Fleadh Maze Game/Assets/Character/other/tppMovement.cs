using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tppMovement : MonoBehaviour {


	public float speed = 5f;
	public float rotationSpeed = 100f;

	Animator anim;

	void Start () {
		anim = this.GetComponent<Animator> ();
	}

	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed * 2f;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);

		if (translation != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("CharSpeed", translation);
		} else {
			anim.SetBool ("isWalking", false);
			anim.SetFloat ("CharSpeed", 0);
		}
	}
}
