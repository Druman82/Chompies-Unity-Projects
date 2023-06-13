using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementKeyboard : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 1f;
    public FixedJoystick joystickL;
    public AudioSource waterSound;


    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            float x = joystickL.Horizontal;
            float z = joystickL.Vertical;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * (speed / 1.5f) * Time.deltaTime);

            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }

        //Water collision
        if (other.gameObject.layer == 4)
        {
            if (Settings.soundFXBool == true)
            {
                waterSound.Play();
            }
        }
    }
}
