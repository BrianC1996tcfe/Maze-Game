using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBoss : MonoBehaviour
{
    public MazeFloorCell cellPrefab;
   private MazeFloorCell[,] cells;
   //public float generationStepDelay;
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
    }
    private void CreateCell(IntVector2 coordinates){
        MazeFloorCell newCell = Instantiate(cellPrefab) as MazeFloorCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = 
            new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
    }
    // private void CreateWallz(int i){
    //     MazeFloorCell newWall = Instantiate(cellPrefab) as MazeFloorCell;
    //     //cells[0, i] = newWall;
    //     //newWall.coordinates = new IntVector2(0,i);
    //     newWall.name = "Maze Outer Wall " + 0 + ", " + i;
    //     newWall.transform.parent = transform;
    //     newWall.transform.localRotation =
    //             Quaternion.Euler(90,90,0);
    //     newWall.transform.localPosition = 
    //         new Vector3(size.z * 0.5f, 0.5f,i - size.z * 0.5f + 0.5f);
              
    //     MazeFloorCell newWall2 = Instantiate(cellPrefab) as MazeFloorCell;
    //    // cells[i, 0] = newWall2;
    //     //newWall2.coordinates = new IntVector2(i,0);
    //     newWall2.name = "Mazex reeOuter Wall2 " + 0 + ", " + i;
    //     newWall2.transform.parent = transform;
    //     newWall2.transform.localRotation =
    //             Quaternion.Euler(90,270,0);
    //     newWall2.transform.localPosition = 
    //         new Vector3(size.z * 0.5f, 0.5f,i - size.z * 0.5f + 0.5f);
    //     //opposite side   
    //     MazeFloorCell newWallOpposite = Instantiate(cellPrefab) as MazeFloorCell;
    //     //cells[i, 0] = newWallOpposite;
    //     //newWallOpposite.coordinates = new IntVector2(10,0);
    //     newWallOpposite.name = "Maze12 Outer Opposite Wall " + size.z + ", " + i;
    //     newWallOpposite.transform.parent = transform;
    //     newWallOpposite.transform.localRotation =
    //             Quaternion.Euler(90,90,0);
    //             //here
    //     newWallOpposite.transform.localPosition = 
    //         new Vector3(size.z*-0.5f, 0.5f,i - size.z * 0.5f + 0.5f);

    //     MazeFloorCell newWallOpposite2 = Instantiate(cellPrefab) as MazeFloorCell;
    //    // cells[i, 0] = newWallOpposite2;
    //     //newWallOpposite2.coordinates = new IntVector2(10,0);
    //     newWallOpposite2.name = "Maze Outer Opposite Wall2 " + size.z + ", " + i;
    //     newWallOpposite2.transform.parent = transform;
    //     newWallOpposite2.transform.localRotation =
    //             Quaternion.Euler(90,270,0);
    //     newWallOpposite2.transform.localPosition = 
    //         new Vector3(size.z*-0.5f, 0.5f,i - size.z * 0.5f + 0.5f);

    // }
    // private void CreateWallX(int i){
    //     MazeFloorCell newWall = Instantiate(cellPrefab) as MazeFloorCell;
    //     //cells[i, 0] = newWall;
    //     //newWall.coordinates = new IntVector2(i,0);
    //     newWall.name = "Maze Outer Wall " + i + ", " + 0;
    //     newWall.transform.parent = transform;
    //     newWall.transform.localRotation =
    //             Quaternion.Euler(90,180,0);
    //     newWall.transform.localPosition = 
    //         new Vector3(i - size.x * 0.5f + 0.5f, 0.5f,size.x * 0.5f);
              
    //     MazeFloorCell newWall2 = Instantiate(cellPrefab) as MazeFloorCell;
    //     //cells[i, 0] = newWall2;
    //    // newWall2.coordinates = new IntVector2(i,0);
    //     newWall2.name = "Maze Outer Wall2 " + i + ", " + 0;
    //     newWall2.transform.parent = transform;
    //     newWall2.transform.localRotation =
    //             Quaternion.Euler(90,0,0);
    //     newWall2.transform.localPosition = 
    //         new Vector3(i - size.x * 0.5f + 0.5f, 0.5f,size.x * 0.5f);
    //     //opposite side   
    //     MazeFloorCell newWallOpposite = Instantiate(cellPrefab) as MazeFloorCell;
    //    // cells[i, 0] = newWallOpposite;
    //    // newWallOpposite.coordinates = new IntVector2(10,0);
    //     newWallOpposite.name = "Maze Outer Opposite Wall " + i + ", " + size.x;
    //     newWallOpposite.transform.parent = transform;
    //     newWallOpposite.transform.localRotation =
    //             Quaternion.Euler(90,180,0);
    //     newWallOpposite.transform.localPosition = 
    //         new Vector3(i - size.x * 0.5f + 0.5f, 0.5f,size.z*-0.5f);

    //     MazeFloorCell newWallOpposite2 = Instantiate(cellPrefab) as MazeFloorCell;
    //     //cells[i, 0] = newWallOpposite2;
    //    // newWallOpposite2.coordinates = new IntVector2(10,0);
    //     newWallOpposite2.name = "Maze Outer Opposite Wall2 " + i + ", " + size.x;
    //     newWallOpposite2.transform.parent = transform;
    //     newWallOpposite2.transform.localRotation =
    //             Quaternion.Euler(90,0,0);
    //     newWallOpposite2.transform.localPosition = 
    //         new Vector3(i - size.x * 0.5f + 0.5f, 0.5f,size.z*-0.5f);
    // }
}