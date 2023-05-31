using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickLook : MonoBehaviour
{
    public float mouseSensitivity = 4f;
    public FixedJoystick joystickR;
    public Transform player;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = joystickR.Horizontal;
        float y = joystickR.Vertical;

        x *= mouseSensitivity;
        y *= mouseSensitivity;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * x);
    }
}