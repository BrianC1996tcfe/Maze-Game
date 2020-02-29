using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float max_Health;
	public float cur_Health = 0f;
	public GameObject healthBar;
	public GameObject player;
	public GameObject invManager;
	public GameObject loot;

	public float xp;


	void Start () {
		invManager = GameObject.FindGameObjectWithTag("InvMan");
		player = GameObject.FindGameObjectWithTag ("Player");
		cur_Health = max_Health;
		loot = GameObject.FindGameObjectWithTag("smallLoot");
	}

	public void TakeDamage(float amount){
		cur_Health -= amount;
		SetHealthBar ();
		if (cur_Health <= 0) {
			Die ();
		}
	}

	public void SetHealth(float amount){
		max_Health += amount;
	}

	public void Die(){
		Vector3 pPos = this.gameObject.transform.position;
		player.gameObject.GetComponent<LevelSystem>().GainExp(xp);
		pPos.y = 1;
		Destroy (gameObject);
		GameObject enemyloot = Instantiate(loot,pPos,Quaternion.identity);
	}

	public void SetHealthBar(){
		float my_health = cur_Health / max_Health;
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(my_health,0f,1f),healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
