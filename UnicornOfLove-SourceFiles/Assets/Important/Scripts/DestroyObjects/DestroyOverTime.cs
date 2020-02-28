using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	float interval = 5f;


	void OnCollisionEnter(){
		Destroy(gameObject,interval);
	}

}
