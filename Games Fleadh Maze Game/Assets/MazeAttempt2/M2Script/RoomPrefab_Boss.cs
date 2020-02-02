using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefab_Boss : MonoBehaviour {
	//length of vector2 array tilepos
	//11 values but starts at 0
	public int tilenum = 10;
	//a value for each x and z position of a square tile int the prefab
	//divide all values by int tilesize in floorGenerator script//<<--done already in this script
	public Vector2[] tilepos = {new Vector2(0,0),new Vector2(1,0),new Vector2(-1,0),new Vector2(1,1),new Vector2(-1,1)
								,new Vector2(0,1),new Vector2(1,2),new Vector2(-1,2),new Vector2(0,2),new Vector2(0,-1),new Vector2(0,-2)};
	//range of x
	//divide all values by int tilesize in floorGenerator script//<<--done already in this script
	public Vector2 rangeZ = new Vector2(2,-2);
	//range of Z
	//divide all values by int tilesize in floorGenerator script//<<--done already in this script
	public Vector2 rangeX = new Vector2(1,-1);
}
