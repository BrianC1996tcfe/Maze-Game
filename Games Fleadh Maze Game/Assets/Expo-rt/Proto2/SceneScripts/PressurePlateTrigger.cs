using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour {

	public GameObject moveDoor;
	public GameObject movePressurePlate;


	private void OnTriggerStay()
	{
		moveDoor.transform.position += moveDoor.transform.forward * Time.deltaTime*5;
	}
	private void OnTriggerEnter()
	{
		movePressurePlate.transform.localPosition = new Vector3 (250, -1.5f, 280);
	}
	private void OnTriggerExit()
	{
		movePressurePlate.transform.localPosition = new Vector3 (250, 0, 280);
	}
}
