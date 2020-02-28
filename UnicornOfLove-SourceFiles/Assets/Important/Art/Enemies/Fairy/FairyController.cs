using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{

    public Transform player;
	public Animator anim;
	public Transform firePoint;
	public GameObject fireballPrefab;
	private float shootTime = 1f;
	private float shootDelay = 1f;


    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 17)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 3f * Time.deltaTime);

            anim.SetBool("isIdle", false);

			if (direction.magnitude > 10)
            {
                this.transform.Translate(0, 0, 0.2f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
			{
				anim.SetBool("isAttacking", true);
				anim.SetBool("isWalking", false);
				InvokeRepeating ("Shoot", shootTime, shootDelay);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
	void Shoot (){
		Instantiate (fireballPrefab, firePoint.position, firePoint.rotation);
		CancelInvoke ("Shoot");
	}
}
