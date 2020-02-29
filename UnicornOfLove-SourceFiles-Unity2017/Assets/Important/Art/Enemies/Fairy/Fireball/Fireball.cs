using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public int dmg = 5;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.forward * speed;
	}
	public void AddDamage(int amount){
		dmg += amount;
	}
	public IEnumerator strayBullets(){
		yield return new WaitForSeconds(10f);
		Destroy (gameObject);
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Player"){
		other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (dmg);
		Destroy (gameObject);
		}
		else{
			StartCoroutine(strayBullets());
		}
		// if(!(other.gameObject.tag=="Enemy")){
			
		// }
		//Destroy (gameObject);
	}
}
