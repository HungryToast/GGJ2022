using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera playerCam;
    
    public Animator animator;
    public int isWalkingHash;
    public int isRunningHash;

    private PlayerController input;

    private Vector2 currentMovement;
    private bool movementPressed;
    private bool runPressed;
    private void Awake()
    {
        input = new PlayerController();
        input.Keyboard.Move.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        
        input.Keyboard.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
        input.Keyboard.Run.canceled += ctx => runPressed = false;

        input.Keyboard.MouseDelta.performed += ctx => ctx.ReadValue<Vector2>();
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        playerCam = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (movementPressed && runPressed && !isRunning)
        {
            animator.SetBool(isRunningHash,true);
        }
        
        if (!movementPressed || !runPressed && isRunning)
        {
            animator.SetBool(isRunningHash,false);
        }
    }

    void HandleRotation()
    {

        Vector3 currentPosition = transform.position;

        Vector3 newPosition = new Vector3(currentMovement.x , 0, currentMovement.y);

        Vector3 positionToLookAt = currentPosition + newPosition ;
        
        transform.LookAt(positionToLookAt);
        
    }

    



    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
