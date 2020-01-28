using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidBody : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 360;
    public float moveSpeed = 20;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
    }
    private void ApplyInput(float moveInput,float turnInput){
        Move(moveInput);
        Turn(turnInput);
    }
    private void Move(float input){
        //transform.Translate(Vector3.forward*input*moveSpeed);
        rb.AddForce(transform.forward*input*moveSpeed,ForceMode.Force);
    }
    private void Turn(float input){
        transform.Rotate(0,input*rotationRate*Time.deltaTime,0);
    }
}
