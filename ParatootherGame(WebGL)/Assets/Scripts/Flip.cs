using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    float speed = 50.0f;

    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
