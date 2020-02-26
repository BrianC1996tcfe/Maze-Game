using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorSCript : MonoBehaviour {
	public Animator animt;
	// Use this for initialization
	void Start () {
		animt= this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O)){
			animt.SetBool("openDoor", true);
		}
	}
}
