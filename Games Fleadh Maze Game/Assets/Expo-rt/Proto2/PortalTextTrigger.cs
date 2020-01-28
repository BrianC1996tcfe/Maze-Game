using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextTrigger : MonoBehaviour {
	
	public GameObject textPortal;

	private void OnTriggerEnter()
	{
		textPortal.SetActive (true);
	}
	private void OnTriggerExit()
	{
		textPortal.SetActive (false);
	}
}
