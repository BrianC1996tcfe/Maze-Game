using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour {

	public int baseDMG = 3;//damage of the weapon
	public int strenght;//player strenght
	private GameObject player;

	public static int WeaponDMG;
	public int dmg;

	//--------------------------------------------------
	public void start(){
		// if(this.gameObject.tag=="BluSword"){

		// }
		// else if(this.gameObject.tag=="RedSword"){

		// }
	}
	public void Update(){
		strenght = PlayerStats.Strenght;
		WeaponDMG = baseDMG +((strenght * baseDMG)/2);

		dmg = WeaponDMG;
		// Debug.Log(this.gameObject.tag+" "+dmg);
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Enemy"){
			other.gameObject.GetComponent<EnemyHealth> ().TakeDamage (WeaponDMG);
		}
	}
}
