using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridFloorGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] quads;
    public Material redMaterial,blueMaterial;
    //private Vector3 cornerClose;
    //private Vector3 cornerOpposite;
    //private Vector3[] Rooms;


    // all atributes of a 'room' 2 sets of points for corners, depth-how many subdivision it took to make this room, divisible-will change manually to 1 if divisible and 0 if not
   //private int[] Xpoint1,Zpoint1,Xpoint2,Zpoint2,divisible;
   
   //every 5 places in array define a room eg. x1,z1,x2,z2,Divisibility
    // private ArrayList roomAttributes =new ArrayList();
    //private ArrayList<ArrayList<int>>

    [Range(5,25)]
    public int sizeX = 5,sizeZ = 5;
    void Start()
    {
       // MakeRoom(0,0,0,sizeX,sizeZ);
        InstantiateFloorQuads();
        Debug.Log("heloo");
       // mazeWallGenerator();
    }
    //every 5 things are a room
    // void MakeRoom(int roomNum,int x1,int z1,int x2,int z2){
    //     Xpoint1[roomNum]=x1;
    //     Zpoint1[roomNum]=z1;
    //     Xpoint2[roomNum]=x2;
    //     Zpoint2[roomNum]=z2;
    //     // roomAttributes.Add(x1);
    //     //  roomAttributes.Add(z1);
    //     //   roomAttributes.Add(x2);
    //     //    roomAttributes.Add(z2);
    //     if(x1 == x2 || z1 == z2){
    //         divisible[roomNum]=0;
    //         // roomAttributes.Add(0);
    //     }
    //     else{
    //         divisible[roomNum]=1;
    //          //roomAttributes.Add(1);
    //     }
    // }
    // void mazeWallGenerator(){
    //     for(int i=0;i<=5;i++){
    //         //if(i==0){
    //             MakeRoom(i,0,0,sizeX,sizeZ);
    //        // }

    //    int rand = Random.Range(1,3);
    //    if(rand==1){
    //          splitAcrossX(new Vector3((float)Xpoint1[i],0,(float)Zpoint1[i]),new Vector3((float)Xpoint2[i*5],0,(float)Zpoint2[i*5]));
    //     }
    //     else{
    //         splitAcrossZ(new Vector3((float)Xpoint1[i],0,(float)Zpoint1[i]),new Vector3((float)Xpoint2[i],0,(float)Zpoint2[i*5]));
    //   }
    //    }
    // }
    void splitAcrossX(Vector3 CornerPoint, Vector3 CornerPointOpposite){
            //int split = Random.Range(0,sizeZ);
            //int entrypoint = Random.Range(0,sizeX);
            int split = Random.Range((int)CornerPoint.z,(int)CornerPointOpposite.z);
             Debug.Log("OVER_HERE_z "+split);
            int entrypoint = Random.Range((int)CornerPoint.x,(int)CornerPointOpposite.x);
            //int endwall=0;
            for(int i=(int)CornerPoint.x;i<=(int)CornerPointOpposite.x;i++){
                Debug.Log("OVER_HERE_x "+i);
                if(!(i==entrypoint)){
                var splitWall = Instantiate(
                    quads[2],
                    transform.position + new Vector3(i,0.5f,split+0.5f),     
                    Quaternion.Euler(0,180,0));
                splitWall.transform.parent=gameObject.transform;
                var splitWall2 = Instantiate(
                    quads[2],
                    transform.position + new Vector3(i,0.5f,split+0.5f),     
                    Quaternion.Euler(0,0,0));
                splitWall2.transform.parent=gameObject.transform;
                }
                //endwall=i;
            }   
            
       // Rooms[1]=new Vector3(endwall,0,split);
        // Debug.Log("OVER_HERE "+Rooms[1]);
        //Rooms[counter,2]=new Vector3(0,0,0);
        
    }
    void splitAcrossZ(Vector3 CornerPoint, Vector3 CornerPointOpposite){
        Debug.Log("poopy");
        int split= Random.Range((int)CornerPoint.x,(int)CornerPointOpposite.x);
        int entrypoint = Random.Range((int)CornerPoint.z,(int)CornerPointOpposite.z);
        for(int i=(int)CornerPoint.z;i<=(int)CornerPointOpposite.z;i++){
            if(!(i==entrypoint)){
            var splitWallz = Instantiate(
                quads[2],
                transform.position + new Vector3(split+0.5f,0.5f,i),     
                Quaternion.Euler(0,90,0));
            splitWallz.transform.parent=gameObject.transform;
            var splitWallz2 = Instantiate(
                quads[2],
                transform.position + new Vector3(split+0.5f,0.5f,i),   
                Quaternion.Euler(0,-90,0));
            splitWallz2.transform.parent=gameObject.transform;
            }
        }
    }
    void InstantiateFloorQuads(){
        //Loop makes a row of quad-rows along z-axis
        for(int z=0; z<=sizeZ;z++){
            makewallsAlongZ(z);
            //Loop makes a row of quads along x-axis
            for(int x=0; x<=sizeX;x++){
                //if statement used to make checkered pattern(%-symbol means 'remainder of')
                makewallsAlongX(x);
                int a = 0 ;
                if((z+x)%2==0){a=1;}
                var floorCell =Instantiate(
                    quads[a],
                    transform.position + new Vector3(x,0,z),     
                    Quaternion.Euler(90,0,0));
                floorCell.transform.parent=gameObject.transform;
            }
        }
    }
    void makewallsAlongZ(int i){
        //quads are 1-sided so instantiate for both sides of wall
            var wallZ = Instantiate(
                quads[0],
                transform.position + new Vector3(-0.5f,0.5f,i),     
                Quaternion.Euler(0,-90,0));
            wallZ.transform.parent=gameObject.transform;
            var wallZ2 = Instantiate(
                quads[0],
                transform.position + new Vector3(-0.5f,0.5f,i), 
                Quaternion.Euler(0,90,0));
            wallZ2.transform.parent=gameObject.transform;
        //opposite walls
            var wallZ3 = Instantiate(
                quads[0],
                transform.position + new Vector3(sizeX+0.5f,0.5f,i),     
                Quaternion.Euler(0,-90,0));
            wallZ3.transform.parent=gameObject.transform;
            var wallZ4 = Instantiate(
                quads[0],
                transform.position + new Vector3(sizeX+0.5f,0.5f,i), 
                Quaternion.Euler(0,90,0));
            wallZ4.transform.parent=gameObject.transform;
    }
    void makewallsAlongX(int i){
        //quads are 1-sided so instantiate for both sides of wall
           var wallX = Instantiate(
                quads[0],
                transform.position + new Vector3(i,0.5f,-0.5f),     
                Quaternion.Euler(0,180,0));
            wallX.transform.parent=gameObject.transform;
            var wallX2 = Instantiate(
                quads[0],
                transform.position + new Vector3(i,0.5f,-0.5f),    
                Quaternion.Euler(0,0,0));
            wallX2.transform.parent=gameObject.transform;
        //opposite wallssizeZ+0.5f
            var wallX3 = Instantiate(
                quads[0],
                transform.position + new Vector3(i,0.5f,sizeZ+0.5f),    
                Quaternion.Euler(0,180,0));
            wallX3.transform.parent=gameObject.transform;
            var wallX4 = Instantiate(
                quads[0],
                transform.position + new Vector3(i,0.5f,sizeZ+0.5f), 
                Quaternion.Euler(0,0,0));
            wallX4.transform.parent=gameObject.transform;
    }
   void Update()
    {
        
    }
}
