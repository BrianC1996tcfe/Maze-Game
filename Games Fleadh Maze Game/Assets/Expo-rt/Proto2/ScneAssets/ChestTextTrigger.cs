using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTextTrigger : MonoBehaviour {

	public GameObject textForChest;
	
	private void OnTriggerEnter()
	{
		textForChest.SetActive (true);
	}
	private void OnTriggerExit()
	{
		textForChest.SetActive (false);
	}
}
