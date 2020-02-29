using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
	public int id;//unique id
	public GameObject particleEffect;
	public GameObject InvManager;

	public AudioClip pickup;
	public AudioSource audioSrc;

	void Start(){
		audioSrc = this.GetComponent<AudioSource>();
		InvManager = GameObject.FindGameObjectWithTag("InvMan");
	}
    public void OnTriggerEnter(Collider collision)
    {
		// Debug.Log("item20");
		if(collision.gameObject.tag=="Player"){
			audioSrc.PlayOneShot (pickup);
			// Debug.Log("item22");
			Vector3 pos = this.gameObject.transform.position;
			InvManager.GetComponent<ItemManager>().pickupItem(id);
			Destroy(this.gameObject);
			GameObject replacement = Instantiate(particleEffect,pos,Quaternion.identity);
		}
	}
}
