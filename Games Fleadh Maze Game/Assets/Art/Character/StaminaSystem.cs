using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour {

	public float max_stamina = 100f;
	public static float cur_stamina = 0f;
	public GameObject staminaBar;

	public Animator anim;

	void Start () {
		anim = this.GetComponent<Animator> ();
		cur_stamina = max_stamina;
	}

	public void Update(){
		SetStaminaBar ();
		if(cur_stamina <= 0){
			cur_stamina = 0;
		}

	}

	public void UseStaminaPotion(float amount){
		cur_stamina += amount;
		if(cur_stamina >= max_stamina){
			cur_stamina = max_stamina;
		}
	}

	public void RegenStamina(float amount){
		if (cur_stamina <= 100f) {
			cur_stamina += amount;
		} else {
			return;
		}

	}

	public void TakeStamina(float amount){
		cur_stamina -= amount;
	}

	public void SetStaminaBar (){
		float my_stamina = cur_stamina / max_stamina;
		staminaBar.transform.localScale = new Vector3 (Mathf.Clamp(my_stamina,0f,1f),staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
	}

}
