using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour {

	public float inputZ;
	public float inputX;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationspeed;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;
	private float verticalVel;
	private Vector3 moveVector;

	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
	}

	void Update () {
		InputMagnitude ();

		isGrounded = controller.isGrounded;
		if (isGrounded) {
			verticalVel -= 0;
		} else {
			verticalVel -= 2;
		}
		moveVector = new Vector3 (0, verticalVel, 0);
		controller.Move (moveVector);

		QuickAttack ();
		HeavyAttack ();

	}

	public void QuickAttack(){

		if (Input.GetButtonDown ("Fire1")) {
			//anim.SetTrigger ("isAttacking");
			anim.SetBool ("Attack", true);
			anim.SetBool ("Movement", false);
			//anim.SetBool ("AttackHeavy", false);
		} else {
			//anim.SetBool ("AttackHeavy", false);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Movement", true);
		}
	}

	public void HeavyAttack(){
		if (Input.GetButtonDown ("Fire2")) {
			anim.SetBool ("AttackHeavy", true);
			//anim.SetBool ("Attack", false);
			anim.SetBool ("Movement", false);
		} else {
			anim.SetBool ("AttackHeavy", false);
			//anim.SetBool ("Attack", false);
			anim.SetBool ("Movement", true);
		}
	}

	void PlayerMoveAndRotation(){
		inputX = Input.GetAxis ("Horizontal");
		inputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * inputZ + right * inputX;

		controller.Move (desiredMoveDirection * Time.deltaTime * 7f);

		if(blockRotationPlayer == false){
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationspeed);
		}
	}

	void InputMagnitude(){
		inputX = Input.GetAxis ("Horizontal");
		inputZ = Input.GetAxis ("Vertical");

		anim.SetFloat ("InputZ", inputZ, 0.0f, Time.deltaTime * 2f);
		anim.SetFloat ("InputX", inputX, 0.0f, Time.deltaTime * 2f);

		Speed = new Vector2 (inputX, inputZ).sqrMagnitude;

		if(Speed > allowPlayerRotation){
			anim.SetFloat ("InputMagnitude", Speed, 0.0f, Time.deltaTime);
			PlayerMoveAndRotation ();
		}
		else if(Speed < allowPlayerRotation){
			anim.SetFloat ("InputMagnitude", Speed, 0.0f, Time.deltaTime);
		}
	}
}
