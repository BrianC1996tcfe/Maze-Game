using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	public Button play;

	public void Start(){
		Button btnPlay = play.GetComponent<Button> ();
		btnPlay.onClick.AddListener(PlayBtnOnClick);
	}

	public void PlayBtnOnClick(){
		SceneManager.LoadScene ("M2");
	}
}
