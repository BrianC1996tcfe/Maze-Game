using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	public Button play;
	public Button scoreboard;
	public Button exit;

	public void Start(){
		Button btnPlay = play.GetComponent<Button> ();
		btnPlay.onClick.AddListener(PlayBtnOnClick);

		Button btnScore = scoreboard.GetComponent<Button> ();
		btnScore.onClick.AddListener(ScoreBtnOnClick);

		Button btnExit = exit.GetComponent<Button> ();
		btnExit.onClick.AddListener(ExitBtnOnClick);
	}

	public void PlayBtnOnClick(){
		SceneManager.LoadScene ("Maze");
	}

	public void ScoreBtnOnClick(){
		SceneManager.LoadScene ("ScoreBoard");
	}

	public void ExitBtnOnClick(){
		Application.Quit ();
	}
}
