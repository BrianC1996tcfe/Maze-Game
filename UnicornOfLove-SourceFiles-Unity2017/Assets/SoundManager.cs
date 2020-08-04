using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip step,attack,chestOpen;

	public AudioSource audioSrc;
	
	void Step(){
		audioSrc.PlayOneShot (step);
	}
	void Attack(){
		audioSrc.PlayOneShot (attack);
	}
	void OpenChest(){
		audioSrc.PlayOneShot (chestOpen);
	}
}
