using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {
	public GameObject floor;
	public GameObject LootRoom;
	public GameObject BossRoom;
	public GameObject SewerRoom;
	public GameObject startTile,endTile;
	public GameObject wall,column;
	public GameObject TextCheck;
	public GameObject sewerpath, sewerConnectMid;
	public GameObject[] Enemies;
	public Vector2 size;
	private int tilesize = 25;//,stack=0;

	//private ArrayList stackList= new ArrayList();
	private Stack<Vector2> mazeBlock = new Stack<Vector2>();

	//array will match floor prefabs// [x/50,z/50]
	public bool[,] partofmaze;
	//match walls in zigzag eg. every second one is are the walls along x-axis
	public bool[,] partofWallX;
	public bool[,] partofWallZ;
	private int cellsUsed,tempcount=0;
	public int enemyLevel;

	// Use this for initialization
	void Start () {
		//int x =size.x as int;
		partofmaze = new bool[(int)size.x+1,(int)size.y+1];
		// Debug.Log("1USED "+partofmaze.GetLength(0)+"USED "+partofmaze.GetLength(1));
		partofWallX = new bool[(int)size.y+1,(int)size.x+1];
		// Debug.Log("2xUSED "+partofWallX.GetLength(0)+"USED "+partofWallX.GetLength(1));
		partofWallZ = new bool[(int)size.x,(int)size.y+1];
		// Debug.Log("2zUSED "+partofWallZ.GetLength(0)+"USED "+partofWallZ.GetLength(1));
		// Debug.Log("T "+size.x+" "+size.y+" "+size);
		cellsUsed=0;
		setBoolsTrue();
		if(!(size.y<10 || size.x<10)){
			placeBossRoomPrefab();
			placeSewerRoomPrefab();
		}
		
		playerTile();
		endtile();
		// Debug.Log("19");
		int chestnum = Mathf.RoundToInt((size.x*size.y)/50);
		if(!(chestnum==0)){
			placeChests(chestnum);
		}
		makeFloor();
		pathfinder();
		makewalls();
		corners();
	}
	private void corners(){
		//creates row along x-axis
		for(int i = 0; i<=size.x;i++){
				for(int e=0;e<=size.y;e++){
					// if(partofWallX[e,i]){
					// Debug.Log("e, "+e+" i, "+i);
					Vector3 posC = new Vector3((i*tilesize)-(tilesize/2),0,(e*tilesize)-(tilesize/2));
					GameObject colum = Instantiate(column,posC,Quaternion.identity);
					colum.transform.parent = transform;
					// }	
				}
		}
	}
		
	private void makewalls(){
		//creates row along x-axis
		for(int i = 0; i<=size.x;i++){
				for(int e=0;e<size.y;e++){
					if(partofWallX[e,i]){
						// Debug.Log("e, "+e+" i, "+i);
						Vector3 posD = new Vector3((i*tilesize)-(tilesize/2),0,e*tilesize);
						GameObject wallx = Instantiate(wall,posD,Quaternion.identity);
						wallx.name="Wall X-axis row,  x-"+i+", z-"+e;
						wallx.transform.parent = transform;
					// 	Vector3 posC = new Vector3((i*tilesize)-(tilesize/2),0,(e*tilesize)-(tilesize/2));
					// GameObject colum = Instantiate(column,posC,Quaternion.identity);
					// colum.transform.parent = transform;
					}
					
				}
		}
		//creates rows along z-axis
			for(int i = 0; i<=size.y;i++){
				for(int e=0;e<size.x;e++){
					if(partofWallZ[e,i]){
						// Debug.Log(" i, "+i+" e, "+e);
						Vector3 posD = new Vector3(e*tilesize,0,(i*tilesize)-(tilesize/2));
						GameObject wallz = Instantiate(wall,posD,Quaternion.Euler(0,90,0));
						wallz.name="Wall Z-axis row, x-"+e+" ,z-"+i;
						wallz.transform.parent = transform;
					// 	Vector3 posC = new Vector3((e*tilesize)-(tilesize/2),0,(i*tilesize)-(tilesize/2));
					// GameObject colum = Instantiate(column,posC,Quaternion.identity);
						// 
					}
				}
		}
	}
	private void pathfinder(){
		//This Gets 46 for some odd reason

		//cellsUsed=0;
		//Debug.Log("**USED "+cellsUsed+"USED "+(partofmaze.GetLength(0)*partofmaze.GetLength(1))+"USED "+partofmaze.GetLength(0)+"USED "+partofmaze.GetLength(1));
		for(int i=0;i<size.x;i++){
			for(int ae=0;ae<size.y;ae++){
				//Debug.Log("WhatNow "+i+" "+ae+" "+partofmaze[i,ae]);
				//}
				if(!(partofmaze[i,ae])){
					cellsUsed++;
					//Debug.Log("KUMinPant "+i+" "+ae+" "+partofmaze[i,ae]);
				}
			}
		}
		//--temporary until i can calculate it correctly--
		//cellsUsed=0;
		// cellsUsed=14;
		//Debug.Log("-*-*-USED "+cellsUsed+"USED "+((int)size.x*(int)size.y)+"USED "+partofmaze.GetLength(0)+"USED "+partofmaze.GetLength(1));
		mazeBlock.Push(new Vector2(0,0));
		// GameObject numText = Instantiate(TextCheck,new Vector3(0,1,0),Quaternion.Euler(90,90,0));	
		// numText.name="numtext 0";
		// numText.GetComponent<TextMesh>().text="R";

		partofmaze[0,0]=false;
		// pathTemp(mazeBlock.Peek(),0);
		cellsUsed++;
		// Debug.Log("Hug "+cellsUsed);
		//for(int i=cellsUsed;cellsUsed<((int)size.x*(int)size.y);){
		while(cellsUsed<(size.x*size.y)){	
			// Debug.Log("ketchup");
				//List<int> neighbor = new List<int>();
				//Vector2[] neighbour;
				int neighbourCount=0;
				bool north=false,south=false,east=false,west=false;
				//0-north 1-east 2-south 3-west
				//check if north is Usable
				if(mazeBlock.Peek().y > 0 && (partofmaze[(int)mazeBlock.Peek().x, (int)mazeBlock.Peek().y - 1])){
					//north=true;
					south=true;
					neighbourCount++;
					// Debug.Log("Is South? x-"+mazeBlock.Peek().x+" z-"+mazeBlock.Peek().y);
					
				}
				//check if east is usable
				if(mazeBlock.Peek().x < size.x && ((partofmaze[(int)mazeBlock.Peek().x + 1, (int)mazeBlock.Peek().y]))){
					east=true;
					neighbourCount++;
					// Debug.Log("Is East? x-"+mazeBlock.Peek().x+" z-"+mazeBlock.Peek().y);
				}
				//check if south is usable
				if(mazeBlock.Peek().y < size.y && ((partofmaze[(int)mazeBlock.Peek().x, (int)mazeBlock.Peek().y + 1]))){
					north=true;
					//south=true;
					neighbourCount++;
					// Debug.Log("Is North? x-"+mazeBlock.Peek().x+" z-"+mazeBlock.Peek().y);
				}
				//check if west is usable
				if(mazeBlock.Peek().x > 0 && ((partofmaze[(int)mazeBlock.Peek().x - 1, (int)mazeBlock.Peek().y]))){
					west=true;
					neighbourCount++;
					// Debug.Log("Is West? x-"+mazeBlock.Peek().x+" z-"+mazeBlock.Peek().y);
					
				}
				// Debug.Log("Path Try- "+tempcount+" Neighbours "+ neighbourCount);
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
					// Debug.Log("north "+ nC);
				if(!(neighbourCount==0)){
					int rand = Random.Range(0,neighbourCount);
					int nextDirection = neighbour[rand];
					//0-north 1-east 2-south 3-west
					switch(nextDirection){
						case 0:
							Vector2 p = new Vector2(mazeBlock.Peek().x,mazeBlock.Peek().y+1);
							//pathTemp(p,0);
							partofmaze[(int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y+1]=false;
							wallBoolRemove((int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y,"north");
							// Debug.Log("North "+tempcount+", Between x-"+mazeBlock.Peek().x+", z-"+mazeBlock.Peek().y+" and x-"+mazeBlock.Peek().x+", z-"+(mazeBlock.Peek().y+1));
							mazeBlock.Push(p);
							tempcount++;
							// GameObject numText2 = Instantiate(TextCheck,new Vector3(p.x*tilesize,1,p.y*tilesize),Quaternion.Euler(90,90,0));	
							// 	numText2.name="numtext "+tempcount.ToString();
							// 	numText2.GetComponent<TextMesh>().text=""+tempcount.ToString();
							break;
						case 1:
							Vector2 a = new Vector2(mazeBlock.Peek().x+1,mazeBlock.Peek().y);
							//pathTemp(a,1);
							partofmaze[(int)mazeBlock.Peek().x+1,(int)mazeBlock.Peek().y]=false;
							wallBoolRemove((int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y,"east");
							// Debug.Log("East "+tempcount+", Between x-"+(mazeBlock.Peek().x+", z-"+mazeBlock.Peek().y+" and x-"+(mazeBlock.Peek().x+1)+", z-"+mazeBlock.Peek().y));
							mazeBlock.Push(a);
							tempcount++;
							// GameObject numText3 = Instantiate(TextCheck,new Vector3(a.x*tilesize,1,a.y*tilesize),Quaternion.Euler(90,90,0));	
							// 	numText3.name="numtext "+tempcount.ToString();
							// 	numText3.GetComponent<TextMesh>().text=""+tempcount.ToString();
							break;
						case 2:
							Vector2 e = new Vector2(mazeBlock.Peek().x,mazeBlock.Peek().y-1);
							//pathTemp(e,2);
							partofmaze[(int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y-1]=false;
							wallBoolRemove((int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y,"south");
							// Debug.Log("South "+tempcount+", Between x-"+mazeBlock.Peek().x+", z-"+mazeBlock.Peek().y+" and x-"+mazeBlock.Peek().x+", z-"+(mazeBlock.Peek().y-1));
							mazeBlock.Push(e);
							tempcount++;
							// GameObject numText4 = Instantiate(TextCheck,new Vector3(e.x*tilesize,1,e.y*tilesize),Quaternion.Euler(90,90,0));	
							// 	numText4.name="numtext "+tempcount.ToString();
							// 	numText4.GetComponent<TextMesh>().text=""+tempcount.ToString();
							break;
						case 3:
							Vector2 k = new Vector2(mazeBlock.Peek().x-1,mazeBlock.Peek().y);
							//pathTemp(k,3);
							partofmaze[(int)mazeBlock.Peek().x-1,(int)mazeBlock.Peek().y]=false;
							wallBoolRemove((int)mazeBlock.Peek().x,(int)mazeBlock.Peek().y,"west");
							// Debug.Log("west "+tempcount+", Between x-"+mazeBlock.Peek().x+", z-"+mazeBlock.Peek().y+" and x-"+(mazeBlock.Peek().x-1)+", z-"+mazeBlock.Peek().y);
							mazeBlock.Push(k);
							tempcount++;
							// GameObject numText5 = Instantiate(TextCheck,new Vector3(k.x*tilesize,1,k.y*tilesize),Quaternion.Euler(90,90,0));	
							// 	numText5.name="numtext "+tempcount.ToString();
							// 	numText5.GetComponent<TextMesh>().text=""+tempcount.ToString();
							break;
					}
					cellsUsed++;
				}
				else{
					mazeBlock.Pop();
				}
				// Debug.Log("squash "+ cellsUsed+" "+(size.x*size.y));
				// if((cellsUsed<(size.x*size.y))){
				// pathfinder();
				// }
		}
		// Debug.Log("Finito c "+cellsUsed+" t "+tempcount);
	}
		private void wallBoolRemove(int x,int z, string direction){
			switch(direction){
				case "north":
					// wallx-axisrow //north
					//partofWallX[z,x+1]=false;
					partofWallZ[x,z+1]=false;
				break;
				case "south":
					//wallx-axisrow //south
					//partofWallX[z,x]=false;
					partofWallZ[x,z]=false;
				break;
				case "east":
					// wallz-axisrow //west-left//workin
					//partofWallZ[x,z+1]=false;
					partofWallX[z,x+1]=false;
				break;
				case "west":
					//wallzx-axisrow //east-right//workin
					//partofWallZ[x,z]=false;
					partofWallX[z,x]=false;
				break;
				case "all":
					// wallx-axisrow //north
					partofWallX[z,x+1]=false;
					//wallx-axisrow //south
					partofWallX[z,x]=false;
					// wallz-axisrow //west-left//workin
					partofWallZ[x,z+1]=false;
					//wallzx-axisrow //east-right//workin
					partofWallZ[x,z]=false;	
				break;
			}
	}
		
	private void placeBossRoomPrefab(){
		RoomPrefab_Boss room1 =  BossRoom.GetComponent<RoomPrefab_Boss>();
		Vector2[] newpos =  new Vector2[room1.tilepos.Length];
		int maxX = (int)size.x - (int)room1.rangeX.x;
		int maxZ = (int)size.y - (int)room1.rangeZ.x;
		int minX = 0-(int)room1.rangeX.y;
		int minZ =	0-(int)room1.rangeZ.y;
		int xr = Random.Range(minX, maxX);
		int	zr = Random.Range(minZ, maxZ);
		// Debug.Log("T sizex "+size.x+" sizey "+size.y+" minX "+minX+" maxX "+maxX+" minZ "+minZ+" maxZ "+maxZ+" xrand "+xr+"  zrand "+zr);
		for(int i=0;i<room1.tilepos.Length;i++){
			//Debug.Log("WIK "+newpos[i]);
			newpos[i].x = (int)room1.tilepos[i].x + xr;
			newpos[i].y = (int)room1.tilepos[i].y + zr;
			// Debug.Log("WIK "+i+" "+newpos[i]+" "+room1.tilepos[i]+" "+room1.tilepos.Length);
			partofmaze[(int)newpos[i].x,(int)newpos[i].y]=false;
			wallBoolRemove((int)newpos[i].x,(int)newpos[i].y,"all");
		}
		Vector3 Rpos = new Vector3(xr*tilesize,0,zr*tilesize);
		GameObject prefabRoom = Instantiate(BossRoom,Rpos,Quaternion.identity);
		if(room1.sewerConnected==true){
			Vector3 Spos = new Vector3((room1.sewerPoint.x+xr)*tilesize,tilesize/2,(room1.sewerPoint.y+zr)*tilesize);
			GameObject SewerEntrance = Instantiate(sewerConnectMid,Spos,Quaternion.identity);
		}
	}
	private void placeSewerRoomPrefab(){
		RoomPrefab_SewerEntrance room2 =  SewerRoom.GetComponent<RoomPrefab_SewerEntrance>();
		Vector2[] newpos =  new Vector2[room2.tilepos.Length];
		int maxX = (int)size.x - (int)room2.rangeX.x;
		int maxZ = (int)size.y - (int)room2.rangeZ.x;
		int minX = 0-(int)room2.rangeX.y;
		int minZ =	0-(int)room2.rangeZ.y;
		int xr = Random.Range(minX, maxX);
		int	zr = Random.Range(minZ, maxZ);
		 Debug.Log("Checknumbers : [sizex- "+size.x+" sizey- "+size.y+"] [minX- "+minX+" maxX- "+maxX+"] [minZ- "+minZ+" maxZ- "+maxZ+"] [xrand- "+xr+"  zrand- "+zr+"]");
		for(int i=0;i<room2.tilepos.Length;i++){
			Debug.Log("Check V2-"+room2.tilepos[i]+" /"+xr+" , "+zr);
			newpos[i].x = (int)room2.tilepos[i].x + xr;
			newpos[i].y = (int)room2.tilepos[i].y + zr;
			 Debug.Log("Co-ordinate "+i+" (x-"+(int)newpos[i].x+" z-"+(int)newpos[i].y+") Length: "+room2.tilepos.Length);
			partofmaze[(int)newpos[i].x,(int)newpos[i].y]=false;
			wallBoolRemove((int)newpos[i].x,(int)newpos[i].y,"all");
			GameObject numText2 = Instantiate(TextCheck,new Vector3(newpos[i].x*tilesize,1,newpos[i].y*tilesize),Quaternion.Euler(90,90,0));	
								numText2.name="numtext "+i.ToString();
								numText2.GetComponent<TextMesh>().text=""+i.ToString();
		}
		Vector3 Rpos = new Vector3(xr*tilesize,0,zr*tilesize);
		GameObject prefabRoom = Instantiate(SewerRoom,Rpos,Quaternion.identity);
		if(room2.sewerConnected==true){
			Vector3 Spos = new Vector3((room2.sewerPoint.x+xr)*tilesize,tilesize/2,(room2.sewerPoint.y+zr)*tilesize);
			GameObject SewerEntrance = Instantiate(sewerConnectMid,Spos,Quaternion.identity);
		}
	}
	private void playerTile(){
		// Vector3 startpos = new Vector3(0,0,-tilesize);
		// GameObject playerStart = Instantiate(startTile,startpos,Quaternion.Euler(0,180,0));
		wallBoolRemove(0,0,"south");
	}
	private void endtile(){
		Vector3 endpos = new Vector3(size.x*tilesize,0,(size.y-1)*tilesize);
		GameObject playerend = Instantiate(endTile,endpos,Quaternion.Euler(0,90,0));
		wallBoolRemove((int)size.x-1,(int)size.y-1,"east");
	}
	private void placeChests(int spawnNum){
		for(int i=0;i<spawnNum;i++){
			int x=Random.Range(0,(int)size.x-1),z=Random.Range(0,(int)size.y);
			//stop from placing on top of something else
			//**fix it so that it can't be placed between **
			while(partofmaze[x,z]==false || (x==0 && z==0) || (x==(int)size.x-1 && z==(int)size.y-1 || ( !partofmaze[x+1,z] && !partofmaze[x,z-1] && !partofmaze[x-1,z] && !partofmaze[x,z+1]))){
				x=Random.Range(0,(int)size.x);
				z=Random.Range(0,(int)size.y);
			}
			//https://answers.unity.com/questions/452983/how-to-exclude-int-values-from-randomrange.html
			//wont rotate to outside
			int[] ValDir;
			if(z==0 && x==(int)size.x-1){
				ValDir=new int[]{2,3};
				
			}
			else if(z==0){
				ValDir=new int[]{0,2,3};
			}
			else if(x==(int)size.x-1){
				ValDir=new int[]{1,2,3};
				Debug.Log("TOOT");
				
			}
			else if(x==0 && z==(int)size.y-1 ){
				ValDir=new int[]{0,1};
				
			}
			else if(x==0){
				ValDir=new int[]{0,1,3};
			}
			else if(z==(int)size.y-1){
				ValDir=new int[]{0,1,2};
				Debug.Log("TOOTTjooj");
			}
			else{
				ValDir=new int[]{0,1,2,3};
			}
			int mandy = ValDir[Random.Range(0,ValDir.Length)];
			prefabrotationcheck(mandy,x,z,ValDir);
			// 
			int rotato = 90*mandy;
			// int rotato=90*0;
			//int rotato=90*2;
			Vector3 redpos = new Vector3(x*tilesize,0,z*tilesize);
			GameObject RedFloor = Instantiate(LootRoom,redpos,Quaternion.Euler(0,rotato,0));
			partofmaze[x,z]=false;
			wallBoolRemove(x,z,"all");
		}
	}
	public void prefabrotationcheck(int mandy,int x,int z,int[] ValDir){
		switch(mandy){
				case 0:
					if(!partofmaze[x+1,z]){
						while(mandy==0){
							mandy = ValDir[Random.Range(0,ValDir.Length)];
						}
					}
				break;
				case 1:
					if(!partofmaze[x,z-1]){
						while(mandy==1){
							mandy = ValDir[Random.Range(0,ValDir.Length)];
						}
					}
				break;
				case 2:
					if(!partofmaze[x-1,z]){
						while(mandy==2){
							mandy = ValDir[Random.Range(0,ValDir.Length)];
						}
					}
				break;
				case 3:
					if(!partofmaze[x,z+1]){
						while(mandy==3){
							mandy = ValDir[Random.Range(0,ValDir.Length)];
						}
					}
				break;
			}
	}

	private void makeFloor(){
		for(int i=0;i<size.x;i++){
			for(int e=0;e<size.y;e++){
				if(partofmaze[i,e]==true){
					int rondam = Random.Range(0,3);
					int rotato = 90*rondam;
					Vector3 zpos = new Vector3(i*tilesize,0,e*tilesize);
					GameObject madeFloor = Instantiate(floor,zpos,Quaternion.Euler(0,rotato,0));
					madeFloor.name = "FloorTile, x-"+i+", z-"+e;
					madeFloor.transform.parent = transform;
					//Make Enemy Spawn
					int randEnemy = Random.Range(-15,Enemies.Length);
					if(randEnemy<0){
						// nothing here as this is the case where no enemy spawns
					}
					else{
						GameObject newEnemy = Instantiate(Enemies[randEnemy],zpos,Quaternion.Euler(0,rotato,0));
						// newEnemy.GetComponent<EnemyManager>.setLevel(enemyLevel);
					}
				}
			}
		}

	}
	private void setBoolsTrue(){
		//Debug.Log("45");
	 	for (int row = 0; row < size.x; row++) {
			 //Debug.Log("47");
    		for (int col = 0; col < size.y; col++) {
				//Debug.Log("49");
       			partofmaze[row,col]=true;
				//    partofWallZ[row,col]=true;
				// Debug.Log("BoolCOOL "+row+" "+col+" "+partofmaze[row,col]+" "+partofmaze.GetLength(0)+" "+partofmaze.GetLength(1));
    		}
 		}
		 for (int row = 0; row < size.x; row++) {
			 //Debug.Log("47");
    		for (int col = 0; col <= size.y; col++) {
				//Debug.Log("49");
				partofWallZ[row,col]=true;
				// Debug.Log("BoolCOOLz "+row+" "+col+" "+partofWallZ[row,col]+" "+partofWallZ.GetLength(0)+" "+partofWallZ.GetLength(1));   
    		}
		 }
		 for (int row = 0; row <= size.y; row++) {
			 //Debug.Log("47");
    		for (int col = 0; col <=size.x; col++) {
				//Debug.Log("49");
       			partofWallX[row,col]=true;
				// Debug.Log("BoolCOOLx "+row+" "+col+" "+partofWallX[row,col]+" "+partofWallX.GetLength(0)+" "+partofWallX.GetLength(1));   
    		}
 		}
	}
}
