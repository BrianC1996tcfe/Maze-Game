using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

	public float dmg;

	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
	}
}
