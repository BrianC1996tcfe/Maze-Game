using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float max_Health;
	public float cur_Health = 0f;
	public GameObject healthBar;
	public GameObject player;

	public int xp = 5;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		max_Health = 25f;
		cur_Health = max_Health;
	}

	public void TakeDamage(float amount){
		cur_Health -= amount;
		SetHealthBar ();
		if (cur_Health <= 0) {
			Die ();
		}
	}

	public void Die(){
		player.gameObject.GetComponent<LevelSystem>().GainExp(xp);
		Destroy (gameObject);
	}

	public void SetHealthBar(){
		float my_health = cur_Health / max_Health;
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(my_health,0f,1f),healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
