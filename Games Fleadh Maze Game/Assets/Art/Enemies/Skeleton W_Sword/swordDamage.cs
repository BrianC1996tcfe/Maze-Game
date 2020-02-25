using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamage : MonoBehaviour {

	public int dmg = 5;

	void OnTriggerEnter(Collider other){
		StartCoroutine ("Collider");
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
	}

	public void AddDamage(int amount){
		dmg += amount;
	}
		
	IEnumerator Collider(){
		this.GetComponent<BoxCollider> ().enabled = false;

		yield return new WaitForSeconds (1f);

		this.GetComponent<BoxCollider> ().enabled = true;
	}
}
