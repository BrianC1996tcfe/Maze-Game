using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {


	//stats
	public static int Health;
	public static int Strenght;
	public int Dexterity;
	public int PhysicalDefense;
	public int MagicResist;

	//values
	public float hpToGive;
	public float speedToGive;
	public static float points;

	//Game Objects
	public GameObject charProfile;
	public GameObject cameraPrefab;
	public GameObject playerPrefab;

	public Button hpBtn;
	public Button strBtn;
	public Button dexBtn;
	public Button mrBtn;
	public Button pdBtn;

	//text boxes
	public Text	Hp;
	public Text Str;
	public Text	Dex;
	public Text	Mr;
	public Text	Dr;
	public Text Points;
	//public Text AtkSpeed;
	//public Text MovSpeed;


	//methods
	public void Start(){
		Button btnStr = strBtn.GetComponent<Button> ();
		btnStr.onClick.AddListener(strBtnOnClick);

		Button btnHp = hpBtn.GetComponent<Button> ();
		btnHp.onClick.AddListener(hpBtnOnClick);

		Button btnDex = dexBtn.GetComponent<Button> ();
		btnDex.onClick.AddListener(dexBtnOnClick);

		hpToGive = 10f;
		speedToGive = 0.02f;

		Dexterity = 5;
		Health = 10;
		Strenght = 5;

	}
		
	public void Update(){
		Points.text = "Points : " + points.ToString ();
		Str.text = "Str : " + Strenght.ToString ();
		Hp.text = "Hp : " + Health.ToString ();
		Dex.text = "Dex : " + Dexterity.ToString ();

		if (Input.GetKeyDown (KeyCode.P)) {
			switch (charProfile.activeSelf) {
			case true:
				CloseCharInfo ();
				break;
			case false:
				OpenCharInfo ();
				break;
			}	
		}
		if (points <= 0) {
			hpBtn.interactable = false;
			strBtn.interactable = false;
			dexBtn.interactable = false;
		} else if (points >=1 ){
			hpBtn.interactable = true;
			strBtn.interactable = true;
			dexBtn.interactable = true;
		}
	}

	public void GivePoints(float amount){
		points += amount;
	}

	public void dexBtnOnClick(){
		Dexterity += 1;
		points -= 1;
		playerPrefab.gameObject.GetComponent<NewMovement> ().IncreaseMovementSpeed (speedToGive);
	}

	public void hpBtnOnClick(){
		Health += 1;
		points -= 1;
		playerPrefab.gameObject.GetComponent<PlayerHealth> ().IncreaseHealth (hpToGive);
	}

	public void strBtnOnClick(){
		Strenght += 1;
		points -= 1;
	}

	public void OpenCharInfo(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		charProfile.SetActive (true);
		cameraPrefab.GetComponent<cameraFollow>().enabled = false;
		playerPrefab.GetComponent<NewMovement>().enabled = false;
	}

	public void CloseCharInfo(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		charProfile.SetActive (false);
		cameraPrefab.GetComponent<cameraFollow>().enabled = true;
		playerPrefab.GetComponent<NewMovement>().enabled = true;
	}
}
