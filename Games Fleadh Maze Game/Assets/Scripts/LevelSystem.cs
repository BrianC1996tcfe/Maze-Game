using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour{

	public int curlevel;

	public GameObject bar;

	//for string purposes
	public float xp;
	public Text playerXP;
	//--------------------
	public float curxp;
	public float xptolevel;
	public float nextlevelxp;
	//xp bracket is a next level xp multiplier. which means when you lvele up youll have to earn more xp to level up
	public float xpbracket;


	public void Start(){
		xp = curxp;
		HandleXpBar ();

	}

	public void UpdateXP(float amount){
		curxp += amount;

		int level = (int)(0.1f * Mathf.Sqrt (amount));

		if(level != curlevel){
			
			curlevel = level;
			//here youd add a level up message or something like that.
		}

	}

	public void HandleXpBar(){
		float my_xp = curxp / xptolevel;
		bar.transform.localScale = new Vector3 (Mathf.Clamp(my_xp,0f,1f),bar.transform.localScale.y, bar.transform.localScale.z);
		playerXP.text = "XP : " + curxp.ToString ();
	}




}
