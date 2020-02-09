using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	public Transform spawnPoint;

	public GameObject broken;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;

	int n;

	void OnTriggerEnter(){
		n = Random.Range (0, 10);
		print (n);

		GameObject.Instantiate (broken, transform.position, Quaternion.identity);
		Destroy (gameObject);

		if(n <= 3){
			Instantiate (spawn1, spawnPoint.position, Quaternion.identity);
		}
		if(n <= 6 && n >= 4){
			Instantiate (spawn2, spawnPoint.position, Quaternion.identity);
		}
		if(n <= 10 && n >= 7){
			Instantiate (spawn3, spawnPoint.position, Quaternion.identity);
		}

	}


}
