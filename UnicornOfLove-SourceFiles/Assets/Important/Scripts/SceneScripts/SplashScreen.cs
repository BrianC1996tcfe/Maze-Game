using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

	public GameObject title_Text;
	public GameObject main_Text;
	public GameObject interact_Text;
	public GameObject canv;
	private int Level;
	public bool canplay, showSplash, deadplayer,restart;
	void Start () {
		showSplash = false;
		canplay = false;
		deadplayer = false;
		restart = false;
		// Level = 1;
		startingSplash();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		// if(Input.GetKeyDown(KeyCode.M)){

		// }
		// if(canplay && deadplayer){
		// 	if(Input.anyKey){
		// 		canplay = false;
		// 		deadplayer = false;
		// 		showSplash = false;
		// 		canv.SetActive(false);
		// 		startingSplash();
		// 		GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().BacktoFirstLevel();
		// 		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().revive();
		// 	}
		// }
		if(canplay){
			if(Input.anyKey){
				showSplash = false;
				canv.SetActive(false);
				eraseText();
				if(restart){
					// canv.canvasRenderer.SetAlpha (1f);
					startingSplash();
					restart = false;
					// GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().BacktoFirstLevel();
				}
			}
		}
		if(showSplash){
			showSplash = false;
			// if(Input.anyKey){
				canplay = false;
				StartCoroutine(levelChangeSplash());
				canv.SetActive(true);
			// }
		}
		if(deadplayer){
			
				showSplash = false;
				
				canv.SetActive(false);
				// startingSplash();
				if(Input.anyKey){
					deadplayer = false;
					restart = true;
					eraseText();
					StartCoroutine(GameOverSplash());
					GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().BacktoFirstLevel();
					GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().revive();
				}
		}
	}
	public void startingSplash(){
		Level = 1;
		title_Text.GetComponent<Text>().text="Level "+Level;
		main_Text.GetComponent<Text>().text="Instructions + story";
		interact_Text.GetComponent<Text>().text="[Any Button] to Begin Game";
		canplay = true;
		canv.SetActive(true);
		// showSplash = true;
	}
	public void eraseText(){
		title_Text.GetComponent<Text>().text="";
		main_Text.GetComponent<Text>().text="";
		interact_Text.GetComponent<Text>().text="";
	}
	public IEnumerator levelChangeSplash(){
		Level++;
		title_Text.GetComponent<Text>().text="Level "+Level;
		main_Text.GetComponent<Text>().text="You've beaten level "+(Level-1)+" are you ready for level "+Level;
		yield return new WaitForSeconds(1.5f);
		interact_Text.GetComponent<Text>().text="[Any Button] to Play";
		canplay = true;
		// Level++;
		// showSplash = true;
	}
	public IEnumerator GameOverSplash(){
		Debug.Log("Game Over");
		// yield return new WaitForSeconds(10f);
		// canv.canvasRenderer.SetAlpha (0.0f);
		canv.SetActive(true);
		title_Text.GetComponent<Text>().text="You Have Died";
		main_Text.GetComponent<Text>().text="You made it to Level "+Level;
		yield return new WaitForSeconds(1.5f);
		interact_Text.GetComponent<Text>().text="[Any Button] to Start Again";
		canplay = true;
		// deadplayer = true;	
	}
}
