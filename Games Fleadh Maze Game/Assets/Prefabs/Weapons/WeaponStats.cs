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
	public void Update(){
		strenght = PlayerStats.Strenght;
		WeaponDMG = strenght + baseDMG;

		dmg = WeaponDMG;

	}
	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponent<EnemyHealth> ().TakeDamage (WeaponDMG);
	}
}
