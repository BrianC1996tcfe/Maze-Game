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
}
