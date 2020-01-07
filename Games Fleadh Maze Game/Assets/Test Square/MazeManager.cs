using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public MazeBoss mazePrefab;
    private MazeBoss mazeInstance;
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
        mazeInstance = Instantiate(mazePrefab) as MazeBoss;
        //StartCoroutine(mazeInstance.Generate());
        mazeInstance.Generate();
    }
    private void RestartGame() {
        //StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
