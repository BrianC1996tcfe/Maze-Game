using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {
	public GameObject floor;
	public GameObject colorfloor;
	public GameObject Room;
	public GameObject startTile;
	public GameObject wall;
	//public GameObject north, south, east, west;
	public Vector2 size;
	private int tilesize = 50;//,stack=0;
	//private ArrayList stackList= new ArrayList();
	private Stack<Vector2> mazeBlock = new Stack<Vector2>();

	//array will match floor prefabs// [x/50,z/50]
	public bool[,] partofmaze;
	private int cellsUsed,tempcount=0;

	// Use this for initialization
	void Start () {
		//int x =size.x as int;
		partofmaze = new bool[(int)size.x+1,(int)size.y+1];
		Debug.Log("T "+size.x+" "+size.y+" "+size);
		setBoolsTrue();
		placePrefab();
		playerTile();
		Debug.Log("19");
		placeRed();
		makeFloor();
		walls1();
	}
	private void walls1(){
		
		for(int i = 1; i<size.x;i++){
				for(int e=0;e<size.y;e++){
					if(partofmaze[i,e]){
						Vector3 posD = new Vector3(i*tilesize-25f,0,e*tilesize);
						GameObject wallz = Instantiate(wall,posD,Quaternion.identity);
						wallz.name="WallX "+(i-1)+"-"+e;
						wallz.transform.parent = transform;
					}
				}
		}
			for(int i = 0; i<size.y-1;i++){
				for(int e=0;e<size.x;e++){
					if(partofmaze[e,i]){
						Vector3 posD = new Vector3(e*tilesize,0,i*tilesize+25f);
						GameObject wallz = Instantiate(wall,posD,Quaternion.Euler(0,90,0));
						wallz.name="WallZ "+i+"-"+e;
						wallz.transform.parent = transform;
						
					}
				}
		}

	//This Gets 46 for some odd reason

		// cellsUsed=0;
		// for(int i=0;i<partofmaze.GetLength(0);i++){
		// 	for(int a=0;a<partofmaze.GetLength(1);a++){
		// 		if(!(partofmaze[i,a])){
		// 			cellsUsed++;
		// 		}
		// 	}
		// }
		cellsUsed=14;
		Debug.Log("USED "+cellsUsed+"USED "+((int)size.x*(int)size.y)+"USED "+partofmaze.GetLength(0)+"USED "+partofmaze.GetLength(1));
		mazeBlock.Push(new Vector2(0,0));
		partofmaze[0,0]=false;
		pathTemp(mazeBlock.Peek(),0);
		cellsUsed++;
		Debug.Log("Hug "+cellsUsed);
		//for(int i=cellsUsed;cellsUsed<((int)size.x*(int)size.y);){
		while(cellsUsed<(size.x*size.y)){
			pathfinder();
			//pathfinder();
		}

	}
	private void pathfinder(){
		Debug.Log("ketchup");
			//List<int> neighbor = new List<int>();
			//Vector2[] neighbour;
			int neighbourCount=0;
			bool north=false,south=false,east=false,west=false;
			//0-north 1-east 2-south 3-west
			//check if north is Usable
			if(mazeBlock.Peek().y > 0 && (partofmaze[(int)mazeBlock.Peek().x, (int)mazeBlock.Peek().y - 1])){
				north=true;
				neighbourCount++;
				
			}
			//check if east is usable
			if(mazeBlock.Peek().x < size.x && ((partofmaze[(int)mazeBlock.Peek().x + 1, (int)mazeBlock.Peek().y]))){
				east=true;
				neighbourCount++;
			}
			//check if south is usable
			if(mazeBlock.Peek().y < size.y && ((partofmaze[(int)mazeBlock.Peek().x, (int)mazeBlock.Peek().y + 1]))){
				south=true;
				neighbourCount++;
			}
			//check if west is usable
			if(mazeBlock.Peek().x > 0 && ((partofmaze[(int)mazeBlock.Peek().x - 1, (int)mazeBlock.Peek().y]))){
				west=true;
				neighbourCount++;
			}
			Debug.Log("north "+ neighbourCount);
			int[] neighbour = new int[neighbourCount];
			//add to array
				int nC=0;
				if(north){
					neighbour[nC]=0;
					nC++;
				}
				if(east){
					neighbour[nC]=1;
					nC++;
				}
				if(south){
					neighbour[nC]=2;
					nC++;
				}
				if(west){
					neighbour[nC]=3;
					nC++;
				}
				Debug.Log("north "+ nC);
			if(!(neighbourCount==0)){
				int rand = Random.Range(0,neighbourCount);
				int nextDirection = neighbour[rand];
				switch(nextDirection){
					case 0:
						Vector2 p = new Vector2(mazeBlock.Peek().x,mazeBlock.Peek().y-1);
						pathTemp(p,0);
						partofmaze[(int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y-1]=false;
						mazeBlock.Push(p);
						break;
					case 1:
						Vector2 a = new Vector2(mazeBlock.Peek().x+1,mazeBlock.Peek().y);
						pathTemp(a,1);
						partofmaze[(int)mazeBlock.Peek().x+1,(int)mazeBlock.Peek().y]=false;
						mazeBlock.Push(a);
						break;
					case 2:
						Vector2 e = new Vector2(mazeBlock.Peek().x,mazeBlock.Peek().y+1);
						pathTemp(e,2);
						partofmaze[(int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y+1]=false;
						mazeBlock.Push(e);
						break;
					case 3:
						Vector2 k = new Vector2(mazeBlock.Peek().x-1,mazeBlock.Peek().y);
						pathTemp(k,3);
						partofmaze[(int)mazeBlock.Peek().x-1,(int)mazeBlock.Peek().y]=false;
						mazeBlock.Push(k);
						break;
				}
				cellsUsed++;
			}
			else{
				mazeBlock.Pop();
			}
			Debug.Log("squash "+ (cellsUsed/(size.x*size.y)));
			// if((cellsUsed<(size.x*size.y))){
			// pathfinder();
			// }
	}
	private void pathTemp(Vector2 p,int i){
		tempcount++;
		//Vector3 wzpos = new Vector3(p.x*tilesize,0,p.y*tilesize);
		if(i==0){
			string destro ="WallX "+p.x+"-"+p.y;
			Destroy(GameObject.Find(destro));
			Debug.Log(destro);
		}
		if(i==1){
			string destro ="WallZ "+p.x+"-"+p.y;
			Destroy(GameObject.Find(destro));
			Debug.Log(destro);
		}
		if(i==2){
			string destro ="WallX "+p.x+"-"+p.y;
			Destroy(GameObject.Find(destro));
			Debug.Log(destro);
		}
		if(i==3){
			string destro ="WallZ "+p.x+"-"+p.y;
			Destroy(GameObject.Find(destro));
			Debug.Log(destro);
		}
		
	}
		
	private void placePrefab(){
		RoomPrefab_Boss room1 =  Room.GetComponent<RoomPrefab_Boss>();
		Vector2[] newpos =  new Vector2[room1.tilepos.Length];
		int maxX = (int)size.x - (int)room1.rangeX.x;
		int maxZ = (int)size.y - (int)room1.rangeZ.x;
		int minX = 0-(int)room1.rangeX.y;
		int minZ =	0-(int)room1.rangeZ.y;
		int xr = Random.Range(minX, maxX);
		int	zr = Random.Range(minZ, maxZ);
		Debug.Log("T sizex "+size.x+" sizey "+size.y+" minX "+minX+" maxX "+maxX+" minZ "+minZ+" maxZ "+maxZ+" xrand "+xr+"  zrand "+zr);
		for(int i=0;i<room1.tilepos.Length;i++){
			//Debug.Log("WIK "+newpos[i]);
			newpos[i].x = (int)room1.tilepos[i].x + xr;
			newpos[i].y = (int)room1.tilepos[i].y + zr;
			Debug.Log("WIK "+i+" "+newpos[i]+" "+room1.tilepos[i]+" "+room1.tilepos.Length);
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
