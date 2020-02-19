﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamage : MonoBehaviour {

	public float dmg;

	void OnTriggerEnter(Collider other){
		StartCoroutine ("Collider");
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
	}

	IEnumerator Collider(){
		this.GetComponent<BoxCollider> ().enabled = false;

		yield return new WaitForSeconds (1f);

		this.GetComponent<BoxCollider> ().enabled = true;
	}
}
