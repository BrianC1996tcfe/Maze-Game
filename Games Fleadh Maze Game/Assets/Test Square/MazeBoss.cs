using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBoss : MonoBehaviour
{
    public MazeFloorCell cellPrefab;
   private MazeFloorCell[,] cells;
   //public float generationStepDelay;
   public GameObject WallPrefab;
   public IntVector2 size;

     void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Generate(){
        //WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeFloorCell[size.x,size.z];
        for(int x = 0; x < size.x; x++){
            //CreateWallX(x);
            for(int z = 0; z < size.z; z++){
                //CreateWallz(z);
               // yield return delay;
                CreateCell(new IntVector2(x, z));
            }
        }
        recursionX(0,size.x,size.z);
    }
    private void CreateCell(IntVector2 coordinates){
        MazeFloorCell newCell = Instantiate(cellPrefab) as MazeFloorCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = 
            new Vector3(coordinates.x, 0f, coordinates.z);
    }
       private void recursionX(int minX, int maxX,int maxZ){
       int i=maxZ;
       while(i>0){
           i=loopy(minX,i);
       }
    }
    public int loopy(int min1,int max1){
        int randomZ = Random.Range(min1,max1);
        int randomDoorWay = Random.Range(0,size.x);
        for(int x=0;x<size.x;x++){
            if(!(x==randomDoorWay)||(max1==size.z)){
            GameObject WallX = Instantiate(WallPrefab);
            WallX.name="Maze Wall " + x + ", " + randomZ;
            WallX.transform.localPosition = new Vector3(x,0.5f,randomZ-0.5f);
            }
        }
        return randomZ;
    }
}