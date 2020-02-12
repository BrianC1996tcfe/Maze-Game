using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public GameObject playerPrefab;
	public GameObject CameraPrefab;
    public GameObject ItemButton;
	public GameObject InventoryCanvas;
	public Button InvClosebutton;
	public GameObject[] Items;
	private int slotAmount = 25;
	// private int row = 5;
	// private int column = 5;
	// private int spacing = 100;
	//private bool invActive=false;
	// Use this for initialization
	// Update is called once per frame
	void Start(){
		//invActive=InventoryCanvas.SetActive;
		// Cursor.visible=true;
		// //Disables camera movement script 
		// CameraPrefab.GetComponent<cameraFollow>().enabled = false;
		// //Disables player movement script 
		// playerPrefab.GetComponent<NewMovement>().enabled = false;
		//MakeButtonRows();void Start () {
		Button btn = InvClosebutton.GetComponent<Button>();
		btn.onClick.AddListener(CloseInventory);
	}
	public void CloseInventory () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible=false;
		InventoryCanvas.SetActive(false);
		CameraPrefab.GetComponent<cameraFollow>().enabled = true;
		playerPrefab.GetComponent<NewMovement>().enabled = true;
	}	
	public void OpenInventory () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible=true;
		InventoryCanvas.SetActive(true);
		CameraPrefab.GetComponent<cameraFollow>().enabled = false;
		playerPrefab.GetComponent<NewMovement>().enabled = false;
	}	
	void Update () {
		// if(InventoryCanvas.activeSelf){
			//Cursor.visible=true;
		// }
		
		if (Input.GetKeyDown(KeyCode.I))
        {
			switch(InventoryCanvas.activeSelf){
				case true:
					CloseInventory ();
				break;
				case false:
					OpenInventory ();
				break;
			}
		}
	}
	// public void MakeButtonRows(){
	// 	for(int e=0-6;e<=row-7;e++){
	// 		for(int i = 3;i <= column+2;i++ ){
	// 			Vector3 buttonPos = new Vector3(i*spacing,(e*spacing)-50,0);
	// 			//Vector3 buttonPos = new Vector3(0,0,0);
	// 			Vector3 buttonScale = new Vector3(1,1,1);
	// 			// float x = InventoryCanvas.transform.position.x;
	// 			// float y = InventoryCanvas.transform.position.y;
	// 			// float z = InventoryCanvas.transform.position.z;
	// 			// Debug.Log("Bong >"+x+" "+y+" "+z);
	// 			// float y2 = y+(y/2);
	// 			// Vector3 buttonPos = new Vector3(y2*2,z,0);
	// 			GameObject Slot = Instantiate(ItemButton,buttonPos,Quaternion.identity);
	// 			// Slot.transform.parent = transform;
	// 			// Slot.transform.localScale = buttonScale;
	// 			Slot.transform.SetParent(InventoryCanvas.transform);
	// 			Slot.transform.localScale = buttonScale;
	// 			Slot.transform.localPosition = buttonPos;
	// 			// Slot.transform.localRotation = spawnRotation;
	// 		}
	// 	}
	// }
}
