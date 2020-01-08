using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpControl : MonoBehaviour {

	public float jumpForce;
	private Rigidbody rb;
	private bool onGround = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && onGround){
			rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
			onGround = false;
		}
	}
	void OnCollisionEnter(Collision collision){
		onGround = true;
	}
}
