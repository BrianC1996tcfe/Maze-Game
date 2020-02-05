using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPMovement : MonoBehaviour {
	public float inputX;
	public float inputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed;
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
		controller.Move (desiredMoveDirection * Time.deltaTime * 4f);
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

		if(blockRotationPlayer == false){
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
		}
	}

	void InputMagnitude(){
		//calculate input Vectors
		inputX = Input.GetAxis ("Horizontal");
		inputZ = Input.GetAxis ("Vertical");

		//0.03f makes animation transitions smoother.
		anim.SetFloat ("InputZ", inputZ, 0.1f, Time.deltaTime * 1f);
		anim.SetFloat ("InputX", inputX, 0.1f, Time.deltaTime * 1f);

		//calculate inpout magnitude
		Speed = new Vector2(inputX,inputZ).sqrMagnitude;

		//physically move player.
		if(Speed > allowPlayerRotation){
			anim.SetFloat ("InputMagnitude", Speed, 0.0f, Time.deltaTime);
			PlayerMoveAndRotation ();
		}
		else if(Speed < allowPlayerRotation){
			anim.SetFloat ("InputMagnitude", Speed, 0.0f, Time.deltaTime);
		}
	}
}
