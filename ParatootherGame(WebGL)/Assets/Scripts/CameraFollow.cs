using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target1 = null;
    [SerializeField] private Transform target2 = null;
    [SerializeField] private Transform target3 = null;
    [SerializeField] private Transform target4 = null;
    [SerializeField] private Transform target5 = null;
    [SerializeField] private Transform target6 = null;
    private Transform target;
    public Vector3 offset;
    public static bool jetpack;
    public static int up;
    public static bool portal;
    public static bool frogFeet;

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.target == 1)
        {
            target = target1;
        }
        else if (Settings.target == 2)
        {
            target = target2;
        }
        else if (Settings.target == 3)
        {
            target = target3;
        }
        else if (Settings.target == 4)
        {
            target = target4;
        }
        else if (Settings.target == 5)
        {
            target = target5;
        }
        else if (Settings.target == 6)
        {
            target = target6;
        }
        offset = transform.position - target.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y >= 8)
        {
            up = 3;
        }

        else if (target.position.y >= 6 && target.position.y < 7.5)
        {
            up = 2;
        }

        else if (target.position.y >= 4 && target.position.y < 5)
        {
            up = 1;
        }

        else if(target.position.y <= 1.5f)
        {
            up = 0;
        }

        if(up == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0.5f, target.position.z) + offset, Time.deltaTime);
        }
        else if (up == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 2, target.position.z) + offset, Time.deltaTime);
        }
        else if (up == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 3f, target.position.z) + offset, Time.deltaTime);
        }
        else if (up == 3)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 5, target.position.z) + offset, Time.deltaTime);
        }


        if (jetpack == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z) + offset, Time.deltaTime * 2);
        }

        if (portal == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x - 4, target.position.y - 3, target.position.z + 15) + offset, Time.deltaTime * 2);
        }
        
        if (frogFeet == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z) + offset, Time.deltaTime * 2);
        }
    }
/*
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }*/
}
