using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	float interval = 10f;


	void OnTriggerEnter(){
		Destroy(gameObject,interval);
	}

}
