using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	// public int level;
	// public int n;
	// public float hp;
	// public int fairy;
	// public int swordskele;
	// public int throwskele;

	// private GameObject enemy;
	// Use this for initialization
	public GameObject enemy;
	public int enemyAttackType; 
	// public GameObject SlimeAttack;
	// public GameObject ThrowSkeletonAttack;
	public GameObject enemyWeapon;

	public void Start(){
		enemyWeapon = GameObject.FindGameObjectWithTag("EnemyWeapon");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	public void EnemyLevel(int level){
		Debug.Log("EnemyLevel:"+level);
		// level += n;

		switch (level) {

		case 1:
			{
				enemy.GetComponent<EnemyHealth> ().SetHealth (30);
				if(enemyAttackType==0){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 7;
				}
				else if(enemyAttackType==1){
					enemyWeapon.GetComponent<Fireball> ().dmg = 7;
				}
				else if(enemyAttackType==2){
					enemyWeapon.GetComponent<BoneScript> ().dmg = 7;
				}
				else if(enemyAttackType==3){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 7;
				}
				// enemy.GetComponent<Fireball> ().AddDamage (2);
				// enemy.GetComponent<swordDamage> ().AddDamage (2);
				// enemy.GetComponent<BoneScript> ().AddDamage (2);
				break;
			}
		case 2:
			{
				enemy.GetComponent<EnemyHealth> ().SetHealth (75);
				if(enemyAttackType==0){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 10;
				}
				else if(enemyAttackType==1){
					enemyWeapon.GetComponent<Fireball> ().dmg = 10;
				}
				else if(enemyAttackType==2){
					enemyWeapon.GetComponent<BoneScript> ().dmg = 10;
				}
				else if(enemyAttackType==3){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 10;
				}
				// enemy.GetComponent<Fireball> ().AddDamage (5);
				// enemy.GetComponent<swordDamage> ().AddDamage (5);
				// enemy.GetComponent<BoneScript> ().AddDamage (5);
				break;
			}
		case 3:
			{
				enemy.GetComponent<EnemyHealth> ().SetHealth (100);
				if(enemyAttackType==0){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 15;
				}
				else if(enemyAttackType==1){
					enemyWeapon.GetComponent<Fireball> ().dmg = 15;
				}
				else if(enemyAttackType==2){
					enemyWeapon.GetComponent<BoneScript> ().dmg = 15;
				}
				else if(enemyAttackType==3){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 15;
				}
				// enemy.GetComponent<Fireball> ().AddDamage (10);
				// enemy.GetComponent<swordDamage> ().AddDamage (10);
				// enemy.GetComponent<BoneScript> ().AddDamage (10);
				break;
			}
		case 4:
			{
				enemy.GetComponent<EnemyHealth> ().SetHealth (150);
				if(enemyAttackType==0){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 20;
				}
				else if(enemyAttackType==1){
					enemyWeapon.GetComponent<Fireball> ().dmg = 20;
				}
				else if(enemyAttackType==2){
					enemyWeapon.GetComponent<BoneScript> ().dmg = 20;
				}
				else if(enemyAttackType==3){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 20;
				}
				// enemy.GetComponent<Fireball> ().AddDamage (15);
				// enemy.GetComponent<swordDamage> ().AddDamage (15);
				// enemy.GetComponent<BoneScript> ().AddDamage (15);
				break;
				
			}
		case 5:
			{
				enemy.GetComponent<EnemyHealth> ().SetHealth (200);
				if(enemyAttackType==0){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 25;
				}
				else if(enemyAttackType==1){
					enemyWeapon.GetComponent<Fireball> ().dmg = 25;
				}
				else if(enemyAttackType==2){
					enemyWeapon.GetComponent<BoneScript> ().dmg = 25;
				}
				else if(enemyAttackType==3){
					enemyWeapon.GetComponent<swordDamage> ().dmg = 25;
				}
				// enemy.GetComponent<Fireball> ().AddDamage (21);
				// enemy.GetComponent<swordDamage> ().AddDamage (21);
				// enemy.GetComponent<BoneScript> ().AddDamage (21);
				break;
			}
		}
	}
}
