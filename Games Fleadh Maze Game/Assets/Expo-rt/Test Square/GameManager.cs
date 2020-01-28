using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MazeGenerate mazePrefab;
    private MazeGenerate mazeInstance;
    void Start()
    {
        BeginGame();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            RestartGame();
        }
    }
    private void BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as MazeGenerate;
        //StartCoroutine(mazeInstance.Generate());
        mazeInstance.Generate();
    }
    private void RestartGame() {
       // StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
