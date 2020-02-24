using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
	public string itemName = "Unique_ItemName";
	public int id;//unique id // represent pickup-able items place in array
	public Sprite itemUISprite;
	public GameObject particleEffect;
	public GameObject InvManager;
	// private toolbarScript toolbar;

	void Start(){
        //Change item tag to Respawn to detect when we look at it
        gameObject.tag = "Respawn";
    }

    public void OnTriggerEnter()
    {
		Vector3 pos = gameObject.transform.position;
       
		// toolbar.pickupItem(id);
		InvManager.GetComponent<ItemManager>().pickupItem(id);
		Destroy(gameObject);
		GameObject replacement = Instantiate(particleEffect,pos,Quaternion.identity);
	}
}
