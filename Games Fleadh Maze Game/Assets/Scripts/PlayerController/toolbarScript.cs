using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolbarScript : MonoBehaviour {
public GameObject[] greyUIPart;
public GameObject[] ItemDescriptionslist;
public GameObject[] pickup_Items;
// private bool[] checker;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			greyUIPart[0].SetActive(false);
			greyUIPart[1].SetActive(true);
			greyUIPart[2].SetActive(true);
			greyUIPart[3].SetActive(true);
			// ItemDescriptionslist[0].GetComponent<Text>().text="YEP";
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			greyUIPart[0].SetActive(true);
			greyUIPart[1].SetActive(false);
			greyUIPart[2].SetActive(true);
			greyUIPart[3].SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			greyUIPart[0].SetActive(true);
			greyUIPart[1].SetActive(true);
			greyUIPart[2].SetActive(false);
			greyUIPart[3].SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			greyUIPart[0].SetActive(true);
			greyUIPart[1].SetActive(true);
			greyUIPart[2].SetActive(true);
			greyUIPart[3].SetActive (false);
		}
	}
	public void pickupItem(int id){
		Debug.Log("MYRe");
		string i = pickup_Items[id].GetComponent<Item>().itemName;
		ItemDescriptionslist[0].GetComponent<Text>().text=i;
	}
}
