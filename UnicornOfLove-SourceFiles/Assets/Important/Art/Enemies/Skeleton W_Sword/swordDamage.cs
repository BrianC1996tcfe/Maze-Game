using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamage : MonoBehaviour {

	public int dmg = 5;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="Player") {
			other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
		}
	}
	public void AddDamage(int amount){
		dmg += amount;
	}
}
