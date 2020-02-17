using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour{


	//variables
	public float level;
	private float experience;
	private float experienceRequired;
	public Text exp;
	public Text myLevel;
	public GameObject xpBar;


	//methods

	void Start(){
		level = 1;
		experience = 0;
		experienceRequired = 100;
	}

	void Update(){
		Exp ();
		SetXpBar();
		SetLevel ();
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
		//experienceRequired = experienceRequired * 1.2;
		IncreaseHealth ();
	}

	public void IncreaseHealth(){
		this.gameObject.GetComponent<PlayerHealth> ().OnLevelUp (10);
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
