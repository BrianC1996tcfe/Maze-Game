using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour {

	public float speed;
	public float dmg;
	public Rigidbody rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
		Destroy (gameObject);
	}
}
