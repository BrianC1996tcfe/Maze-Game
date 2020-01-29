using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour {

	public GameObject moveDoor;
	public GameObject movePressurePlate;
	private Vector3 DoorStartPos,DoorPosNow;
	private bool OnPressurePlate,timerGo;
	private float timeLeft;

	void Start()
	{
		timerGo = false;
		OnPressurePlate = false;
		timeLeft = 5;
        Vector3 position = moveDoor.transform.position;
        DoorStartPos = position;
		DoorPosNow = position;
		//Debug.Log("WEE "+DoorStartPos);
	}
	void Update()
	{
		if(!OnPressurePlate && timerGo)
		{
			if(timeLeft>0)
			{
				timeLeft -= Time.deltaTime;
				Debug.Log("Timer "+ timeLeft + timerGo);
			}
			if( timeLeft <= 0 && (!(DoorPosNow.y >= DoorStartPos.y)))
			{
				//timerGo = false;
				DoorPosNow.y = DoorPosNow.y + 0.1f;
				moveDoor.transform.position = DoorPosNow;
				//Debug.Log("WNN "+ DoorPosNow);
				//Debug.Log("Timer "+ timeLeft);
			}
			else if(timeLeft <= 0)
			{
				timerGo = false;
			}
		}
	}
	private void OnTriggerStay()
	{
		if(DoorPosNow.y >= -41){
		DoorPosNow.y = DoorPosNow.y - 0.1f;
		//Debug.Log("WAA "+ DoorPosNow);
		//moveDoor.transform.position += moveDoor.transform.forward * Time.deltaTime*5;
		moveDoor.transform.position = DoorPosNow;
		}
	}
	private void OnTriggerEnter()
	{
		OnPressurePlate = true;
		timeLeft = 5;
		movePressurePlate.transform.position = new Vector3 (250, -0.5f, 280);
	}
	private void OnTriggerExit()
	{
		timerGo = true;
		OnPressurePlate=false;
		movePressurePlate.transform.position = new Vector3 (250, 0, 280);
	}
}
