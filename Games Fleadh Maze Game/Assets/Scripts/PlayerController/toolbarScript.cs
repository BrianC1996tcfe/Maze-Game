using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolbarScript : MonoBehaviour {
public GameObject[] toolbarSlots;
public GameObject[] greyUIPart;
public GameObject[] ImageItem;
public GameObject[] ItemDescriptionslist;
public GameObject[] pickup_Items;
private bool[] checker;
	void Start () {
		checker = new bool[toolbarSlots.Length];
		boolfalsify();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			// Debug.Log("WAN-WAN-1-1-1");
			//  toolSlotClick(0);
			//  greyUIPart[0].SetActive(true);
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
	void boolfalsify(){
		for(int i=0;i<=checker.Length;i++){
			checker[i] = false;
		}
	}
	// IEnumerator toolSlotClick(int i){
	// 	greyUIPart[i].SetActive(false);
	// 	yield return new WaitForSeconds(.5f);
	// 	// greyUIPart[i].SetActive(true);
	// }
	public void pickupItem(int id){
		for(int e=0;e<=checker.Length;e++){
			Debug.Log("WAN "+e+" "+checker[e]);
			if(checker[e]==false){
				checker[e]=true;
				Debug.Log("MYRe");
				string nameItem = pickup_Items[id].GetComponent<Item>().itemName;
				ItemDescriptionslist[e].GetComponent<Text>().text = nameItem;
				ImageItem[e].GetComponent<Image>().sprite = pickup_Items[id].GetComponent<Item>().itemUISprite;
				
			}
		}
		
	}
}
