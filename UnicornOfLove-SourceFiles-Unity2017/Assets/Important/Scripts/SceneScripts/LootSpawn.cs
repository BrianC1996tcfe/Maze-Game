using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawn : MonoBehaviour {
	public GameObject[] loot;
	public int[] lootSpawnRate;
	public int minloot,maxloot;
	public float thrust = 1.0f;
	void Start () {
		StartCoroutine(spawntheloot());
	}
	
	// Update is called once per frame
	void Update () {
		// if(Input.GetKeyDown(KeyCode.T)){
		// 	// spawntheloot();
		// 	 StartCoroutine(spawntheloot());
		// }
	}
	public IEnumerator spawntheloot(){
		int randlootnum = Random.Range(minloot,maxloot);
		Vector3 SpawnPos = this.gameObject.transform.position;
		for(int i = 0; i <= randlootnum; i++){
			int randloot = Random.Range(0,loot.Length);
			Quaternion randrot = Random.rotation;
			GameObject newloot = Instantiate(loot[randloot],SpawnPos,randrot);
			Rigidbody lootbody = newloot.GetComponent<Rigidbody>();
			lootbody.AddForce(transform.up * thrust,ForceMode.Impulse);
			yield return new WaitForSeconds(0.3f);
		 	lootbody.AddForce(transform.forward * (thrust/3),ForceMode.Impulse);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
