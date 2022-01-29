using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]public Rigidbody playerRb;
    public GameObject player;
    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight;
    public Camera mainCamera;
    private float strafeSpeed;
    

    private void Start()
    {
        playerRb = Rigidbody.FindObjectOfType<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        walkSpeed = 10;
        runSpeed = 30;
        mainCamera = Camera.main;
        strafeSpeed = 10;
    }

    private void OnMove()
    {
        Vector3 moveDirection = new Vector3(mainCamera.transform.position.x,0,0);
        playerRb.AddForce(moveDirection);
    }

    private void OnStrafe()
    {
        Vector3 strafeDirection = new Vector3(0,0,strafeSpeed);
        playerRb.AddForce(strafeDirection);
    }

    private void OnJump()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
