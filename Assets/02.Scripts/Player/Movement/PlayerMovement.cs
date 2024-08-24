using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController characterController;

    [Header("Gravity")]
    public float gravity = -9.81f; 
    public float gravityMultiplier = 3.0f;
    private Vector3 velocity;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }


    void Update()
    {
        Movement();
        ApplyGravity();   
    }

    private void Movement()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        if (Move != Vector3.zero)
        {
            characterController.Move((Move * SpeedMove + velocity) * Time.deltaTime);
            PlayerController.Instance.ChangeCharacterState(State.Run);
        }
        else
        {
            PlayerController.Instance.ChangeCharacterState(State.Idle);
        }

    }

    private void ApplyGravity()
    {
        if (IsGrounded())
        {
            if (velocity.y < 0)
            {
                velocity.y = -1f;
            }
        }
        else
        {
            velocity.y += gravity * gravityMultiplier * Time.deltaTime;
        }
    }



    private bool IsGrounded() => characterController.isGrounded;
}
