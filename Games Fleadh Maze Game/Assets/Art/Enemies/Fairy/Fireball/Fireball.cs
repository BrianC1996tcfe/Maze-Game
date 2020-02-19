using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public int dmg;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
		Destroy (gameObject);
	}
}
