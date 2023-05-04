using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertSpin : MonoBehaviour
{
    float speed = 50.0f;

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
