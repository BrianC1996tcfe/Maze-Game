using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalToNewScene : MonoBehaviour {
public int SceneNum;

private void OnTriggerEnter ()
{
	GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().NextLevel();
	// GameObject.FindGameObjectWithTag("Splash").GetComponent<SplashScreen>().showSplash = true;
}
}
