using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorSCript : MonoBehaviour {
	public Animator animt;
	public GameObject doorTrigger;
	public GameObject doorTrigger_Text;
	public GameObject Inventory;
	private bool coolBool;
	// Use this for initialization
	void Start () {
		coolBool = false;
		animt= this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O)){
			animt.SetBool("openDoor", true);
		}
		if(doorTrigger_Text.activeSelf){
			if(Input.GetKeyDown(KeyCode.E)){
				// if(coolBool){
				// 	coolBool = false;
				// }
				// else{
					coolBool = true;
				// }
				animt.SetBool("openDoor", coolBool);
				killDoorFunctionality();
			}
		}
	}
	public void killDoorFunctionality(){
		doorTrigger.SetActive(false);
		doorTrigger_Text.SetActive(false);
	}
}
