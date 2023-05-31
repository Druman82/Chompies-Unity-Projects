using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = .5f;
    public FixedJoystick joystickR;
    public Transform playerBody;
    public GameObject joystickCanvas;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystickR.Horizontal;
        float y = joystickR.Vertical;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            joystickCanvas.SetActive(true);

            x *= mouseSensitivity;
            y *= mouseSensitivity;

            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * x);
        }
        else
        {
            joystickCanvas.SetActive(false);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}