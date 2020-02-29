using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_DoorTrigger : MonoBehaviour {

	public GameObject textForDoor;
	
	private void OnTriggerEnter()
	{
		// int check = ItemManager.Key;
		if(ItemManager.Key == 0){
			textForDoor.GetComponent<TextMesh>().text = "You need a key to open this door.";
			GameObject.FindGameObjectWithTag ("Door").GetComponent<BossDoorSCript>().doorBool = false;
		}
		else{
			textForDoor.GetComponent<TextMesh>().text = "[E] Use Key to Open Door.";
			GameObject.FindGameObjectWithTag ("Door").GetComponent<BossDoorSCript>().doorBool = true;
		}
		textForDoor.SetActive (true);
	}
	private void OnTriggerExit()
	{
		textForDoor.SetActive (false);
	}
}
