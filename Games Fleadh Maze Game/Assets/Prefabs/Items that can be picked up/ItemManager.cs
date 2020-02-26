using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
	public GameObject H_PotionSlot,S_PotionSlot,KeySlot;
	public GameObject H_PotionNum,S_PotionNum,KeyNum;
	public GameObject player;
	public Sprite H_PotionSprite,H_PotionSpriteGrey,S_PotionSprite,S_PotionSpriteGrey,KeySprite,KeySpriteGrey;
	public int startH_PotionNum,startS_PotionNum, maxH_potion, maxS_potion;
	private static int H_potion,S_potion,Key;
	public GameObject[] UsableItems;
	private bool pickup = false;
	private int ID;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		H_potion = startH_PotionNum;
		S_potion = startS_PotionNum;
		Key = 0;
		updateNumberAndSprite();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && H_potion >= 1){
			H_potion--;
			player.gameObject.GetComponent<PlayerHealth> ().UsePotion (10);
			updateNumberAndSprite();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && S_potion >= 1){
			S_potion--;
			player.gameObject.GetComponent<StaminaSystem> ().UseStaminaPotion (10);
			updateNumberAndSprite();
		}
		if(pickup==true){
			Debug.Log("oooooo");
			
			switch(ID){
			case 0:
				H_potion++;
				Debug.Log("64 "+H_potion);
				break;
			case 1:
				S_potion++;
				Debug.Log("68 "+S_potion);
				break;
			case 2:
				Key++;
				Debug.Log("72 "+Key);
				break;
			}
			
			pickup=false;
			updateNumberAndSprite();
		}
	}
	public void updateNumberAndSprite(){
		Debug.Log("35 "+H_potion + " / " + S_potion + " /  "+Key);
		H_PotionNum.GetComponent<Text>().text = H_potion + " / " + maxH_potion;
		S_PotionNum.GetComponent<Text>().text = S_potion + " / " + maxS_potion;
		KeyNum.GetComponent<Text>().text = Key + " / ?" ;
		if(H_potion<= 0){
			H_potion=0;
			H_PotionSlot.GetComponent<Image>().sprite = H_PotionSpriteGrey;
		}
		else{
			H_PotionSlot.GetComponent<Image>().sprite = H_PotionSprite;
		}
		if(S_potion <= 0){
			S_potion=0;
			S_PotionSlot.GetComponent<Image>().sprite = S_PotionSpriteGrey;
		}
		else{
			S_PotionSlot.GetComponent<Image>().sprite = S_PotionSprite;
		}
		if(Key <= 0){
			Key=0;
			KeySlot.GetComponent<Image>().sprite = KeySpriteGrey;
		}
		else{
			KeySlot.GetComponent<Image>().sprite = KeySprite;
		}
	}
	public void pickupItem(int id){
		// switch(id){
		// 	case 0:
		// 		H_potion++;
		// 		Debug.Log("64 "+H_potion);
		// 		break;
		// 	case 1:
		// 		S_potion++;
		// 		Debug.Log("68 "+S_potion);
		// 		break;
		// 	case 2:
		// 		Key++;
		// 		Debug.Log("72 "+Key);
		// 		break;
		// }
		ID = id;
		Debug.Log("75");
		pickup=true;
		Debug.Log("77");
	}
}
