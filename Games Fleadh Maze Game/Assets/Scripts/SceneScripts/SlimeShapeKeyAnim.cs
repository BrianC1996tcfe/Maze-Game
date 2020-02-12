using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShapeKeyAnim : MonoBehaviour {

	private float mSize = 0.0f, nSize = 0.0f, speed = 0.001f,speedy = 0.0001f;
	void Start () {
		InvokeRepeating("Key1Up",0.0f,speed);
	}
	void Key1Up(){
		if(mSize>=100.0f){
			CancelInvoke("Key1Up");
			InvokeRepeating("Key2Up",0.0f,speed);
		}
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize++);
	}
	void Key2Up(){
		if(nSize>=100.0f){
			CancelInvoke("Key2Up");
			InvokeRepeating("Key1Down",0.0f,speedy);
		}
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, nSize++);
	}
	// void Key2Down(){
	// 	if(nSize<=0.0f){
	// 		CancelInvoke("Key2Down");
	// 		InvokeRepeating("Key1Down",0.0f,speedy);
	// 	}
	// 	GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, nSize--);
	// }
	void Key1Down(){
		if(mSize<=0.0f){
			CancelInvoke("Key1Down");
			InvokeRepeating("Key1Up",0.0f,speed);
		}
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize--);
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, nSize--);
	}
}
