using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    private PlayerController controls;
    
    
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerController();
        controls.Enable();
        moveSpeed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 direction = new Vector3(context.ReadValue<Vector2>().x, 0,context.ReadValue<Vector2>().x).normalized;

        if (context.performed)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0); 
            controller.Move(direction);
            
        }
        

        
        
        
    }
}
