using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
	
	public float dmg;

	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponent<EnemyHealth> ().TakeDamage (dmg);
	}
}
