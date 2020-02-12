using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryClose : MonoBehaviour {
 public GameObject InventoryMenu;
 public Button Invbutton;
	void Start () {
		Button btn = Invbutton.GetComponent<Button>();
		btn.onClick.AddListener(CloseInventory);
	}
	public void CloseInventory () {
		InventoryMenu.SetActive(false);
	}
}
