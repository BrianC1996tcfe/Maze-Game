using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {
	public GameObject floor;
	public GameObject colorfloor;
	public GameObject Room;
	public GameObject startTile;
	public Vector2 size;
	private int tilesize = 50;

	//array will match floor prefabs, use to make
	public bool[,] partofmaze;

	// Use this for initialization
	void Start () {
		//int x =size.x as int;
		partofmaze = new bool[(int)size.x,(int)size.y];
		Debug.Log("T "+size.x+" "+size.y+" "+size);
		setBoolsTrue();
		placePrefab();
		playerTile();
		Debug.Log("19");
		placeRed();
		makeFloor();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void placePrefab(){
		
		RoomPrefab_Boss room1 =  Room.GetComponent<RoomPrefab_Boss>();
		///int numtile = room1.tilenum;
		///keep extra value incase the new room is outside the maze
		//Vector2[] prefabpos = room1.tilepos;
		// Vector2[] newpos =  room1.tilepos;
		Vector2[] newpos =  new Vector2[room1.tilepos.Length];
		int maxX = (int)size.x - (int)room1.rangeX.x;
		int maxZ = (int)size.y - (int)room1.rangeZ.x;
		int minX = 0-(int)room1.rangeX.y;
		int minZ =	0-(int)room1.rangeZ.y;
		// int bigX=0;
		// int smallZ=(int)size.y;
		// int tempX;
		// int tempZ;
		int xr = Random.Range(minX, maxX);
		int	zr = Random.Range(minZ, maxZ);
		Debug.Log("T sizex "+size.x+" sizey "+size.y+" minX "+minX+" maxX "+maxX+" minZ "+minZ+" maxZ "+maxZ+" xrand "+xr+"  zrand "+zr);
		for(int i=0;i<room1.tilepos.Length;i++){
			//Debug.Log("WIK "+newpos[i]);
			newpos[i].x = (int)room1.tilepos[i].x + xr;
			newpos[i].y = (int)room1.tilepos[i].y + zr;
			Debug.Log("WIK "+i+" "+newpos[i]+" "+room1.tilepos[i]+" "+room1.tilepos.Length);
			// tempX=(int)newpos[i].x;
			// tempZ=(int)newpos[i].y;
			// if(tempX>bigX){
			// 	bigX=tempX;
			// }
			// if(tempZ<smallZ){
			// 	smallZ=tempZ;
			// }
			//Debug.Log("WIK "+newpos[i]);
			partofmaze[(int)newpos[i].x,(int)newpos[i].y]=false;
		}
		Vector3 Rpos = new Vector3(xr*tilesize,0,zr*tilesize);
		GameObject prefabRoom = Instantiate(Room,Rpos,Quaternion.identity);

	}
	private void playerTile(){
		Vector3 startpos = new Vector3(0,0,-50);
		GameObject playerStart = Instantiate(startTile,startpos,Quaternion.Euler(0,180,0));
	}
	private void placeRed(){
		for(int i=0;i<=2;i++){
			int x=Random.Range(0,(int)size.x),z=Random.Range(0,(int)size.y);
			while(partofmaze[x,z]==false){
				x=Random.Range(0,(int)size.x);
				z=Random.Range(0,(int)size.y);
			}
			Vector3 redpos = new Vector3(x*tilesize,0,z*tilesize);
			GameObject RedFloor = Instantiate(colorfloor,redpos,Quaternion.identity);
			partofmaze[x,z]=false;
			Debug.Log("maze "+partofmaze[x,z]);
		}
	}
	private void makeFloor(){
		for(int i=0;i<size.x;i++){
			for(int e=0;e<size.y;e++){
				if(partofmaze[i,e]==true){
					Vector3 zpos = new Vector3(i*tilesize,0,e*tilesize);
					GameObject madeFloor = Instantiate(floor,zpos,Quaternion.identity);
					madeFloor.name = "Floor "+zpos.x+" "+zpos.z+" no Color";
					madeFloor.transform.parent = transform;
				}
			}
		}

	}
	private void setBoolsTrue(){
		//Debug.Log("45");
	 	for (int row = 0; row < size.x; row++) {
			 //Debug.Log("47");
    		for (int col = 0; col <size.y; col++) {
				//Debug.Log("49");
       			partofmaze[row,col]=true;
				//Debug.Log("BoolCOOL "+row+" "+col+" "+partofmaze[row,col]);   
    		}
 		}
	}
}
