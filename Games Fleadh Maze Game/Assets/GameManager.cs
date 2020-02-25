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
		NextLevel();
		}
		if (Input.GetKeyDown(KeyCode.K)){
		BacktoFirstLevel();
		}
	}
		
	public void NextLevel(){
		Destroy(GameObject.FindWithTag("Maze"));
		// Maze.GetComponent<s
		// // int a = Maze.GetComponent<FloorGenerator>().enemyLevel;
		// FloorGenerator fg = Maze.GetComponent<FloorGenerator>();
		// int b = a.enemyLevel;
		fl4Gen.enemyLevel++;
		fl4Gen.size.x++;
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
		player.transform.position = PlayerStartPos;
		camerar.transform.position = CStartPos;
	}
}
