using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorSCript : MonoBehaviour {
	public Animator animt;
	public GameObject doorTrigger;
	public GameObject doorTrigger_Text;
	public GameObject Inventory;
	public bool doorBool;
	// Use this for initialization
	void Start () {
		doorBool = false;
		animt= this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// if(Input.GetKeyDown(KeyCode.O)){
		// 	animt.SetBool("openDoor", true);
		// }
		if(doorTrigger_Text.activeSelf){
			if(Input.GetKeyDown(KeyCode.E)){
				// if(coolBool){
				// 	coolBool = false;
				// }
				// else{
					// coolBool = true;
				// }
				if(doorBool){
					animt.SetBool("openDoor", true);
					killDoorFunctionality();
					ItemManager.Key--;
					GameObject.FindGameObjectWithTag("InvMan").GetComponent<ItemManager>().updateNumberAndSprite();
				}
			}
		}
	}
	public void killDoorFunctionality(){
		doorTrigger.SetActive(false);
		doorTrigger_Text.SetActive(false);
	}
}
