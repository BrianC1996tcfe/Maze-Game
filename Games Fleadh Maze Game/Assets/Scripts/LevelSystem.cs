using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour{


	//variables
	public float level;
	public float experience;
	public float experienceRequired;
	public Text exp;
	public Text myLevel;
	public GameObject xpBar;
	public GameObject player;
	public GameObject enemy;
	public static float myPoints;
	public float addPoints;
	//methods

	public void Start(){
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = this.gameObject;
		level = 1f;
		experience = 0;
		experienceRequired = 100;
	}

	public void Update(){
		SetLevel ();
		Exp ();
		SetXpBar();
	}

	public void GainExp(int amount){
		experience += amount;
	}

	public void SetLevel(){
		myLevel.text = "Lv : " + level.ToString ();
	}

	void LevelUp(){
		level += 1;
		experience = 0;
		experienceRequired = experienceRequired * 1.75f;
		player.gameObject.GetComponent<PlayerHealth>().IncreaseHealth(10);

		PlayerStats.points += 3f;
	}

	void Exp(){
		if (experience >= experienceRequired) {
			LevelUp ();	
		}
	}
	public void SetXpBar(){
		float my_experience = experience / experienceRequired;
		xpBar.transform.localScale = new Vector3 (Mathf.Clamp(my_experience,0f,1f),xpBar.transform.localScale.y, xpBar.transform.localScale.z);
		exp.text = "XP : " + experience.ToString ();
	}
}
