using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalToNewScene : MonoBehaviour {

public int SceneNum;

private void OnTriggerEnter ()
{
	SceneManager.LoadScene(SceneNum);
}
}
