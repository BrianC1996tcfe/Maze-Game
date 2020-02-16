using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour {

	public float max_stamina = 100f;
	public float cur_stamina = 0f;
	public GameObject staminaBar;
	public Text staminaAmount;

	public Animator anim;

	void Start () {
		anim = this.GetComponent<Animator> ();
		cur_stamina = max_stamina;
		SetStaminaBar ();
	}

	public void TakeStamina(float amount){
		cur_stamina -= amount;
		SetStaminaBar ();
		if(cur_stamina <= 0){
			anim.SetBool ("Roll", false);
			anim.SetBool ("AttackHeavy", false);
		}
	}

	public void SetStaminaBar (){
		float my_stamina = cur_stamina / max_stamina;
		staminaBar.transform.localScale = new Vector3 (Mathf.Clamp(my_stamina,0f,1f),staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
		staminaAmount.text = "SP : " + cur_stamina.ToString ();
	}

}
