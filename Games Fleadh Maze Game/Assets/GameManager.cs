using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
public GameObject Maze;
//keycount
//xp on death
Vector3 MazePos;

	// Use this for initialization
	void Start () {
		MazePos = Maze.transform.position;
		GameObject newMaze = Instantiate(Maze,MazePos,Quaternion.identity);
		newMaze.tag = "Maze";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
		NextLevel();
		}
	}
	public void NextLevel(){
		
		// Maze.enemylevel++;
		Destroy(GameObject.FindWithTag("Maze"));
		GameObject newMaze = Instantiate(Maze,MazePos,Quaternion.identity);
		newMaze.tag = "Maze";
		
		
	}
	//when you die
	public void BacktoFirstLevel(){

	}
}
