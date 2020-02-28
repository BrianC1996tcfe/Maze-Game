using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_DoorTrigger : MonoBehaviour {

	public GameObject textForDoor;
	
	private void OnTriggerEnter()
	{
		textForDoor.SetActive (true);
	}
	private void OnTriggerExit()
	{
		textForDoor.SetActive (false);
	}
}
