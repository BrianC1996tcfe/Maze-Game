using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMovement : MonoBehaviour {
	//-----------------Movement-----------------------
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
	public GameObject swordL;
	public GameObject swordR;
	public float movementSpeed;
	public float sprintSpeed;
	public float runSpeed;

	private bool canSprint = true;

	//-----------------------------------------------
	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
		runSpeed = 10f;
		sprintSpeed = 15f;
		movementSpeed = runSpeed;

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
		Roll ();
		Sprint ();

	}
	//-----------------Sprint---------------------
	public void Sprint(){
		if (Input.GetKey (KeyCode.LeftShift) && StaminaSystem.cur_stamina >= 1f) {
			anim.SetBool ("Sprint", true);
			anim.SetBool ("Movement", false);
			movementSpeed = sprintSpeed;
			this.GetComponent<StaminaSystem> ().TakeStamina (0.5f);
		} else if (Input.GetKey (KeyCode.LeftShift) && StaminaSystem.cur_stamina <= 0f) {
			movementSpeed = runSpeed;
			anim.SetBool ("Sprint", false);
			anim.SetBool ("Movement", true);
		} else {
			movementSpeed = runSpeed;
		}
		this.GetComponent<StaminaSystem> ().RegenStamina (0.2f);
	}
	//------------------Rolling-------------------
	public void Roll(){
		if (Input.GetKey (KeyCode.LeftControl)) {
			anim.SetBool ("Roll", true);
			anim.SetBool ("Sprint", false);
			anim.SetBool ("Movement", false);
			StartCoroutine("RollTime");
			//this.GetComponent<StaminaSystem> ().TakeStamina (10f);
		} else {
			anim.SetBool ("Roll", false);
			anim.SetBool ("Sprint", false);
			anim.SetBool ("Movement", true);
		}
	}

	IEnumerator RollTime(){
		if (Input.GetKey (KeyCode.LeftShift)) {
			this.GetComponent<Collider> ().enabled = false;

			yield return new WaitForSeconds (0.8f);

			this.GetComponent<Collider> ().enabled = true;
		}
	}
	//------------------Attacking--------------------
	IEnumerator QuickAttackCollider(){
		if (Input.GetButtonDown ("Fire1")) {
			swordL.GetComponent<BoxCollider> ().enabled = true;

			yield return new WaitForSeconds (0.25f);

			swordL.GetComponent<BoxCollider> ().enabled = false;
		}
	}
	public void QuickAttack(){
		if (Input.GetButtonDown ("Fire1")) {
			StartCoroutine ("QuickAttackCollider");
			anim.SetBool ("Attack", true);
			anim.SetBool ("Movement", false);
		} else {
			anim.SetBool ("Attack", false);
			anim.SetBool ("Movement", true);
		}
	}

	IEnumerator HeavyCollider(){
		if (Input.GetButtonDown ("Fire2")) {
			swordR.GetComponent<BoxCollider> ().enabled = true;

			yield return new WaitForSeconds (0.25f);

			swordR.GetComponent<BoxCollider> ().enabled = false;
		}
	}

	public void HeavyAttack(){
		if (Input.GetButtonDown ("Fire2")) {
			StartCoroutine ("HeavyCollider");
			anim.SetBool ("AttackHeavy", true);
			anim.SetBool ("Movement", false);
		} else {
			anim.SetBool ("AttackHeavy", false);
			anim.SetBool ("Movement", true);
		}
	}
	//------------------------------------------------------------

	public void PlayerMoveAndRotation(){
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

		controller.Move (desiredMoveDirection * Time.deltaTime * movementSpeed);

		if(blockRotationPlayer == false){
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationspeed);
		}
	}

	public void IncreaseMovementSpeed(float amount){
		runSpeed += amount;
		sprintSpeed += amount;
	}

	public void InputMagnitude(){
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
