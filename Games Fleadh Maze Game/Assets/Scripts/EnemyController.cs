using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
    static Animator anim;
    

    // Update is called once per frame

    void Start(){
        anim = GetComponent<Animator>();
    }
    void Update () {
		if(Vector3.Distance(player.position, this.transform.position) < 17){
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 3f * Time.deltaTime);

            anim.SetBool("isIdle", false);

			if(direction.magnitude > 7){
				this.transform.Translate (0,0,0.2f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
			}
            else {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
		}
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
	}
}
