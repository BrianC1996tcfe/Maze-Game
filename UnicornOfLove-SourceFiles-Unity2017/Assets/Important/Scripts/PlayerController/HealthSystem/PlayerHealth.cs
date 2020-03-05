using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float max_Health;
	public float cur_Health;
	public GameObject healthBar;
	public Text health;
	private Animator anim;
	private NewMovement movement;
	private Rigidbody rb;
	private bool death_Is_Upon_You;


	void Start () {
		anim = this.GetComponent<Animator> ();
		movement = this.GetComponent<NewMovement> ();
		death_Is_Upon_You = false;
		max_Health = 100f;
		cur_Health = max_Health;
	}

	public void Update (){
		SetHealthBar ();
	}
		
	public void TakeDamage(float amount){
		cur_Health -= amount;
		SetHealthBar ();
		if (cur_Health <= 0){
			cur_Health = 0;
			if(!death_Is_Upon_You){
				death_Is_Upon_You = true;
				anim.SetBool ("Death", true);
				movement.enabled = false;
				this.gameObject.GetComponent<LevelSystem>().experience=0;
				GameObject.FindGameObjectWithTag("Splash").GetComponent<SplashScreen>().deadplayer = true;
			}
		}
	}

	public void UsePotion(float amount){
		cur_Health += amount;
		if(cur_Health >= max_Health){
			cur_Health = max_Health;
			
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
	public void revive(){
		anim.SetBool ("Death", false);
		movement.enabled = true;
		max_Health = 100f;
		cur_Health = max_Health;
		death_Is_Upon_You = false;
		SetHealthBar ();
	}
}
