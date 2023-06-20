using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotate : MonoBehaviour
{
    float speed = 50.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
