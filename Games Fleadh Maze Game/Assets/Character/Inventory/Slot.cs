using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public GameObject Item;
	public bool empty;
	public int ID;
	public string Type;
	public string Description;
	public Sprite Icon;

	public void UpdateSlot(){

		this.GetComponent<>.sprite = Icon;
	}
}
