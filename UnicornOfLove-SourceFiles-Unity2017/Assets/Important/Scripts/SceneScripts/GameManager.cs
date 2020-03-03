using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
public GameObject Maze;
public GameObject player;
public GameObject camerar;
FloorGenerator fl4Gen;
//keycount
//xp on death
Vector3 MazePos;
Vector3 PlayerStartPos;
Vector3 CStartPos = new Vector3(1.5f,33.9f,12.5f);
Vector2 newlvlSize;



	// Use this for initialization
	void Start () {
		fl4Gen= Maze.GetComponent<FloorGenerator>();
		fl4Gen.size.x=5;
		fl4Gen.size.y=5;
		fl4Gen.enemyLevel=1;
		MazePos = Maze.transform.position;
		PlayerStartPos = player.transform.position;
		GameObject newMaze = Instantiate(Maze,MazePos,Quaternion.identity);
		newMaze.tag = "Maze";
		

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
		NextLevel(true);
		}
		if (Input.GetKeyDown(KeyCode.K)){
		BacktoFirstLevel();
		}
	}
		
	public void NextLevel(bool workingPerfectly){
		Debug.Log("44 SHID");
		// StartCoroutine(GameObject.FindGameObjectWithTag("Splash").GetComponent<SplashScreen>().levelChangeSplash());
		GameObject.FindGameObjectWithTag("Splash").GetComponent<SplashScreen>().showSplash = true;
		Destroy(GameObject.FindWithTag("Maze"));
		// Maze.GetComponent<s
		// // int a = Maze.GetComponent<FloorGenerator>().enemyLevel;
		// FloorGenerator fg = Maze.GetComponent<FloorGenerator>();
		// int b = a.enemyLevel;
		if(workingPerfectly){
			if(!(fl4Gen.enemyLevel>=5)){
				fl4Gen.enemyLevel++;
			}
		}
		switch(fl4Gen.enemyLevel){
			case 1:
				newlvlSize = new Vector2(5,5);
			break;
			case 2:
				newlvlSize = new Vector2(5,15);
			break;
			case 3:
				newlvlSize = new Vector2(10,10);
			break;
			case 4:
				newlvlSize = new Vector2(25,10);
			break;
			case 5:
				newlvlSize = new Vector2(25,15);
			break;
		}
		fl4Gen.size.x = newlvlSize.x;
		fl4Gen.size.y = newlvlSize.y;
		GameObject newMaze = Instantiate(Maze,MazePos,Quaternion.identity);
		newMaze.tag = "Maze";
		player.transform.position = PlayerStartPos;
		camerar.transform.position = CStartPos;

	}
	//when you die
	public void BacktoFirstLevel(){
		fl4Gen.size.x=5;
		fl4Gen.size.y=5;
		fl4Gen.enemyLevel=1;
		Destroy(GameObject.FindWithTag("Maze"));
		GameObject newMaze = Instantiate(Maze,MazePos,Quaternion.identity);
		newMaze.tag = "Maze";
		// player.FindWithTag("InvMan").GetComponent<ItemManager>().resetInventory();
		// player.GetComponentInChildren<ItemManager>.resetInventory();
		GameObject.FindGameObjectWithTag("InvMan").GetComponent<ItemManager>().resetInventory();
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().revive();
		player.transform.position = PlayerStartPos;
		camerar.transform.position = CStartPos;
	}
}
