using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour {

	public float speed;
	public int dmg = 5;
	public Rigidbody rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		rb = this.GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
	public void AddDamage(int amount){
		dmg += amount;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Player"){
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
		}
		Destroy (gameObject);
	}
}
