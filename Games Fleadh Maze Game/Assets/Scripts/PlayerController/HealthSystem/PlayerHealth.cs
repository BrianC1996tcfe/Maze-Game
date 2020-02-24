using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float max_Health;
	public float cur_Health = 0f;
	public GameObject healthBar;
	public Text health;
	private Animator anim;
	private NewMovement movement;
	private Rigidbody rb;


	void Start () {
		anim = this.GetComponent<Animator> ();
		movement = this.GetComponent<NewMovement> ();

		max_Health = 100f;
		cur_Health = max_Health;
		SetHealthBar ();
	}
		
	public void TakeDamage(float amount){
		cur_Health -= amount;
		SetHealthBar ();
		if (cur_Health <= 0){
			anim.SetBool ("Death", true);
			movement.enabled = false;
		}
	}
	public void IncreaseHealth(float amount){
		max_Health += amount;
	}
	
	public void SetHealthBar(){
		float my_health = cur_Health / max_Health;
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(my_health,0f,1f),healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		health.text = "HP : " + cur_Health.ToString();
	}
}
