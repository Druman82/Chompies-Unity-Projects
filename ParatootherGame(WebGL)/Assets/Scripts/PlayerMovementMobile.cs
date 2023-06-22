using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementMobile : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 1f;
    public FixedJoystick joystickL;


    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = joystickL.Horizontal;
        float z = joystickL.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }
    }

}
