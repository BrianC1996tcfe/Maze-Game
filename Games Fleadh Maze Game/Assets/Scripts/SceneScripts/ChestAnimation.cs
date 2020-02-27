using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour {
	public GameObject InteractionText;
	private Animator anim;
	private bool coolBool;
	public GameObject loot;
	public GameObject trigger;
	void Start () {
		coolBool = false;
		anim = GetComponent<Animator>();
	}
	void Update () {
		if(InteractionText.activeSelf){
			if(Input.GetKeyDown(KeyCode.E)){
				// if(coolBool){
				// 	coolBool = false;
				// }
				// else{
					coolBool = true;
				// }
				anim.SetBool("open",coolBool);
				killChestFunctionality();
				StartCoroutine(lootsplosion());
			}
		}
	}
	public IEnumerator lootsplosion(){
		yield return new WaitForSeconds(1.5f);
		Vector3 lootPos = this.gameObject.transform.position;
		Quaternion lootrot = this.gameObject.transform.rotation;
		GameObject lootSpawn = Instantiate(loot,lootPos,lootrot);
	}
	public void killChestFunctionality(){
		trigger.SetActive(false);
		InteractionText.SetActive(false);
	}
}
