using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;


	void Start () {
		cur_Health = max_Health;
		
	}

	public void TakeDamage(float amount){
		cur_Health -= amount;
		SetHealthBar ();
		if (cur_Health <= 0){
			Destroy (gameObject);
		}
		Debug.Log (cur_Health);
	}
	
	public void SetHealthBar(){
		float my_health = cur_Health / max_Health;
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(my_health,0f,1f),healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
