using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour {
	public GameObject InteractionText;
	private Animator anim;
	private bool coolBool;
	void Start () {
		coolBool = false;
		anim = GetComponent<Animator>();
	}
	void Update () {
		//if(InteractionText.activeSelf){
			if(InteractionText.activeSelf && Input.GetKeyDown(KeyCode.E)){
				if(coolBool){
					coolBool = false;
				}
				else{
					coolBool = true;
				}
				anim.SetBool("open",coolBool);
			}
		}
	//}
}
