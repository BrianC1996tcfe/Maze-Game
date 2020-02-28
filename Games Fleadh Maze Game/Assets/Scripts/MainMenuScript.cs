using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public GameObject ExitMenu;
	public GameObject playerPrefab;
	public GameObject CameraPrefab;

	public Button resume;
	public Button mainMenu;
	public Button exitGame;

	public static bool gameIsPaused = false;

	public void Start(){
		playerPrefab = GameObject.FindGameObjectWithTag ("Player");
		CameraPrefab = GameObject.FindGameObjectWithTag ("CameraFollow");

		Button btnResume = resume.GetComponent<Button> ();
		btnResume.onClick.AddListener(resumeBtnOnClick);

		Button btnMainMenu = mainMenu.GetComponent<Button> ();
		btnMainMenu.onClick.AddListener(MainMenuBtnOnClick);

		Button btnExitGame = exitGame.GetComponent<Button> ();
		btnExitGame.onClick.AddListener(ExitGameBtnOnClick);

	}

	public void ExitGameBtnOnClick(){
		Application.Quit ();
	}

	public void MainMenuBtnOnClick(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void resumeBtnOnClick(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible=false;
		ExitMenu.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void CloseMenu () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible=false;
		ExitMenu.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}	
	public void OpenMenu () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible=true;
		ExitMenu.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			switch(ExitMenu.activeSelf){
			case true:
				CloseMenu ();
				break;
			case false:
				OpenMenu ();
				break;
			}
		}
	}
		
}
